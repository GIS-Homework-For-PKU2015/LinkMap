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

        private LinkMap wholeMap = new LinkMap();
        //整个mapControl 顶层元素应该是map，之后的操作是针对这个mao进行操作
        //不要单独对polygon操作，但是外包矩形可以有
        private int _curLayerIdx = 0;//当前图层索引 这个可能用不上，直接操作_curLayer
        private LinkLayer _curLayer; // = new LinkLayer();//当前图层
        
        private List<Polygon> _Polygon = new List<Polygon>();       //多边形集合
        private double _DisplayScale = 1D;       //显示比例尺倒数
        private List<Polygon> _SelectedPolygons = new List<Polygon>(); //选中多边形集合
        private List<string> _str;//?

        //内部变量
        private double mOffsetX = 0; double mOffsetY = 0;  //窗口左上角偏移量
        private int mMapOpStyle = 0;//当前操作类型，0无，1放大，2缩小 3漫游 4输入多边形 5选择
        private Polygon mTrackingPolygon = new Polygon();  //用户正在绘制的的多边形
        private PointF mMouseLocation = new Point();   //鼠标当前位置，用于漫游
        private PointF mStartPoint = new PointF();   //几率鼠标按下时的位置，用于拉框

        //鼠标光标对象定义
        //private Cursor mCur_Cross = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LinkMapObject.Resources.Cross.ico"));

        //private Cursor mCur_ZoomIn = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LinkMapObject.Resources.ZoomIn.ico"));

        //private Cursor mCur_ZoomOut = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LinkMapObject.Resources.ZoomOut.ico"));

        //private Cursor mCur_PangUp = new Cursor(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("LinkMapObject.Resources.PanUp.ico"));

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
        /// 获取或设置多边形数组
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
            return sPoint;
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
            //this.Cursor = mCur_ZoomIn;

        }

        /// <summary>
        /// 将地图操作设置为缩小状态
        /// </summary>
        public void ZoomOut()
        {
            mMapOpStyle = 2;
            //this.Cursor = mCur_ZoomOut;
        }

        /// <summary>
        /// 将地图操作设置为漫游状态
        /// </summary>
        public void Pan()
        {
            mMapOpStyle = 3;
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// 将地图操作设置为输入多边形状态
        /// </summary>
        public void TrackPolygon()
        {
            mMapOpStyle = 4;
            this.Cursor = Cursors.Cross;
        }

        /// <summary>
        /// 将地图操作设置为选择要素状态
        /// </summary>
        public void SelcetFeature()
        {
            mMapOpStyle = 5;
            this.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// 增加一个多边形
        /// </summary>
        public void AddPolygon(Polygon polygon)
        {
            _Polygon.Add(polygon);
        }

        /// <summary>
        /// 根据矩形盒进行选择，返回选中多边形集合
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public Polygon[] SelcetByBox(RectangleD box)
        {
            List<Polygon> sSels = new List<Polygon>();
            int sPolygonCount = _Polygon.Count;
            for (int i = 0; i < sPolygonCount; i++)
            {
                if (MapTools.IsPolygonCompleteWithinBox(_Polygon[i], box) == true)
                {
                    sSels.Add(_Polygon[i]);

                }
            }
            return sSels.ToArray();
        }
        #endregion
        public void AddLayer (LinkLayer alayer) {
            wholeMap.AddLayer(alayer);
        }




        #region 事件

        public delegate void TrackingFinishedHandle(object sender, Polygon polygon);            //delegate是什么？
        /// <summary>
        /// 用户输入多边形完毕
        /// </summary>
        public event TrackingFinishedHandle TrackingFinshed;

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




        #endregion


        #region 控件母版事件处理

        private void LinkMapControl_Paint(object sender, PaintEventArgs e)
        {
            //绘制所有多边形    另外，这里面自带了一个e作为绘图用的对象。
            DrawPolygons(e.Graphics);
            DrawSelectedPolygons(e.Graphics);
            DrawTrackingPolygon(e.Graphics);
            DrawMap(e.Graphics);
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
                    if (e.Button == MouseButtons.Left)
                    {
                        if (mTrackingPolygon.PointCount >= 3)  //顶点个数必须大于等于3
                        {
                            LinkMapObject.Polygon sTrackingPolygon = mTrackingPolygon.Clone();
                            mTrackingPolygon.Clear();
                            if (TrackingFinshed != null)
                            {
                              TrackingFinshed(this, sTrackingPolygon); //触发事件(问题出现在这里),换成mTrackingPolygon就可以填色，但是sTrackingPolygon不行
                            }
                        }
                    }
                    break;
                case 5:         //选择
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

            foreach (LinkLayer elay in wholeMap) {
                //默认顺序就是idx=0在最下面，加图层是加到后面
                switch (elay.mapType) {
                    case iType.PointD:
                        foreach (PointD pd in elay) {
                            PointD sScreenPoint = FromMapPoint(pd);    //用变量存储转换后的点
                            RectangleF rect = new RectangleF((float)pd.X, (float)pd.Y, 2f, 2f);
                            //目前写死了，之后做渲染的时候要改这里
                            g.FillEllipse(Brushes.Black, rect);
                        }
                        break;
                    case iType.MultiPoint:
                        break;
                    case iType.Polyline:
                        break;
                    case iType.Polygon:
                        foreach (Polygon pg in elay) {
                            int sPointCount = pg.PointCount;  //由于绘图必须要用vs自带的PointF，所以要进行转换。
                            PointF[] sScreenPoints = new PointF[sPointCount];   //新建点数组
                            for (int j = 0; j < sPointCount; j++) {
                                PointD sScreenPoint = FromMapPoint(pg.GetPoint(j));    //用变量存储转换后的点
                                sScreenPoints[j].X = (float)sScreenPoint.X;         //将转换后的点输入数组
                                sScreenPoints[j].Y = (float)sScreenPoint.Y;
                            }
                            //绘制多边形
                            g.DrawPolygon(sPolygonPen, sScreenPoints);
                            g.FillPolygon(sPolygonBrush, sScreenPoints);
                        }
                        break;
                    case iType.MultiPolygon:
                        break;
                    case iType.Null:
                        break;
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



        #endregion

        #region 对地图(Map)的处理



        /// <summary>
        /// 输出地图到bitmap
        /// </summary>
        public bool outMapToPng (string png_path,int w,int h) {
            //思路：把地图在bitmap上再画一遍； （注意要是全图），允许修改参数
            //string png_path = @"E:\ComputerGraphicsProj\outPng001.png";
            
            Image img = new Bitmap(w, h);
            Graphics gpng = Graphics.FromImage(img);
            DrawMap(gpng);
            DrawPolygons(gpng);
            img.Save(png_path);
            return true;
        }

#endregion

    }
}
