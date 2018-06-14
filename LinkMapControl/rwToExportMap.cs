using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;

//保存和读取地图文件的类
namespace LinkMapObject {
    public class rwToExportMap {
#region 字段
        private LinkMap _cMap = new LinkMap();
        //private DataTable _dtt = new DataTable();
        private string _egisFile = "";

        #endregion
        #region 构造函数
        public rwToExportMap () {

        }
        public rwToExportMap (string efile) {
            _egisFile = efile;
        }

        #endregion
        #region 接口

        /// <summary>
        /// 获取地图
        /// </summary>
        /// <returns>LinkMap</returns>
        public LinkMap getMap () {
            praseEfile();
            return _cMap;
        }
        /// <summary>
        /// 传 入地图
        /// </summary>
        /// <param name="map"></param>
        public void setMap (LinkMap map) {
            _cMap = map;
        }
        public void SaveEGIS () {
            mapToEgisFile();
        }
        //尽量不用
        public void SaveEGIS (string str) {
            _egisFile = str;
            mapToEgisFile();
        }
        public void SaveEGIS (string str,LinkMap m) {
            _egisFile = str;
            _cMap = m;
            mapToEgisFile();
           
        }

        #endregion
        #region 私有函数
        private void praseEfile () {
            try {
                XmlDocument kmlDToG = new XmlDocument();
                kmlDToG.Load(_egisFile);
                XmlNode xDoc = kmlDToG.GetElementsByTagName("Document")[0];//从Document节点开始遍历
                try {//name description visibility 都不是必须要有的
                    _cMap.MapName = xDoc["name"].InnerText;
                }catch {_cMap.MapName = "unName";}
                try { 
                _cMap.MapDescription = xDoc["description"].InnerText;
                }catch {}

                XmlNodeList xLayLst = ((XmlElement)xDoc).GetElementsByTagName("Folder");
                int numLay = -1;
                foreach (XmlNode fea in xLayLst) {//图层遍历
                    numLay++;
                    XmlElement xDT = fea["DTable"];

                    LinkLayer lay = new LinkLayer();
                    try {
                        lay.Name = fea["name"].InnerText;
                    }
                    catch {
                        lay.Name = "layer" + numLay.ToString();
                    }
                    string visibility = "0";
                    try { 
                        visibility = fea["visibility"].InnerText;
                    }catch { }
                    if (visibility == "0") {//可见 
                        lay.IsVisble = true;
                    }else if (visibility == "1") {
                        lay.IsVisble = false;
                    }
                    else {//kml里这是false
                        lay.IsVisble = true;
                    }

                    XmlNodeList xpmklst = ((XmlElement)fea).GetElementsByTagName("Placemark");
                    foreach (XmlNode gPmk in xpmklst) {//对每个Placemark节点进行遍历
                        if (gPmk["Point"] != null) {
                            XmlElement dpoi = gPmk["Point"];
                            string spoic = dpoi["coordinates"].InnerText;//<coordinates>118.366,36.7</coordinates>
                            string[] pcd = spoic.Split(',');
                            PointD pdOne = new PointD(Convert.ToDouble(pcd[0]), Convert.ToDouble(pcd[1]));
                            lay.mapType = iType.PointD;
                            lay.AddPointD(pdOne);
                        }//MultiPoint 对应在MultiGeometry里
                        else if (gPmk["LineString"] != null) {
                            XmlElement dlnstr = gPmk["LineString"];
                            string spoic = dlnstr["coordinates"].InnerText;//轻量版不关注其他要素
                            lay.mapType = iType.Polyline;
                            lay.AddPolyline(new Polyline(strToPList(spoic)));
                        }//MultiLineString在MultiGeometry里
                        else if (gPmk["Polygon"] != null) {
                            
                            XmlElement dpoly = gPmk["Polygon"];
                            foreach (XmlNode bndary in dpoly.GetElementsByTagName("outerBoundaryIs")) {
                                string spnc = bndary["LinearRing"]["coordinates"].InnerText; //注意不是LineString
                                lay.mapType = iType.Polygon;
                                lay.AddPolygon(new Polygon(strToPList(spnc)));
                                
                            }
                            /*
                            foreach (XmlNode bndary in dpoly.GetElementsByTagName("innerBoundaryIs")) {
                                string spinc = bndary["LinearRing"]["coordinates"].InnerText;
                                lay.mapType = iType.Polygon;
                                lay.AddPolygon(new Polygon(strToPList(spinc)));
                            }
                            */
                            

                        }
                        else if (gPmk["MultiGeometry"] != null) {
                            //geojson里面是分multi点/线/面的，但kml里的MultiGeometry是可以既有点又有线又有面
                            //k转j时需要拆为多个，（没有无损的解决方案吧）
                            XmlElement dmgeom = gPmk["MultiGeometry"];
                            XmlNodeList dmlst = gPmk["MultiGeometry"].ChildNodes;
                            XmlNodeList dmpoi = dmgeom.GetElementsByTagName("Point");//MultiPoint
                            XmlNodeList dmline = dmgeom.GetElementsByTagName("LineString");//MultiLineString
                            XmlNodeList dmpoly = dmgeom.GetElementsByTagName("Polygon");// MultiPolygon
                            if (dmpoi.Count != 0) {
                                foreach (XmlNode poi in dmpoi) {
                                    string spoic = poi["coordinates"].InnerText;//<coordinates>118.366,36.7</coordinates>
                                    string[] pcd = spoic.Split(',');
                                    PointD pdOne = new PointD(Convert.ToDouble(pcd[0]), Convert.ToDouble(pcd[1]));
                                    lay.mapType = iType.MultiPoint;
                                    lay.AddPointD(pdOne);
                                }
                            }
                            if (dmline.Count != 0) { //MultiLineString
                                //多条线在同一个multi里，可以认为是可以整合到一个MultiLineString里的
                                
                            }
                            if (dmpoly.Count != 0) { // MultiPolygon
                                
                            }

                        }

                    }

                    lay.Table= nodeToDataTable(xDT);
                    _cMap.AddLayer(lay);
                }

                
            }
            catch {
                
            }

        }
        //保存或更新文件时候用
        private void mapToEgisFile () {


            XmlDocument xmlVer = new XmlDocument();
            XmlDeclaration xdra = xmlVer.CreateXmlDeclaration("1.0", "UTF-8", null);//这一句还是必须有的
            XmlElement rootElt = xmlVer.CreateElement("kml", "http://www.opengis.net/kml/2.2");
            XmlElement xname = xmlVer.CreateElement("name");
            XmlElement xdesc = xmlVer.CreateElement("description");
            xname.InnerText = _cMap.MapName;
            xdesc.InnerText = _cMap.MapDescription;
            XmlElement xdoc = xmlVer.CreateElement("Document");
            xdoc.AppendChild(xname);
            xdoc.AppendChild(xdesc);
            try {
                foreach (LinkLayer lay in _cMap) {
                    XmlElement xfolder = xmlVer.CreateElement("Folder");
                    XmlElement yname = xmlVer.CreateElement("name");
                    XmlElement ydesc = xmlVer.CreateElement("description");
                    XmlElement yVis = xmlVer.CreateElement("visibility");
                    yname.InnerText = lay.Name;
                    ydesc.InnerText = lay.Description;
                    yVis.InnerText = "1";
                    if (!lay.IsVisble) {
                        yVis.InnerText = "0";
                    }
                    xfolder.AppendChild(yname);
                    xfolder.AppendChild(ydesc);
                    xfolder.AppendChild(yVis);
                    //属性数据写入xml
                    XmlElement xtable = dtableToXelm(lay.Table, xmlVer);
                    xfolder.AppendChild(xtable);
                    // 图层中没有元素怎么办？这个之后解决掉
                    switch (lay.mapType) {
                        case iType.PointD:
                            foreach(PointD p in lay) {
                                XmlElement kcdr = xmlVer.CreateElement("coordinates");
                                kcdr.InnerText = pointdToStr(p);
                                XmlElement kpmk = xmlVer.CreateElement("Placemark");
                                XmlElement kpoi = xmlVer.CreateElement("Point");
                                kpoi.AppendChild(kcdr);
                                kpmk.AppendChild(kpoi);
                                xfolder.AppendChild(kpmk);
                            }
                            break;
                        case iType.MultiPoint:

                            break;
                        case iType.Polyline:
                            foreach (Polyline poly in lay) {
                                XmlElement kcdr = xmlVer.CreateElement("coordinates");
                                kcdr.InnerText = lineToCoord(poly);
                                XmlElement kpmk = xmlVer.CreateElement("Placemark");
                                XmlElement kline = xmlVer.CreateElement("LineString");
                                kline.AppendChild(kcdr);
                                kpmk.AppendChild(kline);
                                xfolder.AppendChild(kpmk);
                            }
                            break;
                        case iType.Polygon:
                            foreach (Polygon poly in lay) {
                                XmlElement kpmk = xmlVer.CreateElement("Placemark");
                                XmlElement kpoi = xmlVer.CreateElement("Polygon");
                                XmlElement kobi = xmlVer.CreateElement("outerBoundaryIs");
                                XmlElement kline = xmlVer.CreateElement("LinearRing");//注意不是LineString
                                XmlElement kcdr = xmlVer.CreateElement("coordinates");
                                kcdr.InnerText = lineToCoord(poly);
                                kline.AppendChild(kcdr);
                                kobi.AppendChild(kline);
                                kpoi.AppendChild(kobi);
                                kpmk.AppendChild(kpoi);
                                xfolder.AppendChild(kpmk);
                            }
                            break;
                        case iType.MultiPolygon:

                            break;


                    }

                    xdoc.AppendChild(xfolder);

                }
                rootElt.AppendChild(xdoc);
                xmlVer.AppendChild(xdra);
                xmlVer.AppendChild(rootElt);
                xmlVer.Save(_egisFile);
            }
            catch (Exception exp) {
                
            }
        }

        

        #endregion
        #region 辅助函数
        //节点转DataTable
        private DataTable nodeToDataTable (XmlElement xdt) {
            DataTable dc = new DataTable();
            if (xdt == null)
                return dc;
            XmlElement xcol = xdt["col"];
            string[] cols = xcol.InnerText.Trim().Split(' ');
            
            foreach (string c in cols) {
                dc.Columns.Add(c, typeof(String));
            }
            try {
                foreach (XmlNode xr in xdt.GetElementsByTagName("row")) {
                    string[] rows = xr.InnerText.Trim().Split(' ');//用空格分隔确实有风险
                    DataRow dr = dc.NewRow();
                    for (int i = 0; i < rows.Length; i++) {
                        dr[i] = rows[i];
                    }
                    dc.Rows.Add(dr);
                }
            }
            catch {

            }
            return dc;
        }

        private XmlElement dtableToXelm (DataTable dat,XmlDocument xver) {
            XmlElement xTable = xver.CreateElement("DTable");
            XmlElement xcol= xver.CreateElement("col");
            //要解决好空值的情况
            //DataColumn dc=dat.
            string scol = "";
            //为了处理空值，还是用i；不用foreach
            int colc = dat.Columns.Count;
            for (int i = 0; i < colc; i++) {
                if (i == 0) {//当然列名不至于为空
                    scol = dat.Columns[i].ColumnName;
                }
                else {
                    scol = scol + " " + dat.Columns[i].ColumnName;
                }
            }
            xcol.InnerText = scol;
            xTable.AppendChild(xcol);
            foreach(DataRow dr in dat.Rows) {
                object[] wdk = dr.ItemArray;
                int wklen = wdk.Length;
                string[] wdr = new string[wklen];
                if (wklen > 0) {
                    try {
                        for (int i = 0; i < wklen; i++) {
                            wdr[i] = Convert.ToString(wdk[i]).Trim().Replace(' ','_');
                        }
                    }
                    catch {

                    }
                }
                XmlElement xrow= xver.CreateElement("row");
                xrow.InnerText = strlstTostr(wdr, " ");
                xTable.AppendChild(xrow);
            }
            return xTable;
        }
        private string strlstTostr (string[] slst,string tt) {
            string aw = ""; //tt默认为空格
            for(int j = 0; j < slst.Length; j++) {
                if (j == 0) {
                    aw = slst[j];
                }
                else {
                    aw = aw + tt + slst[j];
                }
            }
            return aw;
        }
        public List<PointD> strToPList (string coor) {
            List<PointD> oPlst = new List<PointD>();
            string[] clst = coor.Trim().Split(' ');//
            int lenc = clst.Length;
            for(int i = 0; i < lenc; i++) {
                
                if (i == lenc - 1) {
                    string[] ctk = clst[i].Split(',');
                    PointD p = new PointD(Convert.ToDouble(ctk[0]), Convert.ToDouble(ctk[1]));
                    if (p.X == oPlst[0].X && p.Y == oPlst[0].Y)
                        break;
                }
                
                string[] ct = clst[i].Split(',');
                PointD pd = new PointD(Convert.ToDouble(ct[0]), Convert.ToDouble(ct[1]));
                oPlst.Add(pd);
                
            }

            
            return oPlst;
        }

        private string pointdToStr (PointD pd) {
            return pd.X.ToString() + "," + pd.Y.ToString();
        }
        private string lineToCoord (Polyline line) {
            string crd = "";
            for(int i = 0; i < line.PointCount; i++) {
                crd = crd + " " + pointdToStr(line.GetPoint(i));
            }
            return crd.Trim();
        }
        private string lineToCoord (Polygon line) {
            string crd = "";
            for (int i = 0; i < line.PointCount; i++) {
                crd = crd + " " + pointdToStr(line.GetPoint(i));
            }
            return crd.Trim();
        }

        #endregion
    }
}
/*采用kml格式保存，保存Folder标签,下面只列出了我们考虑的参数
 * <kml>
 *     <Document>
 *        <name>
 *        <description>
 *        <Style>
 *        <Folder> 一个Folder是一个图层
 *            <DTable>
 *                  <col>
 *                  <row> 简化，先用空格分隔吧 有空数据怎么办
 *                  <row> 统一都先用string 之后再改
 *        
 *            <Placemark>
 *                <name>
 *                <visibility> 可见性：0：不可见 kml规范是只取0,1；它对于不等于1的值认为是不可见
 *                <description>
 *                <Polygon> 类型
 *                   <ExtendedData> 采用简化版的属性保存方式，先不用ExtendedData了 
 *                   <outerBoundaryIs>
 *                      <LinearRing>
 *                         <coordinates>
 * 
 * 
 * 
 * 可以考虑给每一个<Folder> 也就是图层加一个来源标签，分shp导入和手工画的，虽然不是很必要
 * <DTable>
	<col>stroke stroke-width stroke-opacity fill fill-opacity name ewkd</col>
	<row>stroke stroke-width   fill fill-opacity name ewkd</row>
	<row>stroke   stroke-opacity fill fill-opacity name ewkd</row>
	<row>stroke stroke-width stroke-opacity fill fill-opacity  ewkd</row>
</DTable>
 * 
 * */
