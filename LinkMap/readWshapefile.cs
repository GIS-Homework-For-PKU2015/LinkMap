﻿using LinkMapObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkMap {
    class readWshapefile {
        #region 字段
        private string _filePath = "";//单纯路径，没有名字
        private string _fname = "";//单纯名字
        private string _fileShp = @"D:\GeoData\测试用数据\twoTestPolygonNotAtt.shp";//路径加名字
        private string _dbfFullPath = @"D:\GeoData\测试用数据\twoTestPolygonNotAtt.dbf";
        //private string _savefile = "";
        private LinkLayer _layer = new LinkLayer(); //要素变图层
        private DataTable _dt = new DataTable();//属性数据
        //private bool readDone = false;

        #endregion
        #region 构造函数
        public readWshapefile () {

        }
        public readWshapefile (string shpfile) {
            _fileShp = shpfile;

        }

        #endregion
        #region 属性
        /// <summary>
        /// 需要读取的shp路径以及名称
        /// </summary>
        public string FilePath { //单纯路径，没有名字
            get {
                return _fileShp;
            }
            set {
                _fileShp = value;
            }
        }
        public string FileName { //单纯名字 一般包含后缀
            get {
                return _fname;
            }
            set {
                _fname = value;
            }
        }
        /// <summary>
        /// 获取dbf中的属性数据
        /// </summary>
        public DataTable datatable {
            get {
                return _dt;
            }
        }
        /// <summary>
        /// 获取或设置图层名称
        /// </summary>
        public string LayerName  {
            get {
               return _layer.Name;
            }
            set {
                _layer.Name = value;
            }
            
        }

        #endregion
        #region 方法
        /// <summary>
        /// 读入shp，并生成一个图层
        /// </summary>
        public bool readShp () {
            return ReadToLayer();
            //注意shp得到的多边形起点和终点一样，这个可能和我们画的不一样，要区分好，编辑节点可能有问题
            
        }
        public void readDbf () {
            ReadDbfToLayer();
            _layer.Table = _dt;
        }
        public void readDbf (string dbf_path) {
            _dbfFullPath = dbf_path;
            ReadDbfToLayer();
        }
        public LinkLayer GetShpLayer {
            get {
                return _layer;
            }
        }
        // 写入shp 不去实现了

        public void readShpToTxt () {

        }
        public void readShpToKml () {

        }

        #endregion
        #region 私有函数
        private bool ReadToLayer () {
            //1，读入
            OpenFileDialog openShpFD = new OpenFileDialog();
            openShpFD.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            openShpFD.InitialDirectory = "D://";
            if (openShpFD.ShowDialog() == DialogResult.OK) {
                _fileShp = openShpFD.FileName;
                splitPathToName();
            }
            else {
                return false;
            }
            FileStream fs = new FileStream(_fileShp, FileMode.Open);
            BinaryReader brShp = new BinaryReader(fs);
            //读取文件过程
            brShp.ReadBytes(24);
            int FileLength = brShp.ReadInt32(); // <0代表数据长度未知
            int FileBanben = brShp.ReadInt32();
            int ShapeType = brShp.ReadInt32();
            double xmin, ymin, xmax, ymax;
            xmin = brShp.ReadDouble();
            ymax = brShp.ReadDouble();
            xmax = brShp.ReadDouble();
            ymin = brShp.ReadDouble();
            double width = xmax - xmin;
            double height = ymax - ymin;

            brShp.ReadBytes(32);

            switch (ShapeType) {
                case 0://null type
                    break;
                case 1://point
                    List<PointD> plst = new List<PointD>();
                    while (brShp.PeekChar() != -1) {//Peek只是看没有真正取出来
                        uint recordNum = brShp.ReadUInt32();
                        int dataLen = brShp.ReadInt32();
                        brShp.ReadInt32(); //??
                        PointD point = new PointD(brShp.ReadDouble(), -brShp.ReadDouble());
                        plst.Add(point);//需要时删掉上面一句里的负号

                    }
                    LinkLayer poiLayer = new LinkLayer(plst);
                    if (_fname != "") {
                        poiLayer.Name = _fname;
                    }
                    else {
                        poiLayer.Name ="fromShp";
                    }
                    poiLayer.Description = "from shapefile";
                    //mapControl1.AddPoiList(plst);
                    //mapControl1.Refresh();
                    _layer = poiLayer;

                    break;

                case 3://polyline
                    //先以保存到文件为宗旨
                    //List<PointD> plst2 = new List<PointD>();
                    //StreamWriter swline = new StreamWriter(@"E:\ComputerGraphicsProj\GISdesign\lineOut02.txt");
                    LinkLayer lineLayer = new LinkLayer(iType.Polyline);
                    
                    //string lineDescri = "";
                    while (brShp.PeekChar() != -1) {
                        Polyline pline = new Polyline();
                        uint recordNum = brShp.ReadUInt32();
                        int dataLen = brShp.ReadInt32();
                        brShp.ReadInt32();
                        double box0x = brShp.ReadDouble();
                        double box0y = brShp.ReadDouble();
                        double box1x = brShp.ReadDouble();
                        double box1y = brShp.ReadDouble();
                        //swline.WriteLine("box:{0},{1},{2},{3}; recordNum={4},datalen={5}", box0x, box0y, box1x, box1y, recordNum, dataLen);
                        //lineDescri += "box:";
                        int numParts = brShp.ReadInt32();
                        int numPoints = brShp.ReadInt32();
                        //swline.WriteLine("numParts:{0}; numPoints:{1}\n parts:", numParts, numPoints);
                        List<int> parts = new List<int>();
                        for (int i = 0; i < numParts; i++) {
                            int p = brShp.ReadInt32();
                            parts.Add(p);
                            //swline.WriteLine("{0}", p);
                        }
                        //swline.WriteLine("line:");
                        for (int i = 0; i < numPoints; i++) {
                            double px1 = brShp.ReadDouble();
                            double px2 = brShp.ReadDouble();
                            //swline.Write("[{0},{1}],", px1, px2);
                            //循环一次产生一条polyline
                            PointD pd1 = new PointD(px1, -px2);
                            pline.AddPoint(pd1);
                            //plst2.Add(pd1);
                        }
                        lineLayer.AddPolyline(pline);
                    }

                    //swline.Close();
                    
                    if (_fname != "") {
                        lineLayer.Name = _fname;
                    }
                    else {
                        lineLayer.Name = "fromShp";
                    }
                    lineLayer.Description = "from shapefile";
                    //mapControl1.AddPoiList(plst);
                    //mapControl1.Refresh();
                    _layer = lineLayer;

                    break;
                case 5://polygon

                    //List<PointD> plst3 = new List<PointD>();
                    //StreamWriter swline2 = new StreamWriter(@"E:\ComputerGraphicsProj\GISdesign\polygonOut01.txt");
                    LinkLayer polyLayer = new LinkLayer(iType.Polygon);
                    //poiLayer.mapType =iType.Polygon;//需要补上set
                    
                    while (brShp.PeekChar() != -1) {
                        Polygon mpoly = new Polygon();

                        uint recordNum = brShp.ReadUInt32();
                        int dataLen = brShp.ReadInt32();
                        brShp.ReadInt32();
                        double box0x = brShp.ReadDouble();
                        double box0y = brShp.ReadDouble();
                        double box1x = brShp.ReadDouble();
                        double box1y = brShp.ReadDouble();
                        ///swline2.WriteLine("box:{0},{1},{2},{3}; recordNum={4},datalen={5}", box0x, box0y, box1x, box1y, recordNum, dataLen);
                        int numParts = brShp.ReadInt32();
                        int numPoints = brShp.ReadInt32();
                        //swline2.WriteLine("numParts:{0}; numPoints:{1}\n parts:", numParts, numPoints);
                        List<int> parts = new List<int>();
                        for (int i = 0; i < numParts; i++) {
                            int p = brShp.ReadInt32();
                            parts.Add(p);
                            //swline2.WriteLine("{0}", p);
                        }
                        //swline2.WriteLine("line:");
                        for (int i = 0; i < numPoints; i++) {
                            double px1 = brShp.ReadDouble();//x
                            double px2 = brShp.ReadDouble();//y
                            //swline2.Write("[{0},{1}], ", px1, px2);
                            PointD pd1 = new PointD(px1, -px2);
                            //plst3.Add(pd1);
                            mpoly.AddPoint(pd1);
                        }

                        //还应该拆子多边形出来；
                        polyLayer.AddPolygon(mpoly);
                        //运行到这里生成一个多边形

                    }

                    //swline2.Close();
                    
                    if (_fname != "") {
                        polyLayer.Name = _fname;
                    }
                    else {
                        polyLayer.Name = "fromShp";
                    }
                    polyLayer.Description = "from shapefile";
                    //mapControl1.AddPoiList(plst);
                    //mapControl1.Refresh();
                    _layer = polyLayer;


                    break;
                case 8://multipoint
                    Polyline sq = new Polyline();
                    //PointD pw1 = new PointD();

                    break;
                case 11://pointZ
                    break;
                case 13:
                    break;
                case 15:
                    break;
                case 18:
                    break;
                case 21:
                    break;
                case 23:
                    break;
                case 25:
                    break;
                case 28:
                    break;
                case 31://multipatch 复合要素
                    break;

            }



            return true;
            //2，展示到mapControl上   应该是生成一个新图层

        }

        
        private void ReadDbfToLayer () {
            try {
                FileStream fs = new FileStream(_dbfFullPath, FileMode.Open);

                ReadDbfByFname(fs);
            }
            catch(Exception exp) {
                MessageBox.Show(exp.Message);

                OpenFileDialog opendbf = new OpenFileDialog();
                opendbf.Filter = "shapefileDbf(*.dbf)|*.dbf|All files(*.*)|*.*";
                opendbf.Title = "请选择对应dbf文件";
                if (opendbf.ShowDialog() == DialogResult.OK) {
                    _dbfFullPath = opendbf.FileName;
                }
                FileStream fs = new FileStream(_dbfFullPath, FileMode.Open);

                ReadDbfByFname(fs);
            }
        }

        private void ReadDbfByFname (FileStream fs) {
            
            //string fwpath = @"E:\ComputerGraphicsProj\GISdesign\pointDbfOut34.txt";
            //StreamWriter swDbf = new StreamWriter(fwpath);
            BinaryReader brShp = new BinaryReader(fs);
            //读取文件过程
            byte oversion = brShp.ReadByte(); //文件版本，一般是 3
            int oyear = brShp.ReadByte() + 1900;
            byte omonth = brShp.ReadByte();
            byte oday = brShp.ReadByte();
            int numOfRecords = brShp.ReadInt32();//+4  // 文件中的记录条数.
            int HeaderLen = brShp.ReadInt16(); // 文件头中的字节数
            int oneRecordLen = brShp.ReadInt16(); // 一条记录中的字节长度
            //swDbf.WriteLine("ver:{0};year-month-day:{1}-{2}-{3}", oversion, oyear, omonth, oday);
            //swDbf.WriteLine("numOfRecords:{0}; HeaderLen:{1};oneRecordLen:{2}", numOfRecords, HeaderLen, oneRecordLen);
            byte[] awqdfd11 = brShp.ReadBytes(16);//2+1+1+12
            byte mdxMark = brShp.ReadByte();//DBF文件的MDX标识。
            byte langID = brShp.ReadByte();//languageDriverId 国家导出：77 国家标准：0  arcgis导出：77 
            byte[] awqdfd12 = brShp.ReadBytes(2);

            int numFields = (HeaderLen - 33) / 32;
            //swDbf.WriteLine("numFields:{0}", numFields);
            int nDataOffset = 1;
            List<object> mFields = new List<object>();
            int[] recordILen = new int[numFields];
            for (int i = 0; i < numFields; i++) {
                byte[] nbytes = brShp.ReadBytes(11);//记录项名称，是ASCII码值
                Encoding encoding = Encoding.ASCII;//只是11个byte会出现长于11的记录不全
                string sFieldName = encoding.GetString(nbytes);
                string sw1234 = Convert.ToString(nbytes);
                string sw12 = Encoding.Default.GetString(nbytes);

                int nullPoint = sFieldName.IndexOf((char)0);
                if (nullPoint != -1)
                    sFieldName = sFieldName.Substring(0, nullPoint);
                //read the field type
                char cDbaseType = (char)brShp.ReadByte();//记录项的数据类型，是ASCII码值

                // read the field data address, offset from the start of the record.
                int nFieldDataAddress = brShp.ReadInt32(); // +4
                
                int nFieldLength = 0;
                int nDecimals = 0;
                if (cDbaseType == 'C' || cDbaseType == 'c') {
                    //treat decimal count as high byte
                    nFieldLength = (int)brShp.ReadUInt16();//记录项长度
                }
                else {
                    //read field length as an unsigned byte.
                    nFieldLength = (int)brShp.ReadByte();
                    //read decimal count as one byte
                    nDecimals = (int)brShp.ReadByte();//记录项的精度
                }
                recordILen[i] = nFieldLength;
                //read the reserved bytes.
                brShp.ReadBytes(14);
                //Create and add field to collection
                //mFields.Add(new DbfColumn(sFieldName, DbfColumn.GetDbaseType(cDbaseType), nFieldLength, nDecimals, nDataOffset));
                //swDbf.WriteLine("Name:{0}\t;Len:{1}\t;Decimals:{2}\t;DataOffset:{3}\t", sFieldName, nFieldLength, nDecimals, nDataOffset);
                _dt.Columns.Add(sFieldName, typeof(String));
                nDataOffset += nFieldLength;

            }
            byte adwed13 = brShp.ReadByte();

            int ColumnDescriptorSize = 32;
            int nExtraReadBytes = HeaderLen - (33 + (ColumnDescriptorSize * numFields));
            if (nExtraReadBytes > 0)
                brShp.ReadBytes(nExtraReadBytes);

            if (brShp.BaseStream.CanSeek && numOfRecords == 0) {
                
                if (oneRecordLen > 0)
                    numOfRecords = (int)Math.Round(((double)(brShp.BaseStream.Length - HeaderLen - 1) / oneRecordLen));

            }
            //读内容部分 record
            //swDbf.WriteLine("===record====");
            List<object> abcd = new List<object>();
            for (int j = 0; j < numOfRecords; j++) {
                byte spaceByte = brShp.ReadByte();//
                DataRow dr = _dt.NewRow();
                for (int i = 0; i < numFields; i++) {
                    byte[] valRow = brShp.ReadBytes(recordILen[i]);
                    string val = Encoding.Default.GetString(valRow);
                    dr[i]=val.Trim();//去除空格
                }
                _dt.Rows.Add(dr);
                //swDbf.WriteLine(wrstr);swDbf.WriteLine("------end one------");
            }
            //swDbf.WriteLine("===end record====");
            //swDbf.Close();
        }


        private void ReadToText () {
            //1，读入
            OpenFileDialog openShpFD = new OpenFileDialog();
            openShpFD.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            openShpFD.InitialDirectory = "D://";
            if (openShpFD.ShowDialog() == DialogResult.OK) {
                _fileShp = openShpFD.FileName;
                splitPathToName();
            }
            FileStream fs = new FileStream(_fileShp, FileMode.Open);
            BinaryReader brShp = new BinaryReader(fs);
            //读取文件过程
            brShp.ReadBytes(24);
            int FileLength = brShp.ReadInt32(); // <0代表数据长度未知
            int FileBanben = brShp.ReadInt32();
            int ShapeType = brShp.ReadInt32();
            double xmin, ymin, xmax, ymax;
            xmin = brShp.ReadDouble();
            ymax = brShp.ReadDouble();
            xmax = brShp.ReadDouble();
            ymin = brShp.ReadDouble();
            double width = xmax - xmin;
            double height = ymax - ymin;

            brShp.ReadBytes(32);

            switch (ShapeType) {
                case 0://null type
                    break;
                case 1://point
                    List<PointD> plst = new List<PointD>();
                    while (brShp.PeekChar() != -1) {//Peek只是看没有真正取出来
                        uint recordNum = brShp.ReadUInt32();
                        int dataLen = brShp.ReadInt32();
                        brShp.ReadInt32(); //??
                        PointD point = new PointD(brShp.ReadDouble(), -brShp.ReadDouble());
                        plst.Add(point);

                    }

                    //mapControl1.AddPoiList(plst);
                    //mapControl1.Refresh();
                    string fpath = @"E:\ComputerGraphicsProj\GISdesign\pointOut02.txt";
                    //writeShpPointsToFile(plst, fpath);
                    break;

                case 3://polyline
                    //先以保存到文件为宗旨
                    List<PointD> plst2 = new List<PointD>();
                    StreamWriter swline = new StreamWriter(@"E:\ComputerGraphicsProj\GISdesign\lineOut02.txt");
                    while (brShp.PeekChar() != -1) {

                        uint recordNum = brShp.ReadUInt32();
                        int dataLen = brShp.ReadInt32();
                        brShp.ReadInt32();
                        double box0x = brShp.ReadDouble();
                        double box0y = brShp.ReadDouble();
                        double box1x = brShp.ReadDouble();
                        double box1y = brShp.ReadDouble();
                        swline.WriteLine("box:{0},{1},{2},{3}; recordNum={4},datalen={5}", box0x, box0y, box1x, box1y, recordNum, dataLen);
                        int numParts = brShp.ReadInt32();
                        int numPoints = brShp.ReadInt32();
                        swline.WriteLine("numParts:{0}; numPoints:{1}\n parts:", numParts, numPoints);
                        List<int> parts = new List<int>();
                        for (int i = 0; i < numParts; i++) {
                            int p = brShp.ReadInt32();
                            parts.Add(p);
                            swline.WriteLine("{0}", p);
                        }
                        swline.WriteLine("line:");
                        for (int i = 0; i < numPoints; i++) {
                            double px1 = brShp.ReadDouble();
                            double px2 = brShp.ReadDouble();
                            swline.Write("[{0},{1}],", px1, px2);
                            //循环一次产生一条polyline
                            PointD pd1 = new PointD(px1, px2);
                            plst2.Add(pd1);
                        }

                    }
                    //mapControl1.AddPoiList(plst2);
                    //mapControl1.Refresh();
                    swline.Close();

                    break;
                case 5://polygon
                       //先以保存到文件为宗旨
                    List<PointD> plst3 = new List<PointD>();
                    StreamWriter swline2 = new StreamWriter(@"E:\ComputerGraphicsProj\GISdesign\polygonOut01.txt");
                    while (brShp.PeekChar() != -1) {

                        uint recordNum = brShp.ReadUInt32();
                        int dataLen = brShp.ReadInt32();
                        brShp.ReadInt32();
                        double box0x = brShp.ReadDouble();
                        double box0y = brShp.ReadDouble();
                        double box1x = brShp.ReadDouble();
                        double box1y = brShp.ReadDouble();
                        swline2.WriteLine("box:{0},{1},{2},{3}; recordNum={4},datalen={5}", box0x, box0y, box1x, box1y, recordNum, dataLen);
                        int numParts = brShp.ReadInt32();
                        int numPoints = brShp.ReadInt32();
                        swline2.WriteLine("numParts:{0}; numPoints:{1}\n parts:", numParts, numPoints);
                        List<int> parts = new List<int>();
                        for (int i = 0; i < numParts; i++) {
                            int p = brShp.ReadInt32();
                            parts.Add(p);
                            swline2.WriteLine("{0}", p);
                        }
                        swline2.WriteLine("line:");
                        for (int i = 0; i < numPoints; i++) {
                            double px1 = brShp.ReadDouble();
                            double px2 = brShp.ReadDouble();
                            swline2.Write("[{0},{1}], ", px1, px2);
                            PointD pd1 = new PointD(px1, px2);
                            plst3.Add(pd1);

                        }

                        //还应该拆子多边形出来；

                        //运行到这里生成一个多边形

                    }
                    //mapControl1.AddPoiList(plst3);
                    //mapControl1.Refresh();
                    swline2.Close();



                    break;
                case 8://multipoint
                    Polyline sq = new Polyline();
                    //PointD pw1 = new PointD();

                    break;
                case 11://pointZ
                    break;
                case 13:
                    break;
                case 15:
                    break;
                case 18:
                    break;
                case 21:
                    break;
                case 23:
                    break;
                case 25:
                    break;
                case 28:
                    break;
                case 31://multipatch 复合要素
                    break;

            }




            //2，展示到mapControl上   应该是生成一个新图层

        }

        private void readDbfToText () {
            string shpPath = @"D:\GeoData\测试用数据\threePoiForReadTest.dbf";
            string fwpath = @"E:\ComputerGraphicsProj\GISdesign\pointDbfOut04.txt";
            StreamWriter swDbf = new StreamWriter(fwpath);

            FileStream fs = new FileStream(shpPath, FileMode.Open);
            BinaryReader brShp = new BinaryReader(fs);
            //读取文件过程
            byte oversion = brShp.ReadByte(); //文件版本，一般是 3
            int oyear = brShp.ReadByte() + 1900;
            byte omonth = brShp.ReadByte();
            byte oday = brShp.ReadByte();
            int numOfRecords = brShp.ReadInt32();//+4  // 文件中的记录条数.
            int HeaderLen = brShp.ReadInt16(); // 文件头中的字节数
            int oneRecordLen=brShp.ReadInt16(); // 一条记录中的字节长度
            swDbf.WriteLine("ver:{0};year-month-day:{1}-{2}-{3}",oversion,oyear,omonth,oday);
            swDbf.WriteLine("numOfRecords:{0}; HeaderLen:{1};oneRecordLen:{2}", numOfRecords,HeaderLen,oneRecordLen);
            byte[] awqdfd11= brShp.ReadBytes(16);//2+1+1+12
            byte mdxMark = brShp.ReadByte();//DBF文件的MDX标识。
            byte langID = brShp.ReadByte();//languageDriverId 国家导出：77 国家标准：0  arcgis导出：77 
            byte[] awqdfd12 = brShp.ReadBytes(2);

            int numFields = (HeaderLen - 33) / 32;
            swDbf.WriteLine("numFields:{0}", numFields);
            int nDataOffset = 1;
            List<object> mFields = new List<object>();
            int[] recordILen = new int[numFields];
            for (int i = 0; i < numFields; i++) {
                byte[] nbytes = brShp.ReadBytes(11);//记录项名称，是ASCII码值
                Encoding encoding = Encoding.ASCII;
                string sFieldName =encoding.GetString(nbytes);
                string sw1234 = Convert.ToString(nbytes);
                string sw12 = Encoding.Default.GetString(nbytes);

                int nullPoint = sFieldName.IndexOf((char)0);
                if (nullPoint != -1)
                    sFieldName = sFieldName.Substring(0, nullPoint);

                //read the field type
                char cDbaseType = (char)brShp.ReadByte();//记录项的数据类型，是ASCII码值

                // read the field data address, offset from the start of the record.
                int nFieldDataAddress = brShp.ReadInt32(); // +4

                //

                int nFieldLength = 0;
                int nDecimals = 0;
                if (cDbaseType == 'C' || cDbaseType == 'c') {
                    //treat decimal count as high byte
                    nFieldLength = (int)brShp.ReadUInt16();//记录项长度
                }
                else {
                    //read field length as an unsigned byte.
                    nFieldLength = (int)brShp.ReadByte();

                    //read decimal count as one byte
                    nDecimals = (int)brShp.ReadByte();//记录项的精度
                }
                recordILen[i] = nFieldLength;
                //read the reserved bytes.
                brShp.ReadBytes(14);

                //Create and add field to collection
                //mFields.Add(new DbfColumn(sFieldName, DbfColumn.GetDbaseType(cDbaseType), nFieldLength, nDecimals, nDataOffset));
                swDbf.WriteLine("Name:{0}\t;Len:{1}\t;Decimals:{2}\t;DataOffset:{3}\t", sFieldName,nFieldLength, nDecimals, nDataOffset);
                // add up address information, you can not trust the address recorded in the DBF file...
                nDataOffset += nFieldLength;


            }

            byte adwed13= brShp.ReadByte();

            int ColumnDescriptorSize = 32;
            int nExtraReadBytes = HeaderLen - (33 + (ColumnDescriptorSize * numFields));
            if (nExtraReadBytes > 0)
                brShp.ReadBytes(nExtraReadBytes);

            if (brShp.BaseStream.CanSeek && numOfRecords == 0) {
                //notice here that we subtract file end byte which is supposed to be 0x1A,
                //but some DBF files are incorrectly written without this byte, so we round off to nearest integer.
                //that gives a correct result with or without ending byte.
                if (oneRecordLen > 0)
                    numOfRecords = (int) Math.Round(((double)(brShp.BaseStream.Length - HeaderLen - 1) / oneRecordLen));

            }
            //读内容部分 record
            DataTable dt = new DataTable();
            swDbf.WriteLine("===record====");
            List<object> abcd = new List<object>();
            for (int j = 0; j < numOfRecords; j++) {
                byte spaceByte = brShp.ReadByte();//
                //DataRow dr = dt.NewRow();
                string wrstr = "";
                for (int i = 0; i < numFields; i++) {
                    byte[] valRow = brShp.ReadBytes(recordILen[i]);
                    string val = Encoding.ASCII.GetString(valRow);
                    string val2 = Encoding.Default.GetString(valRow);
                    string val3 = Encoding.UTF8.GetString(valRow);
                    wrstr =wrstr+"--"+ "ASCII:"+ val + ";Default:"+val2+ ";UTF8:" + val3+"|";
                    //dr[i]=val;
                }
                swDbf.WriteLine(wrstr);
                swDbf.WriteLine("------end one------");
                //dt.Rows.Add(dr);
            }

            swDbf.WriteLine("===end record====");
            swDbf.Close();
        }

        //datatable to txt file
        private void DTtoTxt (string fileName) {


        }


        private void splitPathToName () {
            try {
                int sidx = _fileShp.LastIndexOf("\\");
                _filePath = _fileShp.Substring(0, sidx);
                _fname = _fileShp.Substring(sidx + 1, _fileShp.Length - sidx - 1 - 4);//除去 .shp
                _dbfFullPath = _filePath + "/" + _fname + ".dbf";
            }catch (Exception  exp){

            }
        }


        #endregion


    }
}
