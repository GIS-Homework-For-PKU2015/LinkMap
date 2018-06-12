using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//图层类
namespace LinkMapObject
{
    public class LinkLayer
    {
        #region 字段
        private List<object> _items = new List<object>();//图层内的数据(但是这object是不是有问题) 啥问题？？
        private bool _isVisble = true; //图层可见性
        private iType _type = iType.Null;//图层中数据类型 枚举
        private string _name="";
        private string _descript = "";//图层描述信息
        private DataTable _dt = new DataTable();//装属性数据
        #endregion

        #region 构造函数
        public LinkLayer() {
            _type = iType.Null;
        }
        public LinkLayer (iType t) {
            _type = t;
        }
        public LinkLayer(PointD poi) {
            _items.Add(poi);
            _type = iType.PointD;
        }
        public LinkLayer (List<PointD> plst) {
            foreach (PointD p in plst) {
                _items.Add(p);
            }
            _type = iType.PointD;//注意pd和multipoint的区分
        }

        public LinkLayer(PointD[] pois) {
            foreach(PointD p in pois) {
                _items.Add(p);
            }
            _type = iType.MultiPoint; //or pointd;
        }
        public LinkLayer(Polyline pline) {
            _items.Add(pline);
            _type = iType.Polyline;
        }
        public LinkLayer(Polygon poly) {
            _items.Add(poly);
            _type = iType.Polygon;
        }
        public LinkLayer(MultiPolygon mpoly) {
            _items.Add(mpoly);
            _type = iType.MultiPolygon;
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

        /// <summary>
        /// 图层名称
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        /// <summary>
        /// 图层描述
        /// </summary>
        public string Description {
            get {
                return _descript;
            }
            set {
                _descript = value;
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
            set {
                _type = value;
            }
        }
        //枚举 foreach用
        public IEnumerator<object> GetEnumerator () {
            return _items.GetEnumerator();
        }
        public DataTable Table {
            get {
                return _dt;
            }
            set {
                _dt = value;
            }
        }


        #endregion


        #region 方法
        /// <summary>
        /// 获取该图层的要素类型
        /// </summary>
        /// <param name="slayer"></param>
        /// <returns></returns>
        public iType LayerGetVectorPorperties()
        {
            return mapType;
        }

        //ublic int LayerIdentifyVector(PointD spoint)
        //
        //   //遍历item
        //   for(int i=0;i< _items.Count; i++)
        //   {
        //       //for(int j=0;j< _items[i].Count) //这里面发现object类可能有问题
        //       if (_items[i] == spoint)
        //           return i;
        //   }
        //   return -1;




        //显示注记（吉梁部分）
        public void LayerShowLabel()
        {

        }




        #endregion

        #region 加要素
        //注：这里不进行类型判断，在调用的时候尽量进行，不要出现点图层还加线要素的情况
        public void AddPointD (PointD pd) {
            _items.Add(pd);
        }
        public void AddPolyline (Polyline line) {
            _items.Add(line);
        }
        public void AddPolygon (Polygon poly) {
            _items.Add(poly);
        }


        public void addFeature (object obj) {
            _items.Add(obj);//尽量不用这一个
        }

#endregion

    }
}
