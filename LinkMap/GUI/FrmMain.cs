using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            int sLC = LinkLayerBox.Nodes.Count;
            LinkLayerBox.Nodes[sLC-1].Checked = true;
            LinkMapControl1.Refresh();
        }

        private void 添加图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.AddLayer al = new GUI.AddLayer();
            al.ShowDialog();
            string LinkLayerName = al.LinkLayerName;
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

        private void btnLinkEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnLinkSelcet_Click(object sender, EventArgs e)
        {
            LinkMapControl1.SelcetFeature();
        }

        private void LinkMapControl1_TrackingFinshed(object sender, LinkMapObject.Polygon polygon)
        {
            LinkMapControl1.AddPolygon(polygon);
            LinkMapControl1.Refresh();
        }

        private void LinkMapControl1_SelectingFinshed(object sender, LinkMapObject.RectangleD box)
        {
            LinkMapObject.Polygon[] sPolygons = LinkMapControl1.SelcetByBox(box);
            LinkMapControl1.SelectedPolygon = sPolygons;
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

        private void btnLinkDrawPolygon_Click(object sender, EventArgs e)
        {
            LinkMapControl1.TrackPolygon();

        }


        private void LinkLayerBox_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void LinkLayerBox_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            LinkMapControl1.MapChangeSelectedLayerVisible(LinkMapControl1.GetLayerByName(e.Node.Text));
            Refresh();
        }

        private void LinkLayerBox_AfterCheck (object sender, TreeViewEventArgs e) {

        }
        private void 导出ToolStripMenuItem_Click (object sender, EventArgs e) {


        }
    }
}
