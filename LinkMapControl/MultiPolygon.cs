
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//目前这个类还不是特别完善
namespace LinkMapObject {
    public class MultiPolygon {
        #region 字段
        private List<PointD> _Points = new List<PointD>();
        private List<Polygon> _innerPoly = new List<Polygon>();
        private List<Polygon> _outerPoly = new List<Polygon>();

        #endregion
        #region 构造函数
        public MultiPolygon () {

        }

#endregion

        #region 属性

        /// <summary>
        /// 获取顶点集合
        /// </summary>

        public PointD[] Points {
            get {
                return _Points.ToArray();
            }
            set {
                _Points.Clear();        //清除数组
                _Points.AddRange(value);    //输入数组
            }
        }
        /// <summary>
        /// 获取点数目
        /// </summary>
        public int PointCount {
            get {
                return _Points.Count;
            }           //只读属性，不能修改，所以不加set
        }
        #endregion  


        #region 方法
        /// <summary>
        /// 获取指定索引号的顶点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PointD GetPoint (int index) {
            return _Points[index];
        }
        /// <summary>
        /// 增加点
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint (PointD point) {
            _Points.Add(point);
        }
        /// <summary>
        /// 清除点
        /// </summary>
        public void Clear () {
            _Points.Clear();
        }


        /// <summary>
        /// 复制一个副本
        /// </summary>
        /// <returns></returns>
        public Polygon Clone () {
            Polygon sPolygon = new Polygon();   //新建一个多边形对象,s开头表示域内
            int sPointCount = _Points.Count();
            for (int i = 0; i < sPointCount; ++i)   //复制所有顶点
            {
                PointD sPoint = new PointD(_Points[i].X, _Points[i].Y);
                sPolygon.AddPoint(sPoint);
            }
            return sPolygon;
        }
        #endregion



    }
}
