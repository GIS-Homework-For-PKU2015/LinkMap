using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkMapObject
{
    public class LinkMap
    {
        #region 字段
        private List<LinkLayer> _items = new List<LinkLayer>();//图层内的数据
        private string _name;

        #endregion

        #region 构造函数
        public LinkMap()            //默认什么都没有
        { }

        public LinkMap(LinkLayer[] Map )     //输入函数,输入接口采取数组而不是list，为了让别的开发环境也能通用。
        {
            _items.AddRange(Map);
        }

        #endregion

        #region 属性

        //地图名称
        public string MapName
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

        //地图图层数目
        public int LayerNum
        {
            get
            {
                return _items.Count;
            }
        }

        #endregion

        #region 方法
        //改变可视状态的方法
        public void MapChangeSelectedLayerVisible(int sLayerIndex)
        {
            if(_items[sLayerIndex].IsVisble)
                _items[sLayerIndex].IsVisble = false;
            else
                _items[sLayerIndex].IsVisble = true;
        }

        //设置指定索引号index图层的显示样式style与显示颜色color
        //等待吉梁部分的样式和颜色类
        public void MapSetGeoStyle()
        {

        }

        //获取图层名称
        public string MapGetLayerName(int sLayerIndex)
        {
            return _items[sLayerIndex].Name;
        }

        //交换显示序号
        public void MapExchangeLayerIndex(int a,int b)
        {
            var temp = _items[a];
            _items[a] = _items[b];
            _items[b] = temp;
        }

        //public Tuple<int,int> MapIdentifyVector(PointD sPoint)
        //{
        //    for(int i=0;i<_items.Count;i++)
        //    {
        //        for(int j=0;j<_items[i].Count;j++)
        //        {
        //            if(sPoint==_items[i][j])
        //            {
        //                return <i,j >;
        //            }
        //        }
        //    }
        //    return<-1,-1>;
        //}

        public void MapAddLayer(string LayerName)
        {
            //_items.Add();
        }

        //删除特定索引号的图层
        public void MapRemoveLayer(int sindex)
        {
            _items.RemoveAt(sindex);
        }

        public iType MapGetDataProperties(int sindex)
        {
            return _items[sindex].mapType;
        }


        #endregion
    }
}
