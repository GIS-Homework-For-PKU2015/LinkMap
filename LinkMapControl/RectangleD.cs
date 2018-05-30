using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkMapObject
{
    public class RectangleD
    {
        #region 字段

        private double _MinX, _MaxX, _MinY, _MaxY;  //矩形坐标参数

        #endregion

        #region 构造函数
        public RectangleD(double MinX, double MaxX, double MinY, double MaxY)
        {

            if (MinX > MaxX || MinY > MaxY)
            {
                throw new Exception("Invalid rectangle!");
            }
            _MinX = MinX;
            _MaxX = MaxX;
            _MinY = MinY;
            _MaxY = MaxY;


        }

        #endregion

        #region   接口
        //设置为只读，不能更改

        /// <summary>           
        /// 获取最小X坐标
        /// </summary>
        public double MinX
        {
            get { return _MinX; }
        }


        /// <summary>
        /// 获取最大X坐标
        /// </summary>
        public double MaxX
        {
            get { return _MaxX; }
        }

        /// <summary>
        /// 获取最小Y坐标
        /// </summary>
        public double MinY
        {
            get { return _MinY; }
        }

        /// <summary>
        /// 获取最大Y坐标
        /// </summary>
        public double MaxY
        {
            get { return _MaxY; }
        }

        /// <summary>
        /// 获取矩形的宽度
        /// </summary>
        public double Width
        {
            get { return _MaxX - _MinX; }
        }

        /// <summary>
        /// 获取矩形的高度
        /// </summary>
        public double Height
        {
            get { return _MaxY - _MinY; }
        }

        #endregion
    }
}
