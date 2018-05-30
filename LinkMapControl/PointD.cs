using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkMapObject
{
    public class PointD
    {
        #region 字段

        private double _X;
        private double _Y;

        #endregion


        #region 构造函数    （用来new）
        public PointD()
        { }

        public PointD(double x, double y)
        {
            _X = x;
            _Y = y;
        }
        #endregion

        #region  属性

        /// <summary>
        /// 获取或设置X坐标
        /// </summary>
        public double X     //访问属性
        {
            get { return _X; }
            set { _X = value; }
        }


        /// <summary>
        /// 获取或设置Y坐标
        /// </summary>
        public double Y     //访问属性
        {
            get { return _Y; }
            set { _Y = value; }
        }

        #endregion

    }
}
