using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinkMapObject;

namespace LinkMap
{
    public partial class FrmMain : Form
    {


        public string LinkLayerName = "";

        #region 构造函数
        public FrmMain()
        {
            InitializeComponent();
        }

        private void LinkMapControl1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region 窗体和控件的事件处理
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatMap cm = new CreatMap();
            cm.ShowDialog();
        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "DataCenter GIS 工程文件(*.egis)|*.egis";
            //dlg.Multiselect = false;
            //dlg.SupportMultiDottedExtensions = true;
            //dlg.Title = "打开";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    //textBox1.Text = System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);
            //    Point a = new Point();
            //}

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "DataCenter GIS 工程文件(*.egis)|*.egis";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
            }


        }

        private void 导入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "位图文件(*.bmp)|*.bmp";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
            }
            */
            readWshapefile rwshp = new readWshapefile();
            rwshp.readShp();
            LinkMapControl1.AddLayer(rwshp.GetShpLayer);
            LinkLayerBox.Nodes.Add(rwshp.LayerName);//这个应该由LinkMapControl管理吧
        }

        private void 添加图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {//这部分的交互你去完善吧，需要图层名称类型，然后在mapcontrol的wholemap里加一个特定类型的图层
            GUI.AddLayer al = new GUI.AddLayer();
            al.ShowDialog();
            string LinkLayerName = al.LinkLayerName;
            string newLayType = al.layerType;
            LinkLayerBox.Nodes.Add(LinkLayerName);
        }

        private void 删除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 在选定位置添加点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPoint ap = new AddPoint();
            ap.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Identity ID = new Identity();
            ID.ShowDialog();
        }

        private void 依据属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search sch = new Search();
            sch.ShowDialog();
        }

        private void btnLinkZoomIn_Click(object sender, EventArgs e)
        {
            LinkMapControl1.ZoomIn();
        }

        private void btnLinkZoomOut_Click(object sender, EventArgs e)
        {
            LinkMapControl1.ZoomOut();
        }

        private void btnLinkPan_Click(object sender, EventArgs e)
        {
            LinkMapControl1.Pan();
        }


        #endregion

        #region 图层管理 
        //这部分 陈玄同 负责，包括treeview的刷新（在加新图层时，改变图层顺序后），图层顺序改变的方式，图层显隐的控制



        public void updateTreeView () {
            LinkLayerBox.Nodes.Clear();
            foreach (string ln in LinkMapControl1.layerNameLst()) {
                LinkLayerBox.Nodes.Add(ln);//按道理是先清空再重新add进去的
            }
            

        }

        #endregion

        #region 按钮事件
        private void btnLinkEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnLinkSelcet_Click(object sender, EventArgs e)
        {
            LinkMapControl1.SelcetFeature();
        }
        //画点
        private void btnLinkDrawPoints_Click (object sender, EventArgs e) {

        }
        //画线
        private void btnLinkDrawPolyline_Click (object sender, EventArgs e) {

        }
        //画多边形
        private void btnLinkDrawPolygon_Click (object sender, EventArgs e) {
            //当目前没有图层时，先生成新图层再画，已有图层，会是在现有图层上画
            LinkMapControl1.TrackPolygon();

        }
        //删除要素 
        //其交互逻辑是，选中了一个图形之后，点删除按钮，会弹出是否删除的msgbox

        private void btnLinkDelete_Click (object sender, EventArgs e) {

        }

        private void LinkMapControl1_TrackingFinshed(object sender, LinkMapObject.Polygon polygon)
        {
            LinkMapControl1.AddPolygon(polygon);
            LinkMapControl1.Refresh();
            updateTreeView();
        }

        private void LinkMapControl1_SelectingFinshed(object sender, LinkMapObject.RectangleD box)
        {
            LinkMapObject.Polygon[] sPolygons = LinkMapControl1.SelcetByBox(box);
            LinkMapControl1.SelectedVec = sPolygons;
            LinkMapControl1.Refresh();
        }

        private void LinkMapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            ShowCoordinates(e.Location);

        }

        private void ShowCoordinates(PointF mouseLocation)
        {
            LinkMapObject.PointD sMouseLocation = new LinkMapObject.PointD(mouseLocation.X, mouseLocation.Y);
            LinkMapObject.PointD sPointOnMap = LinkMapControl1.ToMapPoint(sMouseLocation);
            LinkPointLocation.Text = "X:" + sPointOnMap.X.ToString("0.00") + "   Y:" + sPointOnMap.Y.ToString("0.00");
        }


        private void 导出ToolStripMenuItem_Click (object sender, EventArgs e) {
            int mc_w = LinkMapControl1.Width;
            int mc_h = LinkMapControl1.Height;
            SaveFileDialog pngsavef = new SaveFileDialog();
            pngsavef.Filter = "png文件(*.png)|*.png";
            pngsavef.Title = "保存地图为bitmap";
            if (pngsavef.ShowDialog() == DialogResult.OK) {
                string spng_n = pngsavef.FileName;
                if (LinkMapControl1.outMapToPng(spng_n,mc_w, mc_h)) {
                    MessageBox.Show("保存成功!");
                }
            }
#endregion

        }


    }
}
