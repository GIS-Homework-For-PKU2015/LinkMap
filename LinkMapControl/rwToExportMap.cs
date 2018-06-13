using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

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
                foreach (XmlNode fea in xLayLst) {//图层遍历
                    XmlElement xDT = fea["DTable"];

                    LinkLayer lay = new LinkLayer();
                    string visibility = "1";
                    try { 
                        visibility = fea["visibility"].InnerText;
                    }catch { }
                    if (visibility == "1") {//可见 
                        lay.IsVisble = true;
                    }else if (visibility == "0") {
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
            catch (Exception exp) {
                
            }

        }
        //保存或更新文件时候用
        private void mapToEgisFile () {


        }


        //节点转DataTable
        private DataTable nodeToDataTable (XmlElement xdt) {
            XmlElement xcol = xdt["col"];
            string[] cols = xcol.InnerText.Trim().Split(' ');
            DataTable dc = new DataTable();
            foreach (string c in cols) {
                dc.Columns.Add(c, typeof(String));
            }
            try {
                foreach (XmlNode xr in xdt.GetElementsByTagName("row")) {
                    string[] rows = xr.InnerText.Trim().Split(' ');
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

        public List<PointD> strToPList (string coor) {
            List<PointD> oPlst = new List<PointD>();
            string[] clst = coor.Trim().Split(' ');//在这里写Trim比在调用的时候每一次调用都写更好
            foreach (string cv in clst) {
                string[] ct = cv.Split(',');
                PointD pd= new PointD(Convert.ToDouble(ct[0]), Convert.ToDouble(ct[1]));
                oPlst.Add(pd);
            }
            return oPlst;
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
