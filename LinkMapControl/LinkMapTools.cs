using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkMapObject
{
    internal static class MapTools  //将底图操作常用的算法放在这个类中，由于本身不带数据，所以设置为静态类（代表不能实例化，不能new）,同时也将其设置为其他程序集不能访问（只有MyMapObject能访问）。
    {
        /// <summary>
        /// 指示指定点是否位于指定矩形盒内
        /// </summary>
        /// <param name="point"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        internal static bool IsPointWithinBox(PointD point, RectangleD box)
        {
            if (point.X < box.MinX || point.X > box.MaxX)       //暴力查看是否在矩形内
                return false;
            else if (point.Y < box.MinY || point.Y > box.MaxY)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 指示一个多边形是否完全位于一个矩形内
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        internal static bool IsPolygonCompleteWithinBox(Polygon polygon, RectangleD box)
        {
            int sPointCount = polygon.PointCount;   //挨个点判定
            for (int i = 0; i < sPointCount; i++)
            {
                if (IsPointWithinBox(polygon.GetPoint(i), box) == false)
                    return false;
            }
            return true;
        }
    }
}
