using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkMapObject
{
    public class Polygon
    {
        # region 字段
        private List<PointD> _Points = new List<PointD>();

        #endregion


        #region 
        public Polygon()            //默认什么都没有
        { }

        public Polygon(PointD[] points)     //输入函数,输入接口采取数组而不是list，为了让别的开发环境也能通用。
        {
            _Points.AddRange(points);
        }
        #endregion


        #region 属性  一般都是名词

        /// <summary>
        /// 获取顶点集合
        /// </summary>

        public PointD[] Points
        {
            get { return _Points.ToArray(); }
            set
            {
                _Points.Clear();        //清除数组
                _Points.AddRange(value);    //输入数组
            }
        }
        /// <summary>
        /// 获取点数目
        /// </summary>
        public int PointCount
        {
            get { return _Points.Count; }           //只读属性，不能修改，所以不加set
        }
        #endregion  


        #region 方法   命名方式一般会加一个动词
        /// <summary>
        /// 获取指定索引号的顶点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PointD GetPoint(int index)
        {
            return _Points[index];
        }
        /// <summary>
        /// 增加点
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(PointD point)
        {
            _Points.Add(point);
        }
        /// <summary>
        /// 清除点
        /// </summary>
        public void Clear()
        {
            _Points.Clear();
        }


        /// <summary>
        /// 复制一个副本
        /// </summary>
        /// <returns></returns>
        public Polygon Clone()
        {
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
