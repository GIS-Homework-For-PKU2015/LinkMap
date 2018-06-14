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
        public string _mapFile = "";//工程文件egis保存路径
        #endregion



        #region 构造函数
        public FrmMain()
        {
            InitializeComponent();
        }

        private void LinkMapControl1_Load(object sender, EventArgs e)
        {
            this.Text = LinkMapControl1.GetMapName;
        }
        #endregion



        #region 菜单栏事件
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("新建工程会关闭目前工程，确认执行？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
                return;
            }
            CreatMap cm = new CreatMap();

            DialogResult dcm = cm.ShowDialog();
            if (dcm == DialogResult.OK) {
                string newName = cm.mapName;
                string disef = cm.Desc;
                _mapFile = cm.SavePath;
                this.Text = newName;
                int nc = LinkLayerBox.Nodes[0].Nodes.Count;
                if (nc > 0) {//删掉所有现有节点
                    for (int k = nc - 1; k >= 0; k--) {
                        LinkLayerBox.Nodes[0].Nodes[k].Remove();
                    }
                }
                LinkMapControl1.NewAmap(newName, disef);
                
            }
        }
        //**打开**按钮会执行的操作
        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LinkMapControl1.isWholeMapNotEmpty) {
                DialogResult drl = MessageBox.Show("当前项目里有图层，确认打开新项目文件么？（为防止数据丢失，建议保存egis文件再打开新文件）","tips",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (drl == DialogResult.Cancel) {
                    return;
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "LinkMap工程文件(*.egis)|*.egis";
            openFileDialog.Title = "打开工程文件";
            //openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                _mapFile = openFileDialog.FileName;
                LinkMapControl1.readEGISfile(_mapFile);
                this.Text = LinkMapControl1.GetMapName;
                int nc = LinkLayerBox.Nodes[0].Nodes.Count;
                if (nc > 0) {//删掉所有现有节点
                    for (int k = nc - 1; k >= 0; k--) {
                        LinkLayerBox.Nodes[0].Nodes[k].Remove();
                    }
                }
                foreach (string w in LinkMapControl1.getAllLayerName) {
                    LinkLayerBox.Nodes[0].Nodes.Insert(0, w);
                }

                LinkLayerBox.Nodes[0].ExpandAll();
                LinkMapControl1.Refresh();
            }
            
            

        }
        private void 保存ToolStripMenuItem_Click (object sender, EventArgs e) {
            if (_mapFile == "") {
                SaveFileDialog egisSave = new SaveFileDialog();
                egisSave.Filter = "LinkMap工程文件(*.egis)|*.egis";
                if (egisSave.ShowDialog() == DialogResult.OK) {
                    _mapFile = egisSave.FileName;
                    LinkMapControl1.outMapToEGIS(_mapFile);
                    MessageBox.Show("保存完毕！");
                }
            }
            else {
                LinkMapControl1.outMapToEGIS(_mapFile);
                MessageBox.Show("已保存！");
            }
            
        }
        //正版导入按钮
        private void 导入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            readWshapefile rwshp = new readWshapefile();
            rwshp.readShp();
            rwshp.readDbf();
            LinkMapControl1.AddLayer(rwshp.GetShpLayer);
            LinkLayerBox.Nodes[0].Nodes.Insert(0, rwshp.LayerName);//这个应该由LinkMapControl管理吧
            //int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[0].Checked = true;
            LinkLayerBox.Nodes[0].ExpandAll();
            LinkMapControl1.Refresh();
        }

        private void 添加图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.AddLayer al = new GUI.AddLayer();
            al.ShowDialog();
            string LinkLayerName = al.LinkLayerName;
            LinkMapControl1.AddLayer(LinkLayerName, al.type);
            LinkLayerBox.Nodes[0].Nodes.Insert(0, LinkLayerName);//这个应该由LinkMapControl管理吧
            //int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[0].Checked = true;
            LinkLayerBox.Nodes[0].ExpandAll();
            LinkMapControl1.Refresh();
        }

        private void 删除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LinkLayerBox.Nodes[0].GetNodeCount(false); i++)
            {
                if (LinkLayerBox.Nodes[0].Nodes[i].IsSelected == true)
                {
                    int a = LinkLayerBox.Nodes[0].GetNodeCount(false);
                    LinkLayerBox.Nodes[0].Nodes[i].Remove();
                    LinkMapControl1.RemoveLayer(a - i - 1);
                    LinkMapControl1.SortByTreeview(LinkLayerBox.Nodes[0]);
                    LinkMapControl1.Refresh();
                    return;
                }
            }
        }
        private void 查看属性表ToolStripMenuItem_Click (object sender, EventArgs e) {
            if (LinkMapControl1.mapLayerNum == 0) {
                MessageBox.Show("当前无图层!", "tips", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GUI.attributeForm attf = new GUI.attributeForm();
            //目前查看的是当前图层的属性表，想看选中图层的属性表之后再拓展，目前不写
            LinkMapObject.LinkLayer lay = LinkMapControl1.GetCurlayer();
            DataTable dat = lay.Table;
            if (dat.Rows.Count==0) {
                //dat.Columns.Add("AttZero", typeof(String));
                dat.Rows.Add("目前属性为空");
            }
            attf.SetDGVsource(dat);

            attf.Text = lay.Name;
            attf.Show();
        }

        private void 编辑属性表ToolStripMenuItem_Click (object sender, EventArgs e) {
            if (LinkMapControl1.mapLayerNum == 0) {
                MessageBox.Show("当前无图层","tips",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            GUI.editAttForm eAtt = new GUI.editAttForm();
            
            LinkMapObject.LinkLayer lay = LinkMapControl1.GetCurlayer();
            eAtt.eafDT = lay.Table;
            if (eAtt.ShowDialog() == DialogResult.Cancel) {
                DataTable dw = eAtt.eafDT;
                //LinkMapControl1.dtableToXelm(dw);
                LinkMapControl1.UpdateTable(dw);
            }
        }
        private void 在选定位置添加点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPoint ap = new AddPoint();
            DialogResult diaw= ap.ShowDialog();
            if (diaw == DialogResult.OK) {
                LinkMapControl1.AddPointToMap(ap.X, ap.Y);
            }
        }



        private void 依据属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search sch = new Search();
            sch.searchDT = LinkMapControl1.GetCurlayer().Table;
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Identity ID = new Identity();
            ID.Show();
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
            if (LinkMapControl1.SelectedFeaNum > 0) {
                if(MessageBox.Show("删除操作不可逆，确认要删除选中要素么？", "tips",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)
                    ==DialogResult.OK) {
                    LinkMapControl1.delSelectedFea();

                }
            }
            else {
                MessageBox.Show("目前无选中要素，要删除要素请先选中要素！","tips");
            }
            
        }
        #endregion



        #region LinMapControl控件触发的事件
        private void LinkMapControl1_TrackingPointFinshed(object sender, LinkMapObject.PointD points)
        {
            LinkMapObject.LinkLayer Curlayer = LinkMapControl1.GetCurlayer();
            LinkLayerBox.Nodes[0].Nodes.Insert(0, Curlayer.Name); //Add(Curlayer.Name);
            //int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[0].Checked = true;
            LinkLayerBox.Nodes[0].ExpandAll();
            LinkMapControl1.Refresh();
        }

        private void LinkMapControl1_TrackingPolylineFinshed(object sender, LinkMapObject.Polyline polyline)
        {
            LinkMapObject.LinkLayer Curlayer = LinkMapControl1.GetCurlayer();
            LinkLayerBox.Nodes[0].Nodes.Insert(0, Curlayer.Name);
            //int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[0].Checked = true;
            LinkLayerBox.Nodes[0].ExpandAll();
            LinkMapControl1.Refresh();
        }

        private void LinkMapControl1_TrackingFinshed(object sender, LinkMapObject.Polygon polygon)
        {
            //如果当前图层是多边形图层，该多边形写到当前图层里，否则写到新图层里

            LinkMapObject.LinkLayer Curlayer = LinkMapControl1.GetCurlayer();
            LinkLayerBox.Nodes[0].Nodes.Insert(0, Curlayer.Name);
            //int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[0].Checked = true;
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

        private void LinkMapControl1_GetTreeViewIndex(object sender, int a, int b)
        {
            TreeNode temp = LinkLayerBox.Nodes[0].Nodes[a];
            LinkLayerBox.Nodes[0].Nodes[a] = LinkLayerBox.Nodes[0].Nodes[b];
            LinkLayerBox.Nodes[0].Nodes[b] = temp;
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
            LinkMapControl1.SortByTreeview(LinkLayerBox.Nodes[0]);
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
                if(e.Node.Text!="LinkMap")
                {
                    LinkMapControl1.MapChangeSelectedLayerVisible(LinkMapControl1.GetLayerByName(e.Node.Text));
                    Refresh();
                }

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

        #region 右键菜单栏
        private void 查看属性表ToolStripMenuItem1_Click (object sender, EventArgs e) {
            if (LinkMapControl1.mapLayerNum == 0) {
                MessageBox.Show("当前无图层。", "tips", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GUI.attributeForm attf = new GUI.attributeForm();
            //目前查看的是当前图层的属性表，想看选中图层的属性表之后再拓展，目前不写
            LinkMapObject.LinkLayer lay = LinkMapControl1.GetCurlayer();
            DataTable dat = lay.Table;
            if (dat.Rows.Count == 0) {
                dat.Columns.Add("AttZero", typeof(String));
                dat.Rows.Add("目前属性为空");
            }
            attf.SetDGVsource(dat);

            attf.Text = lay.Name;
            attf.Show();
        }






        #endregion

        private void 增加图层ToolStripMenuItem_Click (object sender, EventArgs e) {
            GUI.AddLayer al = new GUI.AddLayer();
            al.ShowDialog();
            string LinkLayerName = al.LinkLayerName;
            LinkMapControl1.AddLayer(LinkLayerName, al.type);
            LinkLayerBox.Nodes[0].Nodes.Insert(0, LinkLayerName);//这个应该由LinkMapControl管理吧
            //int sLC = LinkLayerBox.Nodes[0].Nodes.Count;
            mjudgementcheckbox = 0;
            LinkLayerBox.Nodes[0].Nodes[0].Checked = true;
            LinkLayerBox.Nodes[0].ExpandAll();
            LinkMapControl1.Refresh();
        }

        private void 删除图层ToolStripMenuItem1_Click (object sender, EventArgs e) {
            for (int i = 0; i < LinkLayerBox.Nodes[0].GetNodeCount(false); i++) {
                if (LinkLayerBox.Nodes[0].Nodes[i].IsSelected == true) {
                    int a = LinkLayerBox.Nodes[0].GetNodeCount(false);
                    LinkLayerBox.Nodes[0].Nodes[i].Remove();
                    LinkMapControl1.RemoveLayer(a - i - 1);
                    LinkMapControl1.SortByTreeview(LinkLayerBox.Nodes[0]);
                    LinkMapControl1.Refresh();
                    return;
                }
            }
        }

        private void 重命名ToolStripMenuItem_Click (object sender, EventArgs e) {

        }

        private void 设置地图名称ToolStripMenuItem_Click (object sender, EventArgs e) {
            GUI.renameMapPrioj rename = new GUI.renameMapPrioj();
            rename.Rname = this.Text;
            DialogResult dir = rename.ShowDialog();
            if (dir == DialogResult.OK) {
                this.Text = rename.Rname;
                LinkMapControl1.MapNameSet = this.Text;
            }
        }
    }
}
