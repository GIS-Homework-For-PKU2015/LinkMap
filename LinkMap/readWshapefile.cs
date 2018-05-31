using LinkMapObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkMap {
    class readWshapefile {
        #region 字段
        private string _filePath = "";//单纯路径，没有名字
        private string _fname = "";//单纯名字
        private string _fileShp = "";//路径加名字
        //private string _savefile = "";

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
        public string File {
            get {
                return _fileShp;
            }
            set {
                _fileShp = value;
            }
        }


        #endregion
        #region 方法
        /// <summary>
        /// 读入shp，并生成一个图层
        /// </summary>
        public void readShp () {

        }

        // 写入shp 不去实现了

        public void readShpToTxt () {

        }
        public void readShpToKml () {

        }

        #endregion

        #region 私有函数
        private void ReadToText () {
            string _sw = "";
            //1，读入
            string shpPath = @"G:\shapeFileTest\POLYGON.shp";
            OpenFileDialog openShpFD = new OpenFileDialog();
            openShpFD.Filter = "shapefile(*.shp)|*.shp|All files(*.*)|*.*";
            openShpFD.InitialDirectory = "D://";
            if (openShpFD.ShowDialog() == DialogResult.OK) {
                shpPath = openShpFD.FileName;
            }
            FileStream fs = new FileStream(shpPath, FileMode.Open);
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
                        PointD point = new PointD(brShp.ReadDouble(), brShp.ReadDouble());
                        plst.Add(point);

                    }

                    //mapControl1.AddPoiList(plst);
                    //mapControl1.Refresh();
                    string fpath = @"G:\shapeFileTest\pointOut02.txt";
                    //writeShpPointsToFile(plst, fpath);
                    break;

                case 3://polyline
                    //先以保存到文件为宗旨
                    List<PointD> plst2 = new List<PointD>();
                    StreamWriter swline = new StreamWriter(@"G:\shapeFileTest\lineOut02.txt");
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
                    StreamWriter swline2 = new StreamWriter(@"G:\shapeFileTest\polygonOut01.txt");
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




            //2，展示到mapControl上   应该是生成一个新图层的

        }


        #endregion


    }
}
