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
            datatableInt();//把datatable初始化一下

        }
        public LinkLayer (iType t) {
            _type = t;
            datatableInt();
        }
        public LinkLayer(PointD poi) {
            _items.Add(poi);
            _type = iType.PointD;
            datatableInt();
            DataRow r = _dt.NewRow();
            _dt.Rows.Add(r);
        }
        public LinkLayer (List<PointD> plst) {
            datatableInt();
            foreach (PointD p in plst) {
                _items.Add(p);
                DataRow r = _dt.NewRow();
                _dt.Rows.Add(r);
            }
            _type = iType.PointD;//注意pd和multipoint的区分
        }

        public LinkLayer(PointD[] pois) {
            datatableInt();
            foreach (PointD p in pois) {
                _items.Add(p);
                DataRow r = _dt.NewRow();
                _dt.Rows.Add(r);
            }
            _type = iType.MultiPoint; //or pointd;
        }
        public LinkLayer(Polyline pline) {
            _items.Add(pline);
            _type = iType.Polyline;
            datatableInt();
            DataRow r = _dt.NewRow();
            _dt.Rows.Add(r);
        }
        public LinkLayer(Polygon poly) {
            _items.Add(poly);
            _type = iType.Polygon;
            datatableInt();
            DataRow r = _dt.NewRow();
            _dt.Rows.Add(r);
        }
        public LinkLayer(MultiPolygon mpoly) {
            _items.Add(mpoly);
            _type = iType.MultiPolygon;
            datatableInt();
            DataRow r = _dt.NewRow();
            _dt.Rows.Add(r);
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
        public object getFeatureByIdx (int idx) {
            //不主要在这里验证 idx是否超出索引
            if (idx < _items.Count) {
                return _items[idx];
            }
            else {
                return _items[0];
            }
            
        }
        public void setFeatureByIdx (int idx,object fea) {
            //不主要在这里验证 idx是否超出索引
            if (idx < _items.Count) {
                _items[idx]=fea;
            }
            else {}

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
        public PointD[] GetPointRange () {
            List<PointD> plst = new List<PointD>();
            if (_type == iType.PointD) {
                foreach(PointD p in _items) {
                    plst.Add(p);
                }
                return plst.ToArray();
            }else if (_type == iType.MultiPoint) {
                
            }else if (_type == iType.Polyline) {
                foreach (Polyline pline in _items) {
                    int lc = pline.PointCount;
                    for (int i = 0; i < lc; i++) {
                        plst.Add(pline.GetPoint(i));
                    }
                }
                return plst.ToArray();
            }else if (_type == iType.Polygon) {
                foreach (Polygon poly in _items) {
                    int lc = poly.PointCount;
                    for (int i = 0; i < lc; i++) {
                        plst.Add(poly.GetPoint(i));
                    }
                }
                return plst.ToArray();
            }else if (_type == iType.MultiPolygon) {
                
            }else { }
            return plst.ToArray();
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

        #region 增删要素
        //注：这里不进行类型判断，在调用的时候尽量进行，不要出现点图层还加线要素的情况
        public void AddPointD (PointD pd) {
            _items.Add(pd);
            DataRow r = _dt.NewRow();
            _dt.Rows.Add(r);
        }
        public void AddPolyline (Polyline line) {
            _items.Add(line);
            DataRow r = _dt.NewRow();
            _dt.Rows.Add(r);
        }
        public void AddPolygon (Polygon poly) {
            _items.Add(poly);
            DataRow r = _dt.NewRow();
            _dt.Rows.Add(r);
        }


        public void addFeature (object obj) {
            _items.Add(obj);//尽量不用这一个
            DataRow r = _dt.NewRow();
            _dt.Rows.Add(r);
        }

        //可以增加就应该可以删除，删除其中的要素，在编辑和删除中用到
        /// <summary>
        /// 通过索引idx删除要素
        /// </summary>
        /// <param name="idx"></param>
        public void delFeaByIdx (int idx) {
            try {
                _items.RemoveAt(idx);
                _dt.Rows.RemoveAt(idx);
            }
            catch {}
        }
        public void insertFeature (int idx,object obj) {
            _items.Insert(idx, obj);
            try {
                DataRow r = _dt.NewRow();
                _dt.Rows.InsertAt(r,idx); 
            }
            catch { }
        }


        private void datatableInt () {//属性数据初始化；
            _dt.Columns.Add("name");//typeof(String)
            _dt.Columns.Add("decs");
        }
#endregion

    }
}
