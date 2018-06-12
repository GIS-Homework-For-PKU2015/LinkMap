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
        #region 字段
        public int mjudgementcheckbox = 1;
        public string LinkLayerName = "";
        #endregion



        #region 构造函数
        public FrmMain()
        {
            InitializeComponent();
        }

        private void LinkMapControl1_Load(object sender, EventArgs e)
        {

        }
        #endregion



        #region 菜单栏事件
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
            LinkLayerBox.Nodes[0].Nodes.Add(rwshp.LayerName);//这个应该由LinkMapControl管理吧
            int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[sLC - 1].Checked = true;
            LinkLayerBox.Nodes[0].ExpandAll();
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

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog pngSave = new SaveFileDialog();
            pngSave.Filter = "png文件(*.png)|*.png";
            if (pngSave.ShowDialog() == DialogResult.OK)
            {
                int mc_w = LinkMapControl1.Width;
                int mc_h = LinkMapControl1.Height;
                LinkMapControl1.outMapToPng(pngSave.FileName, mc_w, mc_h);
                MessageBox.Show("保存完毕！");
            }
        }
        #endregion



        #region 工具栏事件


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



        private void btnLinkSelcet_Click(object sender, EventArgs e)
        {
            LinkMapControl1.SelcetFeature();
        }

        //编辑
        private void btnLinkEdit_Click(object sender, EventArgs e)
        {
            LinkMapControl1.MoveFeature();
        }
        //画点
        private void btnLinkDrawPoints_Click(object sender, EventArgs e)
        {
            LinkMapControl1.AddPoint();
        }
        //画线
        private void btnLinkDrawPolyline_Click(object sender, EventArgs e)
        {
            LinkMapControl1.AddPolyline();
        }
        //画多边形
        private void btnLinkDrawPolygon_Click(object sender, EventArgs e)
        {
            LinkMapControl1.TrackPolygon();

        }

        //删除要素
        private void btnLinkDelete_Click(object sender, EventArgs e)
        {

        }
        #endregion



        #region LinMapControl控件触发的事件
        private void LinkMapControl1_TrackingPointFinshed(object sender, LinkMapObject.PointD points)
        {
            LinkMapObject.LinkLayer Curlayer = LinkMapControl1.GetCurlayer();
            LinkLayerBox.Nodes[0].Nodes.Add(Curlayer.Name);
            int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[sLC - 1].Checked = true;
            LinkLayerBox.Nodes[0].ExpandAll();
            LinkMapControl1.Refresh();
        }

        private void LinkMapControl1_TrackingPolylineFinshed(object sender, LinkMapObject.Polyline polyline)
        {
            LinkMapObject.LinkLayer Curlayer = LinkMapControl1.GetCurlayer();
            LinkLayerBox.Nodes[0].Nodes.Add(Curlayer.Name);
            int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[sLC - 1].Checked = true;
            LinkLayerBox.Nodes[0].ExpandAll();
            LinkMapControl1.Refresh();
        }

        private void LinkMapControl1_TrackingFinshed(object sender, LinkMapObject.Polygon polygon)
        {
            //如果当前图层是多边形图层，该多边形写到当前图层里，否则写到新图层里

            LinkMapObject.LinkLayer Curlayer = LinkMapControl1.GetCurlayer();
            LinkLayerBox.Nodes[0].Nodes.Add(Curlayer.Name);
            int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[sLC - 1].Checked = true;
            LinkLayerBox.Nodes[0].ExpandAll();
            LinkMapControl1.Refresh();
        }

        private void LinkMapControl1_SelectingFinshed(object sender, LinkMapObject.RectangleD box)
        {
            //不限制于选多边形；判断是什么要素，然后加到选择列表里

            LinkMapControl1.SelectedFea = LinkMapControl1.SelcetByBox(box); ;
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
            double Yreal = 0 - sPointOnMap.Y;
            LinkPointLocation.Text = "X:" + sPointOnMap.X.ToString("0.00") + "   Y:" + Yreal.ToString("0.00");
        }

        private void LinkMapControl1_DispalyCsaleChanged(object sender)
        {
            tss2.Text = "1:" + LinkMapControl1.DisplayScale.ToString("0.00");
        }

        #endregion



        #region 图层管理界面事件
        private void LinkLayerBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void LinkLayerBox_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        //编辑
        //private void btnLinkEdit_Click (object sender, EventArgs e) {
            //LinkMapControl1.MoveFeature();
            //}


        private void LinkLayerBox_DragOver(object sender, DragEventArgs e)
        {
            //处理 treeView1控件DragOver事件
            //修改鼠标进入节点的背景色，还原上一个节点的背景色
            //TreeView MyTreeView = (TreeView)sender;
            //TreeNode MyNode = MyTreeView.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));
            //if ((MyNode != null) && (MyNode != MyOldNode))
            //{
            //    MyOldNode.BackColor = Color.White;
            //    MyNode.BackColor = Color.Blue;
            //    MyOldNode = MyNode;
            //}

        }

        private void LinkLayerBox_DragDrop(object sender, DragEventArgs e)
        {
            //处理 treeView1控件DragDrop事件 
            TreeNode MyNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            TreeView MyTreeView = (TreeView)sender;
            //得到当前鼠标进入的节点
            TreeNode MyTargetNode = MyTreeView.GetNodeAt(LinkLayerBox.PointToClient(new Point(e.X, e.Y)));
            if (MyTargetNode != null)
            {
                TreeNode MyTargetParent = MyTargetNode.Parent;
                //删除拖放的节点
                //添加到目标节点
                if (MyTargetNode.Parent != null)
                {
                    MyNode.Remove();
                    MyTargetNode.Parent.Nodes.Insert(MyTargetNode.Index, MyNode);
                    MyTargetNode.BackColor = Color.White;
                    MyTreeView.SelectedNode = MyTargetNode;
                }


            }
            //把节点索引和图层索引统一，然后刷新重绘

            Refresh();
        }

        private void LinkLayerBox_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (mjudgementcheckbox == 0)
            {
                mjudgementcheckbox = 1;
            }
            else
            {
                LinkMapControl1.MapChangeSelectedLayerVisible(LinkMapControl1.GetLayerByName(e.Node.Text));
                Refresh();
            }
        }
        #endregion



        #region 自建函数
        //更新树节点
        private void UpdateTreeView() {
            //
            //string[] treeStr =;

        }
        #endregion










    }
}
