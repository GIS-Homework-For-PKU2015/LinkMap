using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//图层类
namespace LinkMapObject {
    public class MapLayer {
        #region 字段
        private List<object> _items = new List<object>();//图层内的数据
        private bool _isVisble = true; //图层可见性
        private iType _type = iType.PointD;//图层中数据类型 枚举

        #endregion
        #region 构造函数
        public MapLayer () {

        }
        public MapLayer (PointD poi) {
            _items.Add(poi);
        }
        public MapLayer (PointD[] pois) {
            foreach(PointD p in pois) {
                _items.Add(p);
            }
        }
        public MapLayer (Polyline pline) {
            _items.Add(pline);
        }
        public MapLayer (Polygon poly) {
            _items.Add(poly);
        }
        public MapLayer (MultiPolygon mpoly) {
            _items.Add(mpoly);
        }

        #endregion

        #region 属性
        /// <summary>
        /// 设置图层是否可见
        /// </summary>
        public bool IsVisble {
            get{
                return _isVisble;
            }set {
                _isVisble = value;
            }
        }

        public int Count {
            get {
                return _items.Count;
            }//只读
        }
        public iType mapType {
            get {
                return _type;
            }
        }
        
        #endregion  


        #region 方法
        


        #endregion



    }
}
