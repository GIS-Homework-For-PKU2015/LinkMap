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
        private string _name="";
        private string _descript = "";
        //图层顺序在LinkMap里控制
        #endregion

        #region 构造函数
        public LinkMap ()            //默认什么都没有
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

        public string MapDescription {
            get {
                return _descript;
            }
            set {
                _descript = value;
            }
        }
        /// <summary>
        /// 地图图层的数目，=Count 
        /// </summary>
        public int LayerNum
        {
            get
            {
                return _items.Count;
            }
        }
        //这一句很值得学习 不包含“GetEnumerator”的公共定义，因此 foreach 语句不能作用于“LinkMap
        public IEnumerator<LinkLayer> GetEnumerator () {
            return _items.GetEnumerator();
        }
        /// <summary>
        /// 获取当前图层，最上面的图层
        /// </summary>
        public LinkLayer GetCurLayer {
            get {
                return _items.Last();
            }
        }
        /// <summary>
        /// 更新当前图层
        /// </summary>
        /// <param name="lay"></param>
        public void RefreshCurLayer (LinkLayer lay) {
            _items.RemoveAt(_items.Count-1);
            _items.Add(lay);
        }


        /// <summary>
        /// 通过索引获取图层
        /// </summary>
        /// <param name="idx"></param>
        /// <returns>a LinkLayer</returns>
        public LinkLayer GetLayerByIndex (int idx) {
            return _items[idx];//不在这里进行idx是否超出的判断
        }




        #endregion

        #region 方法
        /// <summary>
        /// 加图层
        /// </summary>
        /// <param name="lay"></param>
        public void AddLayer (LinkLayer lay) {
            _items.Add(lay);
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
