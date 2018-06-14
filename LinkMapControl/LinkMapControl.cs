using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkMapObject
{
    public partial class LinkMapControl : UserControl
    {
        #region 字段
        //设计时属性变量
        private Color _FillColor = Color.Tomato;    //多边形填充色
        private Color _BoundaryColor = Color.Black; //多边形边界色
        private Color _TrackingColor = Color.DarkGreen; //
        private bool _SelfMouseWheel = true;    //接受鼠标滚轮事件时是否自动缩放  
        //运行时属性变量


        private LinkMap wholeMap = new LinkMap("默认工程");
        //整个mapControl 顶层元素应该是map，之后的操作是针对这个mao进行操作

        //不要单独对polygon操作，但是外包矩形可以有
        private int _curLayerIdx = 0;//当前图层索引 这个可能用不上，直接操作_curLayer
        private LinkLayer _curLayer; // = new LinkLayer();//当前图层
        private int _editNearPoi = 0;//0:不在编辑状态 1:鼠标属于按下的情况  2：有在编辑范围内的点 3：不在

        private List<Polygon> _Polygon = new List<Polygon>();       //多边形集合
        private double _DisplayScale = 1D;       //显示比例尺倒数
        private List<Polygon> _SelectedPolygons = new List<Polygon>(); //选中多边形集合
        private List<object> _SelectedFea = new List<object>();//选中的要素集合
        private iType _selectType = iType.Null;
        private List<string> _str;//?
        

        //内部变量
        private double mOffsetX = 0; double mOffsetY = 0;  //窗口左上角偏移量
        private int mMapOpStyle = 0;//当前操作类型，0无，1放大，2缩小 3漫游 4输入多边形 5选择 6 输入点 7输入多点 8输入线 9输入多线 10输入多多边形 11 删除选中要素 12 移动要素
        private Polygon mTrackingPolygon = new Polygon();  //用户正在绘制的的多边形
        private PointF mMouseLocation = new Point();   //鼠标当前位置，用于漫游
        private PointF mStartPoint = new PointF();   //几率鼠标按下时的位置，用于拉框
        private Polyline mTrackingLine = new Polyline();

        //鼠标光标对象定义
        private Cursor mCur_Cross = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LinkMapControl.Resources.Cross.ico"));

        private Cursor mCur_ZoomIn = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LinkMapControl.Resources.ZoomIn.ico"));

        private Cursor mCur_ZoomOut = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LinkMapControl.Resources.ZoomOut.ico"));

        private Cursor mCur_PangUp = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LinkMapControl.Resources.PanUp.ico"));

        //常量
        private const float mcBoundaryWidth = 1F;       //多边形边界宽度
        private const float mcTrackingWidth = 1F;       //描绘的多边形宽度
        private const float mcVetexHandleSize = 7F;     //跟踪多边形顶点手柄大小，单位像素
        private const float mcZoomRatio = 1.2F;         //缩放系统
        private Color mcSelcetingBosxColor = Color.DarkGreen;//选择框颜色
        private const float mcSelcetingBoxWidth = 2F;//选择多边形宽度
        private Color mcSelectingColor = Color.Cyan;//选择多边形颜色

        #endregion


        #region 构造函数
        public LinkMapControl()
        {
            InitializeComponent();
            this.MouseWheel += LinkMapControl_MouseWheel;           //创建一个新的mousewheel事件
        }
        #endregion


        #region 属性

        /// <summary>
        /// "获取或设置多边形填充色"
        /// </summary>
        [Browsable(true), Description("获取或设置多边形填充色")] //这个控件显示在右边的属性窗口中，用做开发的用户可看到
        public Color FillColor
        {
            get { return _FillColor; }
            set { _FillColor = value; }
        }

        /// <summary>
        /// "获取或设置多边形边框色"
        /// </summary>
        [Browsable(true), Description("获取或设置多边形边框色")] //这个控件显示在右边的属性窗口中，用做开发的用户可看到
        public Color BoundaryColor      //注意，这里面的Color只是Framwork里面的类，在其他的里面是不行的。
        {
            get { return _BoundaryColor; }
            set { _BoundaryColor = value; }
        }

        /// <summary>
        /// "获取或跟踪图形边框色"
        /// </summary>
        [Browsable(true), Description("获取或跟踪图形边框色")] //这个控件显示在右边的属性窗口中，用做开发的用户可看到
        public Color TrackingColor      //注意，这里面的Color只是Framwork里面的类，在其他的里面是不行的。
        {
            get { return _TrackingColor; }
            set { _TrackingColor = value; }
        }

        /// <summary>
        /// 获取或设置鼠标滑轮时间是是否自动缩放
        /// </summary>
        [Browsable(true), Description("获取或设置鼠标滑轮时间是是否自动缩放")]
        public bool SelfMouseWheel
        {
            get { return _SelfMouseWheel; }
            set { _SelfMouseWheel = value; }
        }
        /// <summary>
        /// 获取或设置多边形数组, 这个是在哪里调用的？
        /// </summary>
        [Browsable(false)]
        public Polygon[] Polygon
        {
            get { return _SelectedPolygons.ToArray(); }
            set
            {
                _Polygon.Clear();
                _Polygon.AddRange(value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]

        public Polygon[] SelectedPolygon
        {
            get { return _SelectedPolygons.ToArray(); }
            set
            {
                _SelectedPolygons.Clear();
                _SelectedPolygons.AddRange(value);
            }
        }
        //选中的要素，不止于多边形
        public List<object> SelectedFea {
            get {
                return _SelectedFea;
            }
            set {
                _SelectedFea.Clear();
                _SelectedFea = value;
            }
        }
        public iType SelectedFeaType {
            get {
                return _selectType;
            }
        }

        /// <summary>
        /// 获取或设置显示比例尺倒数
        /// </summary>
        /// 
        [Browsable(false)]
        public double DisplayScale
        {
            get { return _DisplayScale; }
            set { _DisplayScale = value; }
        }
        public string GetMapName {
            get {
                return wholeMap.MapName;
            }
        }
        public string[] getAllLayerName {
            get {
                return wholeMap.getAllLayerName;
            }
        }


        #endregion


        #region 方法


        //方法和私有函数都是定义函数，
        //区别在于私有函数是只能在本代码中使用，无法在类的外部调用
        //而方法是可以在类的外部调用的。


        /// <summary>
        /// 将地图坐标转换为屏幕坐标
        /// </summary>
        /// 

        public PointD FromMapPoint(PointD point)
        {
            PointD sPoint = new PointD();
            sPoint.X = (point.X - mOffsetX) / _DisplayScale;
            sPoint.Y = (point.Y - mOffsetY) / _DisplayScale;
            //sPoint.Y =this.Height- (point.Y - mOffsetY) / _DisplayScale;
            return sPoint;

        }

        /// <summary>
        /// 将屏幕坐标转换为地图坐标
        /// </summary>
        /// 

        public PointD ToMapPoint(PointD point)
        {
            PointD sPoint = new PointD();
            sPoint.X = point.X * _DisplayScale + mOffsetX;
            sPoint.Y = point.Y * _DisplayScale + mOffsetY;
            //sPoint.Y = (point.Y- this.Height) * _DisplayScale + mOffsetY;
            return sPoint;
        }

        /// <summary>
        /// 将map中layer的显示顺序改为treeview上的顺序
        /// </summary>
        /// 

        //这里的输入是Treevi里面的父Node—LinkMap
        public void SortByTreeview(TreeNode sNode)
        {
            TreeNode MyNode = sNode;
            LinkMap sclonemap = wholeMap;
            for(int i=0;i<wholeMap.LayerNum;i++)
            {
                foreach (TreeNode sTreeNode in sNode.Nodes)
                {
                    if(sTreeNode.Text==wholeMap.GetLayerByIndex(i).Name)
                    {
                        sclonemap.MapExchangeLayerIndex(wholeMap.LayerNum-i-1, sTreeNode.Index);
                    }
                }
            }
            wholeMap = sclonemap;
        }


        public void SortByWholeMap(TreeNode sNode)
        {
            TreeNode MyNode = sNode;
            for (int i = 0; i < wholeMap.LayerNum; i++)
            {
                
                foreach (TreeNode sTreeNode in sNode.Nodes)
                {
                    if (sTreeNode.Text == wholeMap.GetLayerByIndex(i).Name)
                    {
                        if (GetTreeViewIndex != null)
                        {
                            //进入frmMain的委托事件
                            GetTreeViewIndex(this, wholeMap.LayerNum - i - 1, sTreeNode.Index); 
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 获取当前图层,调用了wholeMap.GetCurLayer
        /// </summary>
        /// <returns></returns>
        public LinkLayer GetCurlayer()
        {
            return wholeMap.GetCurLayer;
        }
        public void UpdateTable (DataTable dw) {
            LinkLayer lw = wholeMap.GetCurLayer;
            lw.Table = dw;
            wholeMap.RefreshCurLayer(lw);
        }
        /// <summary>
        /// 以指定点为中心，以指定系数进行缩放
        /// </summary>
        /// <param name="center"></param>
        /// <param name="ratio"></param>
        public void ZoomByCenter(PointD center, double ratio)            //这里有问题
        {
            double sDisplayScale;
            sDisplayScale = _DisplayScale / ratio;
            double sOffsetX; double sOffsetY;
            sOffsetX = mOffsetX + (1 - 1 / ratio) * (center.X - mOffsetX);
            sOffsetY = mOffsetY + (1 - 1 / ratio) * (center.Y - mOffsetY);
            mOffsetX = sOffsetX;
            mOffsetY = sOffsetY;
            _DisplayScale = sDisplayScale;

            //触发事件              
            if (DispalyCsaleChanged != null)
            {
                DispalyCsaleChanged(this);
            }
        }


        /// <summary>
        /// 将地图操作设置为放大状态
        /// </summary>
        public void ZoomIn()
        {
            mMapOpStyle = 1;
            this.Cursor = mCur_ZoomIn;

        }
        public int mapLayerNum {
            get {
                return wholeMap.LayerNum;
            }
        }
        /// <summary>
        /// 将地图操作设置为缩小状态
        /// </summary>
        public void ZoomOut()
        {
            mMapOpStyle = 2;
            this.Cursor = mCur_ZoomOut;
        }

        /// <summary>
        /// 将地图操作设置为漫游状态
        /// </summary>
        public void Pan()
        {
            mMapOpStyle = 3;
            this.Cursor = mCur_PangUp;
        }

        /// <summary>
        /// 将地图操作设置为输入多边形状态
        /// </summary>
        public void TrackPolygon()
        {
            mMapOpStyle = 4;
            this.Cursor = mCur_Cross;
        }

        /// <summary>
        /// 将地图操作设置为选择要素状态
        /// </summary>
        public void SelcetFeature()
        {
            mMapOpStyle = 5;
            this.Cursor = Cursors.Arrow;
        }

        public void AddPoint () {
            mMapOpStyle = 6;
            this.Cursor = Cursors.Arrow;
        }
        public void AddMultiPoint () {
            mMapOpStyle = 7;
            this.Cursor = Cursors.Arrow;
        }
        public void AddPolyline () {
            mMapOpStyle = 8;
            this.Cursor = Cursors.Arrow;
        }
        public void AddMultiline() {
            mMapOpStyle = 9;
            this.Cursor = Cursors.Arrow;
        }
        public void AddMultiPolygon () {
            mMapOpStyle = 10;
            this.Cursor = Cursors.Arrow;
        }
        public void DeleteFeature () {
            mMapOpStyle = 11;
            this.Cursor = Cursors.Arrow;
        }
        public void MoveFeature () {
            mMapOpStyle = 12;
            _editNearPoi = 2;
        }

        /// <summary>
        /// 增加一个多边形
        /// </summary>
        //public void AddPolygon(Polygon polygon)
        //{
        //    //如果当前图层是多边形图层，该多边形写到当前图层里，否则写到新图层里
        //    if (wholeMap.LayerNum == 0) {
        //        LinkLayer nlay = new LinkLayer(polygon);
        //        nlay.Name = "drawPolygon";
        //        nlay.IsVisble = false;
        //        wholeMap.AddLayer(nlay);
        //        _curLayer = wholeMap.GetCurLayer;
        //    }
        //    else {
        //        _curLayer = wholeMap.GetCurLayer;
        //        if (_curLayer.mapType == iType.Polygon) {
        //            _curLayer.AddPolygon(polygon);
        //            wholeMap.RefreshCurLayer(_curLayer);
        //        }
        //        else {
        //            LinkLayer nlay = new LinkLayer(polygon);
        //            nlay.Name = "drawPolygon1";
        //            nlay.IsVisble = false;
        //            wholeMap.AddLayer(nlay);
        //            _curLayer = wholeMap.GetCurLayer;
        //        }
        //    }
        //    //_Polygon.Add(polygon);
        //}

        /// <summary>
        /// 根据矩形盒进行选择，返回选中要素集合
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public List<object> SelcetByBox(RectangleD box)
        {
            List<object> sSels = new List<object>();
            _curLayer = wholeMap.GetCurLayer;
            sSels.Clear();//之前选中的要清掉
            if (_curLayer.mapType == iType.PointD) {
                foreach(PointD poi in _curLayer) {
                    if (MapTools.IsPointWithinBox(poi, box)) {
                        sSels.Add(poi);
                    }
                }
                _selectType = iType.PointD;
            }else if (_curLayer.mapType == iType.MultiPoint) {

            }else if (_curLayer.mapType == iType.Polyline) {
                foreach (Polyline line in _curLayer) {
                    int lcount = line.PointCount;
                    int c = 0;
                    for (int i = 0; i < lcount; i++) {
                        if (MapTools.IsPointWithinBox(line.GetPoint(i), box) ) {
                            c++;
                        }
                        if (c == lcount) {//不是完备版，目前仅当点都在box内才选中
                            sSels.Add(line);
                        }
                    }
                }
                _selectType = iType.Polyline;
            }
            else if (_curLayer.mapType == iType.Polygon) {
                
                foreach (Polygon poly in _curLayer) {
                    if (MapTools.IsPolygonCompleteWithinBox(poly, box) == true) {
                        sSels.Add(poly);
                    }
                }
                _selectType = iType.Polygon;
            }
            else if (_curLayer.mapType == iType.MultiPolygon) {

            }
            
            
            return sSels;
        }

        //添加图层并且显示
        public void AddLayer(LinkLayer alayer)
        {
            wholeMap.AddLayer(alayer);
        }

        //从名称获取图层
        public int GetLayerByName(string name)
        {
            for (int i = 0; i < wholeMap.LayerNum; i++)
            {
                if (wholeMap.GetLayerByIndex(i).Name == name)
                {
                    return i;
                    break;
                }
            }
            //如果没有则返回一个新建的空图层
            return -1;
        }

        //改变图层可视化状态
        public void MapChangeSelectedLayerVisible(int sLayer)
        {
            if (wholeMap.GetLayerByIndex(sLayer).IsVisble)
                wholeMap.GetLayerByIndex(sLayer).IsVisble = false;
            else
                wholeMap.GetLayerByIndex(sLayer).IsVisble = true;
        }

        public void RemoveLayer(int index)
        {
            wholeMap.MapRemoveLayer(index);
        }

        public void AddLayer(string name,string type)
        {
            LinkLayer nlay = new LinkLayer();
            if(type=="Polygon")
            {
                nlay.mapType =iType.Polygon;
            }
            else if(type =="Polyline")
            {
                nlay.mapType = iType.Polyline;
            }
            else if (type == "PointD")
            {
                nlay.mapType = iType.PointD;
            }
            else
            {
                return;
            }
            nlay.Name = name;
            nlay.IsVisble = true;
            wholeMap.AddLayer(nlay);
            _curLayer = wholeMap.GetCurLayer;
        }
        #endregion


        #region 事件

        public delegate void TrackingFinishedHandle(object sender, Polygon polygon);            //delegate是什么？
        /// <summary>
        /// 用户输入多边形完毕
        /// </summary>
        public event TrackingFinishedHandle TrackingFinshed;

        public delegate void TrackingPolylineFinishedHandle(object sender, Polyline polyline);
        /// <summary>
        /// 用户输入线完毕
        /// </summary>
        public event TrackingPolylineFinishedHandle TrackingPolylineFinshed;

        public delegate void TrackingPointFinishedHandle(object sender, PointD points);
        /// <summary>
        /// 用户输入点完毕
        /// </summary>
        public event TrackingPointFinishedHandle TrackingPointFinshed;

        public delegate void DispalyScaleChangeHandle(object sender);
        /// <summary>
        /// 显示比例出发生了变化
        /// </summary>
        public event DispalyScaleChangeHandle DispalyCsaleChanged;

        public delegate void SelectingFinishedHandle(object sender, RectangleD box);
        /// <summary>
        /// 用户选择完毕
        /// </summary>
        public event SelectingFinishedHandle SelectingFinshed;

        public delegate void GetTreeViewIndexHandle(object sender, int a,int b);
        /// <summary>
        /// 用户刷新treeview事件
        /// </summary>
        public event GetTreeViewIndexHandle GetTreeViewIndex;




        #endregion


        #region 控件母版事件处理

        private void LinkMapControl_Paint(object sender, PaintEventArgs e)
        {
            //绘制所有多边形    另外，这里面自带了一个e作为绘图用的对象。
            //DrawPolygons(e.Graphics);
            //DrawSelectedPolygons(e.Graphics);
            //注意画的顺序，追踪要素应该是最上面的时间
            DrawMap(e.Graphics);
            DrawTrackingPolygon(e.Graphics);
            DrawTrackingPolyline(e.Graphics);
            DrawSelectedFeas(e.Graphics);

        }

        //鼠标按下事件
        private void LinkMapControl_MouseDown(object sender, MouseEventArgs e)  //sender判断触发事件的是谁。e是包含了与事件有关的参数。
        {
            switch (mMapOpStyle)
            {
                case 0:
                    break;
                case 1:          //放大
                    if (e.Button == MouseButtons.Left)
                    {
                        PointD sMouseLocation = new PointD(e.Location.X, e.Location.Y);
                        PointD sPoint = ToMapPoint(sMouseLocation);
                        ZoomByCenter(sPoint, mcZoomRatio);
                        Refresh();
                    }
                    break;
                case 2:          //缩小
                    if (e.Button == MouseButtons.Left)
                    {
                        PointD sMouseLocation = new PointD(e.Location.X, e.Location.Y);
                        PointD sPoint = ToMapPoint(sMouseLocation);
                        ZoomByCenter(sPoint, 1 / mcZoomRatio);
                        Refresh();
                    }
                    break;
                case 3:          //漫游
                    if (e.Button == MouseButtons.Left)
                    {
                        mMouseLocation.X = e.Location.X;
                        mMouseLocation.Y = e.Location.Y;
                    }
                    break;
                case 4:         //输入多边形
                    if (e.Button == MouseButtons.Left && e.Clicks == 1)
                    {
                        PointD sScreenPoint = new PointD(e.Location.X, e.Location.Y);
                        PointD sMapPoint = ToMapPoint(sScreenPoint);
                        mTrackingPolygon.AddPoint(sMapPoint);
                        Refresh();
                    }
                    break;
                case 5:         //选择
                    if (e.Button == MouseButtons.Left)
                    {
                        mStartPoint = e.Location;
                    }

                    break;
                case 6:         //add point
                    if (e.Button == MouseButtons.Left) {
                        //判断当前图层是否是点图层 no->提醒用户；yes，加一个点
                        //mStartPoint = e.Location;
                        PointD poiw = new PointD(e.Location.X, e.Location.Y);
                        PointD mpoiw = ToMapPoint(poiw);
                        if (wholeMap.LayerNum == 0) {
                            LinkLayer nlay = new LinkLayer(mpoiw);
                            nlay.Name = "Layer" + wholeMap.LayerNum.ToString();
                            nlay.IsVisble = true;
                            wholeMap.AddLayer(nlay);
                            _curLayer = wholeMap.GetCurLayer;
                            if (TrackingPointFinshed != null)
                            {//进入frmMain的委托事件
                                TrackingPointFinshed(this, mpoiw); //触发事件(问题出现在这里),换成mTrackingPolygon就可以填色，但是sTrackingPolygon不行
                            }
                        }
                        else {
                            _curLayer = wholeMap.GetCurLayer;
                            if (_curLayer.mapType == iType.PointD) {
                                _curLayer.AddPointD(mpoiw);
                                wholeMap.RefreshCurLayer(_curLayer);
                            }
                            else {
                                LinkLayer nlay = new LinkLayer(mpoiw);
                                nlay.Name = "Layer" + wholeMap.LayerNum.ToString();
                                nlay.IsVisble = true;
                                wholeMap.AddLayer(nlay);
                                _curLayer = wholeMap.GetCurLayer;
                                if (TrackingPointFinshed != null)
                                {//进入frmMain的委托事件
                                    TrackingPointFinshed(this, mpoiw); //触发事件(问题出现在这里),换成mTrackingPolygon就可以填色，但是sTrackingPolygon不行
                                }
                            }
                        }
                        Refresh();
                    }

                    break;
                case 7:         //add multipoint
                    if (e.Button == MouseButtons.Left) {
                        //判断当前图层是否是线图层 
                        mStartPoint = e.Location;
                    }

                    break;
                case 8:         //add line
                    if (e.Button == MouseButtons.Left && e.Clicks == 1) {
                        PointD sScreenPoint = new PointD(e.Location.X, e.Location.Y);
                        PointD sMapPoint = ToMapPoint(sScreenPoint);
                        mTrackingLine.AddPoint(sMapPoint);
                        Refresh();
                    }

                    break;
                case 9:         //add multiline
                    if (e.Button == MouseButtons.Left) {
                        //
                        //mStartPoint = e.Location;
                    }

                    break;
                case 10:         //add multipolygon
                    if (e.Button == MouseButtons.Left) {
                        //判断当前图层是否是点图层 no->提醒用户；yes，加一个点
                        //mStartPoint = e.Location;
                    }

                    break;
                case 11:         //删除要素
                    
                    break;
                case 12:         //编辑要素  移动要素
                    if (e.Button == MouseButtons.Left) {
                        _editNearPoi = 1;
                    }else if (e.Button == MouseButtons.Middle ) {//增加节点
                        //需要计算加点的位置应该加在哪个节点上，这部分逻辑还需要时间去写，作为暂存功能。
                        _curLayer = wholeMap.GetCurLayer;
                        switch (_curLayer.mapType) {
                            case iType.PointD:
                                
                                break;
                            case iType.MultiPoint:

                                break;
                            case iType.Polyline:
                                int lc = _curLayer.Count;
                                for (int i = 0; i < lc; i++) {
                                    Polyline line = (Polyline)_curLayer.getFeatureByIdx(i);
                                    PointD md = ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                                    for (int k = 0; k < line.PointCount; k++) {
                                        PointD ld = line.getLineByIdx(k);
                                        double thd = 40 * _DisplayScale;
                                        if (Math.Abs(md.X - ld.X) <thd && Math.Abs(md.Y - ld.Y) < thd) {
                                            line.insertPoint(k,md);
                                            _curLayer.setFeatureByIdx(i, line);
                                            wholeMap.RefreshCurLayer(_curLayer);
                                            this.Refresh();
                                            break;
                                        }

                                    }
                                }
                                break;
                            case iType.Polygon:
                                int pca = _curLayer.Count;
                                for (int i = 0; i < pca; i++) {
                                    Polygon line = (Polygon)_curLayer.getFeatureByIdx(i);
                                    PointD md = ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                                    for (int k = 0; k < line.PointCount; k++) {
                                        PointD ld = line.getPoiByIdx(k);
                                        double thd = 40 * _DisplayScale;
                                        if (Math.Abs(md.X - ld.X) < thd && Math.Abs(md.Y - ld.Y) < thd) {
                                            line.insertPoint(k, md);
                                            _curLayer.setFeatureByIdx(i, line);
                                            wholeMap.RefreshCurLayer(_curLayer);
                                            this.Refresh();
                                            break;
                                        }
                                    }
                                }
                                break;
                            case iType.MultiPolygon:

                                break;

                            }
                        }

                        break;
                case 13:         //编辑要素
                    
                    break;
            }


        }

        //鼠标移动
        private void LinkMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mMapOpStyle)
            {
                case 0:
                    break;
                case 1:          //放大
                    break;
                case 2:          //缩小
                    break;
                case 3:          //漫游
                    if (e.Button == MouseButtons.Left)
                    {
                        PointD sPreMouseLocation = new PointD(mMouseLocation.X, mMouseLocation.Y);
                        PointD sCurMouseLocation = new PointD(e.Location.X, e.Location.Y);
                        PointD sPreMapPoint = ToMapPoint(sPreMouseLocation);
                        PointD sCurMapPoint = ToMapPoint(sCurMouseLocation);
                        //修改offset
                        mOffsetX = mOffsetX + sPreMapPoint.X - sCurMapPoint.X;
                        mOffsetY = mOffsetY + sPreMapPoint.Y - sCurMapPoint.Y;
                        //刷新
                        Refresh();
                        mMouseLocation.X = e.Location.X;
                        mMouseLocation.Y = e.Location.Y;
                    }
                    break;
                case 4:         //输入多边形
                    mMouseLocation.X = e.Location.X;
                    mMouseLocation.Y = e.Location.Y;
                    Refresh();
                    break;
                case 5:         //选择
                    if (e.Button == MouseButtons.Left)
                    {
                        Refresh();//刷新
                        Graphics g = Graphics.FromHwnd(this.Handle);        //实现画矩形
                        Pen sBoxPen = new Pen(mcSelcetingBosxColor, mcSelcetingBoxWidth);
                        float sMinX = Math.Min(mStartPoint.X, e.Location.X);
                        float sMxaX = Math.Max(mStartPoint.X, e.Location.X);
                        float sMinY = Math.Min(mStartPoint.Y, e.Location.Y);
                        float sMxaY = Math.Max(mStartPoint.Y, e.Location.Y);
                        g.DrawRectangle(sBoxPen, sMinX, sMinY, sMxaX - sMinX, sMxaY - sMinY);
                        g.Dispose();
                    }
                    break;
                case 6:         //add point
                    
                    break;
                case 7:         //add multipoint
                    //等下一个点
                    break;
                case 8:         //add line
                    mMouseLocation.X = e.Location.X;
                    mMouseLocation.Y = e.Location.Y;
                    Refresh();
                    break;
                case 9:         //add multiline
                    
                    break;
                case 10:         //add multipolygon
                    
                    break;
                case 11:         //删除要素

                    break;
                case 12:         //编辑要素 目前只有移动要素
                    //判断要素类型，对当前点循环，如果距离在一定范围内，鼠标变化
                    _curLayer = wholeMap.GetCurLayer;
                    int kt = 0;
                    if (_editNearPoi == 1 && _curLayer.IsVisble) {//鼠标左键属于按下状态
                        //必须是可见的图层才能编辑
                        switch (_curLayer.mapType) {
                            case iType.PointD:
                                int curl = _curLayer.Count;
                                for (int k = 0; k < curl; k++) {
                                    PointD pd = (PointD)_curLayer.getFeatureByIdx(k);
                                    PointD md = ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                                    double thd = 20 * _DisplayScale;
                                    if (Math.Abs(md.X - pd.X) < thd && Math.Abs(md.Y - pd.Y) < thd) {
                                        this.Cursor = Cursors.SizeAll;
                                        kt += 1;
                                        if (kt == 1) {
                                            _curLayer.setFeatureByIdx(k, md);
                                            wholeMap.RefreshCurLayer(_curLayer);
                                        }
                                        this.Refresh();
                                        break;
                                    }else if (kt==0) {
                                        this.Cursor = Cursors.Arrow;
                                    }
                                }
                                break;
                            case iType.MultiPoint:

                                break;
                            case iType.Polyline:
                                int lc = _curLayer.Count;
                                for (int i = 0; i < lc; i++) {
                                    Polyline line = (Polyline)_curLayer.getFeatureByIdx(i);
                                    PointD md = ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                                    for (int k = 0; k < line.PointCount; k++) {
                                        PointD ld = line.getLineByIdx(k);
                                        double thd = 20 * _DisplayScale;
                                        if (Math.Abs(md.X - ld.X) < thd && Math.Abs(md.Y - ld.Y) < thd) {
                                            
                                            this.Cursor = Cursors.SizeAll;
                                            kt += 1;
                                            if (kt == 1) {
                                                line.setLPoiByIdx(k, md);
                                                _curLayer.setFeatureByIdx(i, line);
                                                wholeMap.RefreshCurLayer(_curLayer);
                                                this.Refresh();
                                            }
                                            
                                            break;
                                        }else if (kt==0) {
                                            this.Cursor = Cursors.Arrow;
                                        }

                                    }
                                }
                                break;
                            case iType.Polygon:
                                int pca = _curLayer.Count;
                                for (int i = 0; i < pca; i++) {
                                    Polygon line = (Polygon)_curLayer.getFeatureByIdx(i);
                                    PointD md =ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                                    for (int k = 0; k < line.PointCount; k++) {
                                        PointD ld = line.getPoiByIdx(k);
                                        double thd = 20 * _DisplayScale;
                                        if (Math.Abs(md.X - ld.X) < thd && Math.Abs(md.Y- ld.Y) < thd) {
                                            this.Cursor = Cursors.SizeAll;
                                            kt += 1;
                                            if (kt == 1) {
                                                line.setPoiByIdx(k, md);
                                                _curLayer.setFeatureByIdx(i, line);
                                                wholeMap.RefreshCurLayer(_curLayer);
                                                this.Refresh();
                                            }
                                            
                                            break;
                                        }else if (kt ==0) {
                                           this.Cursor = Cursors.Arrow;
                                        }

                                    }
                                }
                                break;
                            case iType.MultiPolygon:

                                break;


                        }

                    }else if (_editNearPoi == 2 && _curLayer.IsVisble) {//这里的目的是变符号形状
                        PointD[] plst = _curLayer.GetPointRange();
                        int pc = plst.Length;
                        mMouseLocation.X = e.Location.X;
                        mMouseLocation.Y = e.Location.Y;
                        for (int k = 0; k < pc; k++) {
                            PointD md = ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                            double thd = 20 * _DisplayScale;
                            if (Math.Abs(md.X - plst[k].X) < thd && Math.Abs(md.Y - plst[k].Y) < thd) {
                                this.Cursor = Cursors.SizeAll;
                                kt = 1;
                            }
                            else if (kt==0) {
                                this.Cursor = Cursors.Arrow;
                            }
                        }
                    }
                    
                    break;
            }
        }

        //鼠标松开
        private void LinkMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            switch (mMapOpStyle)
            {
                case 0:
                    break;
                case 1:          //放大
                    break;
                case 2:          //缩小
                    break;
                case 3:          //漫游
                    break;
                case 4:         //输入多边形
                    break;
                case 5:         //选择
                    if (e.Button == MouseButtons.Left)
                    {
                        double sMinX = Math.Min(mStartPoint.X, e.Location.X);
                        double sMaxX = Math.Max(mStartPoint.X, e.Location.X);
                        double sMinY = Math.Min(mStartPoint.Y, e.Location.Y);
                        double sMaxY = Math.Max(mStartPoint.Y, e.Location.Y);
                        PointD sTopLeft = new PointD(sMinX, sMinY);
                        PointD sBottomRight = new PointD(sMaxX, sMaxY);
                        PointD sTopLeftOnMap = ToMapPoint(sTopLeft);
                        PointD sBottomRightOnMap = ToMapPoint(sBottomRight);
                        RectangleD sSelBox = new RectangleD(sTopLeftOnMap.X, sBottomRightOnMap.X, sTopLeftOnMap.Y, sBottomRightOnMap.Y);
                        Refresh();
                        if (SelectingFinshed != null)
                            SelectingFinshed(this, sSelBox);

                    }
                    break;
                case 6:         //add point

                    break;
                case 7:         //add multipoint
                    //等下一个点
                    break;
                case 8:         //add line

                    break;
                case 9:         //add multiline

                    break;
                case 10:         //add multipolygon

                    break;
                case 11:         //删除要素

                    break;
                case 12:         //编辑要素  移动要素 当鼠标拿起来时，点定型了
                    _editNearPoi =2;
                    break;
                case 13:         //编辑要素

                    break;
            }
        }

        //鼠标双击
        private void LinkMapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (mMapOpStyle)
            {
                case 0:
                    break;
                case 1:          //放大
                    break;
                case 2:          //缩小
                    break;
                case 3:          //漫游
                    break;
                case 4:         //输入多边形
                    if (mTrackingPolygon.PointCount >= 3)  //顶点个数必须大于等于2
                    {
                        Polygon sTraPolygon = mTrackingPolygon.Clone();
                        //LinkMapObject.Polygon sTrackingPolygon = mTrackingPolygon.Clone();
                        //这一句不要手贱删LinkMapObject 否则容易出bug，我被坑过
                        mTrackingPolygon.Clear();
                        //mTrackingPolygon.Clear();
                        //如果当前图层是多边形图层，该多边形写到当前图层里，否则写到新图层里


                        if (wholeMap.LayerNum == 0)
                        {
                            LinkLayer nlay = new LinkLayer(sTraPolygon);
                            nlay.Name = "Layer"+wholeMap.LayerNum.ToString();
                            nlay.IsVisble = true;
                            wholeMap.AddLayer(nlay);
                            _curLayer = wholeMap.GetCurLayer;
                            if (TrackingFinshed != null)
                            {//进入frmMain的委托事件
                                TrackingFinshed(this, sTraPolygon); //触发事件(问题出现在这里),换成mTrackingPolygon就可以填色，但是sTrackingPolygon不行
                            }
                        }
                        else
                        {
                            _curLayer = wholeMap.GetCurLayer;
                            if (_curLayer.mapType == iType.Polygon)
                            {
                                _curLayer.AddPolygon(sTraPolygon);
                                wholeMap.RefreshCurLayer(_curLayer);
                            }
                            else
                            {
                                LinkLayer nlay = new LinkLayer(sTraPolygon);
                                nlay.Name = "Layer" + wholeMap.LayerNum.ToString();
                                nlay.IsVisble = true;
                                wholeMap.AddLayer(nlay);
                                _curLayer = wholeMap.GetCurLayer;
                                if (TrackingFinshed != null)
                                {//进入frmMain的委托事件
                                    TrackingFinshed(this, sTraPolygon); //触发事件(问题出现在这里),换成mTrackingPolygon就可以填色，但是sTrackingPolygon不行
                                }
                            }
                        }
                    }
                    break;
                case 5:         //选择
                    break;
                case 6:         //add point

                    break;
                case 7:         //add multipoint
                    //等下一个点
                    break;
                case 8:         //add line
                    if (mTrackingLine.PointCount >= 2)  //顶点个数必须大于等于2
                        {
                        Polyline sTraPolyline = mTrackingLine.Clone();
                        //LinkMapObject.Polygon sTrackingPolygon = mTrackingPolygon.Clone();
                        //这一句不要手贱删LinkMapObject 否则容易出bug，我被坑过
                        mTrackingLine.Clear();
                        //mTrackingPolygon.Clear();
                        //如果当前图层是多边形图层，该多边形写到当前图层里，否则写到新图层里

                        if (wholeMap.LayerNum == 0) {
                            LinkLayer nlay = new LinkLayer(sTraPolyline);
                            nlay.Name = "Layer" + wholeMap.LayerNum.ToString();
                            nlay.IsVisble = true;
                            wholeMap.AddLayer(nlay);
                            _curLayer = wholeMap.GetCurLayer;
                            if (TrackingPolylineFinshed != null)
                            {//进入frmMain的委托事件
                                TrackingPolylineFinshed(this, sTraPolyline); //触发事件(问题出现在这里),换成mTrackingPolygon就可以填色，但是sTrackingPolygon不行
                            }
                        }
                        else {
                            _curLayer = wholeMap.GetCurLayer;
                            if (_curLayer.mapType == iType.Polyline) {
                                _curLayer.AddPolyline(sTraPolyline);
                                wholeMap.RefreshCurLayer(_curLayer);
                            }
                            else {
                                LinkLayer nlay = new LinkLayer(sTraPolyline);
                                nlay.Name = "Layer" + wholeMap.LayerNum.ToString();
                                nlay.IsVisble = true;
                                wholeMap.AddLayer(nlay);
                                _curLayer = wholeMap.GetCurLayer;
                                if (TrackingPolylineFinshed != null)
                                {//进入frmMain的委托事件
                                    TrackingPolylineFinshed(this, sTraPolyline); //触发事件(问题出现在这里),换成mTrackingPolygon就可以填色，但是sTrackingPolygon不行
                                }
                            }
                        }

                    }
                    break;
                case 9:         //add multiline

                    break;
                case 10:         //add multipolygon

                    break;
                case 11:         //删除要素

                    break;
                case 12:         //移动要素 右键双击时是删除结点
                    if (e.Button == MouseButtons.Right) {//右键双击
                        _curLayer = wholeMap.GetCurLayer;
                        int kt = 0;
                        switch (_curLayer.mapType) {
                            case iType.PointD:
                                int curl = _curLayer.Count;
                                for (int k = 0; k < curl; k++) {
                                    PointD pd = (PointD)_curLayer.getFeatureByIdx(k);
                                    PointD md = ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                                    double thd = 20 * _DisplayScale;
                                    if (Math.Abs(md.X - pd.X) < thd && Math.Abs(md.Y - pd.Y) < thd) {
                                        //满足条件，删除节点
                                        _curLayer.delFeaByIdx(k);
                                        wholeMap.RefreshCurLayer(_curLayer);
                                        this.Refresh();
                                    }
                                    }
                                    break;
                                case iType.MultiPoint:

                                    break;
                                case iType.Polyline:
                                    int lc = _curLayer.Count;
                                    for (int i = 0; i < lc; i++) {
                                        Polyline line = (Polyline)_curLayer.getFeatureByIdx(i);
                                        PointD md = ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                                        for (int k = 0; k < line.PointCount; k++) {
                                            PointD ld = line.getLineByIdx(k);
                                        double thd = 20 * _DisplayScale;
                                        if (Math.Abs(md.X - ld.X) < thd && Math.Abs(md.Y - ld.Y) < thd) {
                                            if (line.PointCount < 3) {
                                                MessageBox.Show("顶点太少了，不能再删了！");
                                            }
                                            else {
                                                line.delPoiByIdx(k);
                                                _curLayer.setFeatureByIdx(i, line);
                                                wholeMap.RefreshCurLayer(_curLayer);
                                                this.Refresh();
                                            }
                                            }

                                        }
                                    }
                                    break;
                                case iType.Polygon:
                                    int pca = _curLayer.Count;
                                    for (int i = 0; i < pca; i++) {
                                        Polygon line = (Polygon)_curLayer.getFeatureByIdx(i);
                                        PointD md = ToMapPoint(new PointD(e.Location.X, e.Location.Y));
                                        for (int k = 0; k < line.PointCount; k++) {
                                            PointD ld = line.getPoiByIdx(k);
                                        double thd = 20 * _DisplayScale;
                                        if (Math.Abs(md.X - ld.X) < thd && Math.Abs(md.Y - ld.Y) < thd) {
                                            if (line.PointCount < 4) {
                                                MessageBox.Show("顶点太少，不能再删了！");
                                            }
                                            else {
                                                line.delPoiByIdx(k);
                                                _curLayer.setFeatureByIdx(i, line);
                                                wholeMap.RefreshCurLayer(_curLayer);
                                                this.Refresh();
                                            }
                                        }
                                            //else if (kt == 0) {
                                                //this.Cursor = Cursors.Arrow;
                                            //}

                                        }
                                    }
                                    break;
                                case iType.MultiPolygon:

                                    break;


                            

                        }
                    }
                    break;
            }
        }

        //鼠标滑轮事件
        private void LinkMapControl_MouseWheel(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (_SelfMouseWheel == true)
            {
                if (e.Delta > 0)      //如果前滚
                {
                    PointD sCenterPoint = new PointD(this.ClientSize.Width / 2, this.ClientSize.Height / 2);//屏幕坐标
                    PointD sCenterOnMap = ToMapPoint(sCenterPoint);
                    ZoomByCenter(sCenterOnMap, mcZoomRatio);
                    Refresh();
                }
                else
                {
                    PointD sCenterPoint = new PointD(this.ClientSize.Width / 2, this.ClientSize.Height / 2);//屏幕坐标
                    PointD sCenterOnMap = ToMapPoint(sCenterPoint);
                    ZoomByCenter(sCenterOnMap, 1 / mcZoomRatio);
                    Refresh();
                }
            }
        }





        #endregion


        #region 私有函数


        //重绘地图，按道理说这个把DrawPolygons DrawTrackingPolygon 等囊括了
        private void DrawMap (Graphics g) {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            List<int> aw = new List<int>();

            SolidBrush sPolygonBrush = new SolidBrush(_FillColor);
            Pen sPolygonPen = new Pen(_BoundaryColor, mcBoundaryWidth);

            foreach (LinkLayer elay in wholeMap)
            {
                if (elay.IsVisble)
                {
                    //默认顺序就是idx=0在最下面，加图层是加到后面
                    switch (elay.mapType)
                    {
                        case iType.PointD:
                            foreach (PointD pd in elay)
                            {
                                PointD sScPoi= FromMapPoint(pd);    //用变量存储转换后的点
                                RectangleF rect = new RectangleF((float)sScPoi.X, (float)sScPoi.Y, 2f, 2f);
                                //目前写死了，之后做渲染的时候要改这里
                                g.FillEllipse(Brushes.Black, rect);
                            }
                            break;
                        case iType.MultiPoint:
                            break;
                        case iType.Polyline:
                            foreach (Polyline pline in elay) {
                                Pen lPen = new Pen(_BoundaryColor, mcBoundaryWidth);
                                int lineCount = pline.PointCount;
                                PointF[] wpoi = new PointF[lineCount];
                                for (int i = 0; i < lineCount; i++) {

                                    PointD sScPoi= FromMapPoint(pline.GetPoint(i));    //用变量存储转换后的点
                                    wpoi[i] = new PointF((float) sScPoi.X, (float)sScPoi.Y);
                                }
                                g.DrawLines(lPen, wpoi);
                                lPen.Dispose();
                            }

                            break;
                        case iType.Polygon:
                            foreach (Polygon pg in elay)
                            {
                                Pen sPen = new Pen(_BoundaryColor, mcBoundaryWidth);
                                int sPointCount = pg.PointCount;  //由于绘图必须要用vs自带的PointF，所以要进行转换。
                                PointF[] sScreenPoints = new PointF[sPointCount];   //新建点数组
                                for (int j = 0; j < sPointCount; j++)
                                {
                                    PointD sScreenPoint = FromMapPoint(pg.GetPoint(j));    //将地图坐标转化为屏幕坐标
                                    sScreenPoints[j].X = (float)sScreenPoint.X;         //将转换后的点输入数组
                                    sScreenPoints[j].Y = (float)sScreenPoint.Y;
                                }
                                //绘制多边形
                                g.DrawPolygon(sPen, sScreenPoints);
                                g.FillPolygon(sPolygonBrush, sScreenPoints);
                                sPen.Dispose();
                            }
                            break;
                        case iType.MultiPolygon: //drawpath
                            break;
                        case iType.Null:
                            break;
                    }
                }
                
            }
        }
        private void DrawPolygons(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            int sPolygonCount = _Polygon.Count;//多边形数目
            SolidBrush sPolygonBrush = new SolidBrush(_FillColor);
            Pen sPolygonPen = new Pen(_BoundaryColor, mcBoundaryWidth);
            //循环绘制
            for (int i = 0; i < sPolygonCount; i++)
            {
                int sPointCount = _Polygon[i].PointCount;  //由于绘图必须要用vs自带的PointF，所以要进行转换。
                PointF[] sScreenPoints = new PointF[sPointCount];   //新建点数组
                for (int j = 0; j < sPointCount; j++)
                {
                    PointD sScreenPoint = FromMapPoint(_Polygon[i].GetPoint(j));    //用变量存储转换后的点
                    sScreenPoints[j].X = (float)sScreenPoint.X;         //将转换后的点输入数组
                    sScreenPoints[j].Y = (float)sScreenPoint.Y;
                }
                //绘制多边形
                g.DrawPolygon(sPolygonPen, sScreenPoints);          
                g.FillPolygon(sPolygonBrush, sScreenPoints);

            }
            sPolygonBrush.Dispose();                                //释放画笔资源
            sPolygonPen.Dispose();
        }

        private void DrawTrackingPolygon(Graphics g)
        {
            int sPointCount = mTrackingPolygon.PointCount; //获取跟踪多边形顶点数
            if (sPointCount == 0)
                return;
            //绘制多边形的所有边
            Pen sTrackingPen = new Pen(_TrackingColor, mcTrackingWidth);
            PointF[] sScreenPoints = new PointF[sPointCount];

            for (int i = 0; i < sPointCount; i++)
            {

                PointD sScreenPoint = FromMapPoint(mTrackingPolygon.GetPoint(i));
                sScreenPoints[i].X = (float)sScreenPoint.X;
                sScreenPoints[i].Y = (float)sScreenPoint.Y;
            }
            if (sPointCount > 1)
            {
                g.DrawLines(sTrackingPen, sScreenPoints);
            }
            //绘制多边形顶点手柄
            SolidBrush sVertexBrush = new SolidBrush(_TrackingColor);
            for (int i = 0; i < sPointCount; i++)
            {
                RectangleF sRect = new RectangleF(sScreenPoints[i].X -
                    mcVetexHandleSize / 2,
                    sScreenPoints[i].Y - mcVetexHandleSize / 2,
                    mcVetexHandleSize, mcVetexHandleSize);
                g.FillRectangle(sVertexBrush, sRect);
            }

            if (mMapOpStyle == 4)
            {
                g.DrawLine(sTrackingPen, sScreenPoints[0], mMouseLocation);
                g.DrawLine(sTrackingPen, sScreenPoints[sPointCount - 1], mMouseLocation);

            }
            sTrackingPen.Dispose();
            sVertexBrush.Dispose();
        }
        private void DrawTrackingPolyline (Graphics g) {
            int sPointCount = mTrackingLine.PointCount; //获取跟踪多边形顶点数
            if (sPointCount == 0)
                return;
            //绘制跟踪线的所有边
            Pen sTrackingPen = new Pen(_TrackingColor, mcTrackingWidth);
            PointF[] sScreenPoints = new PointF[sPointCount];

            for (int i = 0; i < sPointCount; i++) {

                PointD sScreenPoint = FromMapPoint(mTrackingLine.GetPoint(i));
                sScreenPoints[i].X = (float)sScreenPoint.X;
                sScreenPoints[i].Y = (float)sScreenPoint.Y;
            }
            if (sPointCount > 1) {
                g.DrawLines(sTrackingPen, sScreenPoints);
            }
            //绘制多边形顶点手柄
            SolidBrush sVertexBrush = new SolidBrush(_TrackingColor);
            for (int i = 0; i < sPointCount; i++) {
                RectangleF sRect = new RectangleF(sScreenPoints[i].X -
                    mcVetexHandleSize / 2,
                    sScreenPoints[i].Y - mcVetexHandleSize / 2,
                    mcVetexHandleSize, mcVetexHandleSize);
                g.FillRectangle(sVertexBrush, sRect);
            }

            if (mMapOpStyle == 8) {//橡皮筋效果
                //g.DrawLine(sTrackingPen, sScreenPoints[0], mMouseLocation);
                g.DrawLine(sTrackingPen, sScreenPoints[sPointCount - 1], mMouseLocation);

            }
            sTrackingPen.Dispose();
            sVertexBrush.Dispose();
        }

        private void DrawSelectedFeas (Graphics g) {
            int sPolygonCount = _SelectedFea.Count;
            Pen sPolygonPen = new Pen(mcSelectingColor, 2);
            if (_selectType == iType.Null) {

            }else if (_selectType == iType.PointD) {
                foreach(PointD p in _SelectedFea) {
                    PointD sScreenPoint = FromMapPoint(p);
                    DrawPoint(sScreenPoint, g, 3f,Brushes.Tomato);
                }
            }
            else if (_selectType == iType.MultiPoint) {

            }
            else if (_selectType == iType.Polyline) {
                foreach(Polyline p in _SelectedFea) {
                    int sPointCount = p.PointCount;
                    PointF[] sScreenPoints = new PointF[sPointCount];
                    for (int j = 0; j < sPointCount; j++) {
                        PointD sScreenPoint = FromMapPoint(p.Points[j]);
                        sScreenPoints[j].X = (float)sScreenPoint.X;
                        sScreenPoints[j].Y = (float)sScreenPoint.Y;

                    }
                    g.DrawLines(sPolygonPen, sScreenPoints);
                }
            }
            else if (_selectType == iType.Polygon) {
                foreach (Polygon p in _SelectedFea) {
                    int sPointCount = p.PointCount;
                    PointF[] sScreenPoints = new PointF[sPointCount];
                    for (int j = 0; j < sPointCount; j++) {
                        PointD sScreenPoint = FromMapPoint(p.Points[j]);
                        sScreenPoints[j].X = (float)sScreenPoint.X;
                        sScreenPoints[j].Y = (float)sScreenPoint.Y;

                    }
                    g.DrawPolygon(sPolygonPen, sScreenPoints);
                }
            }
            else if (_selectType == iType.MultiPolygon) {

            }
            
            
        }
        //不用了
        private void DrawSelectedPolygons(Graphics g)
        {
            int sPolygonCount = _SelectedPolygons.Count;
            Pen sPolygonPen = new Pen(mcSelectingColor, 2);
            for (int i = 0; i < sPolygonCount; i++)
            {
                int sPointCount = _SelectedPolygons[i].PointCount;
                PointF[] sScreenPoints = new PointF[sPointCount];
                for (int j = 0; j < sPointCount; j++)
                {
                    PointD sScreenPoint = FromMapPoint(_SelectedPolygons[i].Points[j]);
                    sScreenPoints[j].X = (float)sScreenPoint.X;
                    sScreenPoints[j].Y = (float)sScreenPoint.Y;

                }
                g.DrawPolygon(sPolygonPen, sScreenPoints);
            }
        }


        //把dat写入到一个msg，debug用
        public void dtableToXelm (DataTable dat) {
            string scol = "";
            //为了处理空值，还是用i；不用foreach
            int colc = dat.Columns.Count;
            for (int i = 0; i < colc; i++) {
                if (i == 0) {//当然列名不至于为空
                    scol = dat.Columns[i].ColumnName;
                }
                else {
                    scol = scol + " " + dat.Columns[i].ColumnName;
                }
            }
            scol = scol + "\n";
            foreach (DataRow dr in dat.Rows) {
                object[] wdk = dr.ItemArray;
                int wklen = wdk.Length;
                //string[] wdr = new string[wklen];
                if (wklen > 0) {
                    try {
                        for (int i = 0; i < wklen; i++) {
                            //wdr[i] = Convert.ToString(wdk[i]).Trim().Replace(' ', '_');
                            scol = scol + Convert.ToString(wdk[i]).Trim();
                        }
                    }
                    catch {}
                }
                scol += "\n";
            }
            MessageBox.Show(scol);
        }
        #endregion


        #region 对地图(Map)的处理

        public void DrawPoint (PointD p, Graphics g,float s,Brush b) {
            PointD sScPoi = FromMapPoint(p);    //用变量存储转换后的点
            RectangleF rect = new RectangleF((float)sScPoi.X, (float)sScPoi.Y, s, s);
            //目前写死了，之后做渲染的时候要改这里
            g.FillEllipse(b, rect);
        }

        /// <summary>
        /// 输出地图到bitmap
        /// </summary>
        public void outMapToPng (string png_path, int w,int h) {
            //思路：把地图在bitmap上再画一遍； （注意要是全图），允许修改参数
            //string png_path = @"E:\ComputerGraphicsProj\outPng001.png";
            
            Image img = new Bitmap(w, h);
            Graphics gpng = Graphics.FromImage(img);
            gpng.Clear(Color.White);//白色背景，如果需要透明背景就把这句注释掉
            DrawPolygons(gpng);
            DrawMap(gpng);

            img.Save(png_path);
        }

        /// <summary>
        /// 导出所有图层和属性数据到地图文件中
        /// </summary>
        public void outMapToEGIS (string egis) {
            rwToExportMap rEm = new rwToExportMap();
            rEm.SaveEGIS(egis,wholeMap);
            
        }
        /// <summary>
        /// 读取egis文件变成一个wholeMap
        /// </summary>
        /// <param name="egis"></param>
        public void readEGISfile (string egis) {
            rwToExportMap rEm = new rwToExportMap(egis);
            wholeMap=rEm.getMap();
            //this.Refresh();
        }
        /// <summary>
        /// 判断目前wholeMap是否为空
        /// </summary>
        public bool isWholeMapNotEmpty {
            get {
                if (wholeMap.LayerNum == 0) {
                    return false;//is empty
                }
                else {
                    return true;
                }
            }
        }


        #endregion


    }
}
