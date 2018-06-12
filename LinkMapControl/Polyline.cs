using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkMapObject {  //LinkMapControl
    public class Polyline {

        #region 字段
        private List<PointD> _Points = new List<PointD>();

        #endregion
        #region 构造函数
        public Polyline () { }

        public Polyline (PointD[] pois) {
            _Points.AddRange(pois);
        }
        public Polyline (List<PointD> points) {
            _Points = points;
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
            get { return _Points.Count; }
        }
        public PointD getLineByIdx (int idx) {
            return _Points[idx];
        }
        public void setLPoiByIdx (int idx, PointD p) {
            _Points[idx] = p;
        }
        public void delPoiByIdx (int idx) {
            _Points.RemoveAt(idx);
        }
        public void insertPoint (int idx, PointD p) {
            _Points.Insert(idx, p);
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
        /// 复制一条线
        /// </summary>
        /// <returns>A Clone Polyline</returns>
        public Polyline Clone () {
            Polyline sline = new Polyline();
            foreach (PointD p in _Points) {
                sline.AddPoint(p);
            }
            return sline;
        }

        #endregion


    }
}
