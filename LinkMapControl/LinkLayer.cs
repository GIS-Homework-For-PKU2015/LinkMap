using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//图层类
namespace LinkMapObject
{
    public class LinkLayer
    {
        #region 字段
        private List<object> _items = new List<object>();//图层内的数据(但是这歌object是不是有问题)
        private bool _isVisble = true; //图层可见性
        private iType _type = iType.PointD;//图层中数据类型 枚举
        private string _name;
        #endregion

        #region 构造函数
        public LinkLayer() {

        }
        public LinkLayer(PointD poi) {
            _items.Add(poi);
        }
        public LinkLayer(PointD[] pois) {
            foreach(PointD p in pois) {
                _items.Add(p);
            }
        }
        public LinkLayer(Polyline pline) {
            _items.Add(pline);
        }
        public LinkLayer(Polygon poly) {
            _items.Add(poly);
        }
        public LinkLayer(MultiPolygon mpoly) {
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



    }
}
