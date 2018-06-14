namespace LinkMap
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("LinkMap");
            this.Linkmenu = new System.Windows.Forms.MenuStrip();
            this.LinkFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重设地图名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LinkEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在选定位置添加点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LinkLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LinkSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.依据属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.依据几何查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加注记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.简单符号法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.唯一值符号法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScripLink = new System.Windows.Forms.ToolStrip();
            this.btnLinkZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnLinkZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnLinkPan = new System.Windows.Forms.ToolStripButton();
            this.btnLinkSelcet = new System.Windows.Forms.ToolStripButton();
            this.btnLinkEdit = new System.Windows.Forms.ToolStripButton();
            this.btnLinkDrawPoints = new System.Windows.Forms.ToolStripButton();
            this.btnLinkDrawPolyline = new System.Windows.Forms.ToolStripButton();
            this.btnLinkDrawPolygon = new System.Windows.Forms.ToolStripButton();
            this.btnLinkDelete = new System.Windows.Forms.ToolStripButton();
            this.LinkLayerBox = new System.Windows.Forms.TreeView();
            this.LinkPointLocation = new System.Windows.Forms.Label();
            this.tss2 = new System.Windows.Forms.Label();
            this.cmstripLayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看属性表ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.增加图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除图层ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LinkMapControl1 = new LinkMapObject.LinkMapControl();
            this.Linkmenu.SuspendLayout();
            this.ScripLink.SuspendLayout();
            this.cmstripLayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Linkmenu
            // 
            this.Linkmenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Linkmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LinkFileToolStripMenuItem,
            this.LinkEditToolStripMenuItem,
            this.LinkLayerToolStripMenuItem,
            this.LinkSearchToolStripMenuItem,
            this.注记ToolStripMenuItem});
            this.Linkmenu.Location = new System.Drawing.Point(0, 0);
            this.Linkmenu.Name = "Linkmenu";
            this.Linkmenu.Size = new System.Drawing.Size(1250, 39);
            this.Linkmenu.TabIndex = 0;
            this.Linkmenu.Text = "menuStrip1";
            // 
            // LinkFileToolStripMenuItem
            // 
            this.LinkFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.导入ToolStripMenuItem,
            this.导入ToolStripMenuItem1,
            this.保存ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.重设地图名称ToolStripMenuItem});
            this.LinkFileToolStripMenuItem.Name = "LinkFileToolStripMenuItem";
            this.LinkFileToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.LinkFileToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.导入ToolStripMenuItem.Text = "打开";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导入ToolStripMenuItem1
            // 
            this.导入ToolStripMenuItem1.Name = "导入ToolStripMenuItem1";
            this.导入ToolStripMenuItem1.Size = new System.Drawing.Size(256, 38);
            this.导入ToolStripMenuItem1.Text = "导入";
            this.导入ToolStripMenuItem1.Click += new System.EventHandler(this.导入ToolStripMenuItem1_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // 重设地图名称ToolStripMenuItem
            // 
            this.重设地图名称ToolStripMenuItem.Name = "重设地图名称ToolStripMenuItem";
            this.重设地图名称ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.重设地图名称ToolStripMenuItem.Text = "重设地图名称";
            this.重设地图名称ToolStripMenuItem.Click += new System.EventHandler(this.重设地图名称ToolStripMenuItem_Click);
            // 
            // LinkEditToolStripMenuItem
            // 
            this.LinkEditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始编辑ToolStripMenuItem,
            this.结束编辑ToolStripMenuItem,
            this.在选定位置添加点ToolStripMenuItem});
            this.LinkEditToolStripMenuItem.Name = "LinkEditToolStripMenuItem";
            this.LinkEditToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.LinkEditToolStripMenuItem.Text = "编辑";
            // 
            // 开始编辑ToolStripMenuItem
            // 
            this.开始编辑ToolStripMenuItem.Name = "开始编辑ToolStripMenuItem";
            this.开始编辑ToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.开始编辑ToolStripMenuItem.Text = "开始编辑";
            // 
            // 结束编辑ToolStripMenuItem
            // 
            this.结束编辑ToolStripMenuItem.Name = "结束编辑ToolStripMenuItem";
            this.结束编辑ToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.结束编辑ToolStripMenuItem.Text = "结束编辑";
            // 
            // 在选定位置添加点ToolStripMenuItem
            // 
            this.在选定位置添加点ToolStripMenuItem.Name = "在选定位置添加点ToolStripMenuItem";
            this.在选定位置添加点ToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.在选定位置添加点ToolStripMenuItem.Text = "在选定位置添加点";
            this.在选定位置添加点ToolStripMenuItem.Click += new System.EventHandler(this.在选定位置添加点ToolStripMenuItem_Click);
            // 
            // LinkLayerToolStripMenuItem
            // 
            this.LinkLayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加图层ToolStripMenuItem,
            this.删除图层ToolStripMenuItem,
            this.查看属性表ToolStripMenuItem,
            this.编辑属性表ToolStripMenuItem});
            this.LinkLayerToolStripMenuItem.Name = "LinkLayerToolStripMenuItem";
            this.LinkLayerToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.LinkLayerToolStripMenuItem.Text = "图层";
            // 
            // 添加图层ToolStripMenuItem
            // 
            this.添加图层ToolStripMenuItem.Name = "添加图层ToolStripMenuItem";
            this.添加图层ToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.添加图层ToolStripMenuItem.Text = "添加图层";
            this.添加图层ToolStripMenuItem.Click += new System.EventHandler(this.添加图层ToolStripMenuItem_Click);
            // 
            // 删除图层ToolStripMenuItem
            // 
            this.删除图层ToolStripMenuItem.Name = "删除图层ToolStripMenuItem";
            this.删除图层ToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.删除图层ToolStripMenuItem.Text = "删除图层";
            this.删除图层ToolStripMenuItem.Click += new System.EventHandler(this.删除图层ToolStripMenuItem_Click);
            // 
            // 查看属性表ToolStripMenuItem
            // 
            this.查看属性表ToolStripMenuItem.Name = "查看属性表ToolStripMenuItem";
            this.查看属性表ToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.查看属性表ToolStripMenuItem.Text = "查看属性表";
            this.查看属性表ToolStripMenuItem.Click += new System.EventHandler(this.查看属性表ToolStripMenuItem_Click);
            // 
            // 编辑属性表ToolStripMenuItem
            // 
            this.编辑属性表ToolStripMenuItem.Name = "编辑属性表ToolStripMenuItem";
            this.编辑属性表ToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.编辑属性表ToolStripMenuItem.Text = "编辑属性表";
            this.编辑属性表ToolStripMenuItem.Click += new System.EventHandler(this.编辑属性表ToolStripMenuItem_Click);
            // 
            // LinkSearchToolStripMenuItem
            // 
            this.LinkSearchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.依据属性查询ToolStripMenuItem,
            this.依据几何查询ToolStripMenuItem});
            this.LinkSearchToolStripMenuItem.Name = "LinkSearchToolStripMenuItem";
            this.LinkSearchToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.LinkSearchToolStripMenuItem.Text = "查询";
            // 
            // 依据属性查询ToolStripMenuItem
            // 
            this.依据属性查询ToolStripMenuItem.Name = "依据属性查询ToolStripMenuItem";
            this.依据属性查询ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.依据属性查询ToolStripMenuItem.Text = "依据属性查询";
            this.依据属性查询ToolStripMenuItem.Click += new System.EventHandler(this.依据属性查询ToolStripMenuItem_Click);
            // 
            // 依据几何查询ToolStripMenuItem
            // 
            this.依据几何查询ToolStripMenuItem.Name = "依据几何查询ToolStripMenuItem";
            this.依据几何查询ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.依据几何查询ToolStripMenuItem.Text = "依据几何查询";
            // 
            // 注记ToolStripMenuItem
            // 
            this.注记ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加注记ToolStripMenuItem,
            this.简单符号法ToolStripMenuItem,
            this.唯一值符号法ToolStripMenuItem});
            this.注记ToolStripMenuItem.Name = "注记ToolStripMenuItem";
            this.注记ToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.注记ToolStripMenuItem.Text = "渲染";
            // 
            // 添加注记ToolStripMenuItem
            // 
            this.添加注记ToolStripMenuItem.Name = "添加注记ToolStripMenuItem";
            this.添加注记ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.添加注记ToolStripMenuItem.Text = "添加注记";
            this.添加注记ToolStripMenuItem.Click += new System.EventHandler(this.添加注记ToolStripMenuItem_Click);
            // 
            // 简单符号法ToolStripMenuItem
            // 
            this.简单符号法ToolStripMenuItem.Name = "简单符号法ToolStripMenuItem";
            this.简单符号法ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.简单符号法ToolStripMenuItem.Text = "简单符号法";
            this.简单符号法ToolStripMenuItem.Click += new System.EventHandler(this.简单符号法ToolStripMenuItem_Click);
            // 
            // 唯一值符号法ToolStripMenuItem
            // 
            this.唯一值符号法ToolStripMenuItem.Name = "唯一值符号法ToolStripMenuItem";
            this.唯一值符号法ToolStripMenuItem.Size = new System.Drawing.Size(256, 38);
            this.唯一值符号法ToolStripMenuItem.Text = "唯一值符号法";
            this.唯一值符号法ToolStripMenuItem.Click += new System.EventHandler(this.唯一值符号法ToolStripMenuItem_Click);
            // 
            // ScripLink
            // 
            this.ScripLink.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ScripLink.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ScripLink.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLinkZoomIn,
            this.btnLinkZoomOut,
            this.btnLinkPan,
            this.btnLinkSelcet,
            this.btnLinkEdit,
            this.btnLinkDrawPoints,
            this.btnLinkDrawPolyline,
            this.btnLinkDrawPolygon,
            this.btnLinkDelete});
            this.ScripLink.Location = new System.Drawing.Point(0, 39);
            this.ScripLink.Name = "ScripLink";
            this.ScripLink.Padding = new System.Windows.Forms.Padding(0);
            this.ScripLink.Size = new System.Drawing.Size(1250, 39);
            this.ScripLink.TabIndex = 1;
            this.ScripLink.Text = "toolStrip1";
            // 
            // btnLinkZoomIn
            // 
            this.btnLinkZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkZoomIn.Image")));
            this.btnLinkZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkZoomIn.Name = "btnLinkZoomIn";
            this.btnLinkZoomIn.Size = new System.Drawing.Size(36, 36);
            this.btnLinkZoomIn.Text = "ZoomIn";
            this.btnLinkZoomIn.Click += new System.EventHandler(this.btnLinkZoomIn_Click);
            // 
            // btnLinkZoomOut
            // 
            this.btnLinkZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkZoomOut.Image")));
            this.btnLinkZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkZoomOut.Name = "btnLinkZoomOut";
            this.btnLinkZoomOut.Size = new System.Drawing.Size(36, 36);
            this.btnLinkZoomOut.Text = "ZoomOut";
            this.btnLinkZoomOut.Click += new System.EventHandler(this.btnLinkZoomOut_Click);
            // 
            // btnLinkPan
            // 
            this.btnLinkPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkPan.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkPan.Image")));
            this.btnLinkPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkPan.Name = "btnLinkPan";
            this.btnLinkPan.Size = new System.Drawing.Size(36, 36);
            this.btnLinkPan.Text = "Pan";
            this.btnLinkPan.Click += new System.EventHandler(this.btnLinkPan_Click);
            // 
            // btnLinkSelcet
            // 
            this.btnLinkSelcet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkSelcet.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkSelcet.Image")));
            this.btnLinkSelcet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkSelcet.Name = "btnLinkSelcet";
            this.btnLinkSelcet.Size = new System.Drawing.Size(36, 36);
            this.btnLinkSelcet.Text = "Select";
            this.btnLinkSelcet.Click += new System.EventHandler(this.btnLinkSelcet_Click);
            // 
            // btnLinkEdit
            // 
            this.btnLinkEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkEdit.Image")));
            this.btnLinkEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkEdit.Name = "btnLinkEdit";
            this.btnLinkEdit.Size = new System.Drawing.Size(36, 36);
            this.btnLinkEdit.Text = "Edit";
            this.btnLinkEdit.Click += new System.EventHandler(this.btnLinkEdit_Click);
            // 
            // btnLinkDrawPoints
            // 
            this.btnLinkDrawPoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkDrawPoints.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkDrawPoints.Image")));
            this.btnLinkDrawPoints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkDrawPoints.Name = "btnLinkDrawPoints";
            this.btnLinkDrawPoints.Size = new System.Drawing.Size(36, 36);
            this.btnLinkDrawPoints.Text = "AddPoint";
            this.btnLinkDrawPoints.Click += new System.EventHandler(this.btnLinkDrawPoints_Click);
            // 
            // btnLinkDrawPolyline
            // 
            this.btnLinkDrawPolyline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkDrawPolyline.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkDrawPolyline.Image")));
            this.btnLinkDrawPolyline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkDrawPolyline.Name = "btnLinkDrawPolyline";
            this.btnLinkDrawPolyline.Size = new System.Drawing.Size(36, 36);
            this.btnLinkDrawPolyline.Text = "AddPolyline";
            this.btnLinkDrawPolyline.Click += new System.EventHandler(this.btnLinkDrawPolyline_Click);
            // 
            // btnLinkDrawPolygon
            // 
            this.btnLinkDrawPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkDrawPolygon.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkDrawPolygon.Image")));
            this.btnLinkDrawPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkDrawPolygon.Name = "btnLinkDrawPolygon";
            this.btnLinkDrawPolygon.Size = new System.Drawing.Size(36, 36);
            this.btnLinkDrawPolygon.Text = "AddPolygon";
            this.btnLinkDrawPolygon.Click += new System.EventHandler(this.btnLinkDrawPolygon_Click);
            // 
            // btnLinkDelete
            // 
            this.btnLinkDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkDelete.Image")));
            this.btnLinkDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkDelete.Name = "btnLinkDelete";
            this.btnLinkDelete.Size = new System.Drawing.Size(36, 36);
            this.btnLinkDelete.Text = "Delete";
            this.btnLinkDelete.Click += new System.EventHandler(this.btnLinkDelete_Click);
            // 
            // LinkLayerBox
            // 
            this.LinkLayerBox.AllowDrop = true;
            this.LinkLayerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LinkLayerBox.CheckBoxes = true;
            this.LinkLayerBox.LabelEdit = true;
            this.LinkLayerBox.Location = new System.Drawing.Point(16, 152);
            this.LinkLayerBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LinkLayerBox.Name = "LinkLayerBox";
            treeNode1.Checked = true;
            treeNode1.Name = "LinkMapNode";
            treeNode1.Text = "LinkMap";
            this.LinkLayerBox.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.LinkLayerBox.Size = new System.Drawing.Size(304, 602);
            this.LinkLayerBox.TabIndex = 3;
            this.LinkLayerBox.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.LinkLayerBox_AfterLabelEdit);
            this.LinkLayerBox.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.LinkLayerBox_BeforeCheck);
            this.LinkLayerBox.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.LinkLayerBox_AfterCheck);
            this.LinkLayerBox.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.LinkLayerBox_ItemDrag);
            this.LinkLayerBox.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LinkLayerBox_NodeMouseDoubleClick);
            this.LinkLayerBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.LinkLayerBox_DragDrop);
            this.LinkLayerBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.LinkLayerBox_DragEnter);
            this.LinkLayerBox.DragOver += new System.Windows.Forms.DragEventHandler(this.LinkLayerBox_DragOver);
            // 
            // LinkPointLocation
            // 
            this.LinkPointLocation.AutoSize = true;
            this.LinkPointLocation.Location = new System.Drawing.Point(336, 760);
            this.LinkPointLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LinkPointLocation.Name = "LinkPointLocation";
            this.LinkPointLocation.Size = new System.Drawing.Size(0, 24);
            this.LinkPointLocation.TabIndex = 5;
            // 
            // tss2
            // 
            this.tss2.AutoSize = true;
            this.tss2.Location = new System.Drawing.Point(1160, 760);
            this.tss2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tss2.Name = "tss2";
            this.tss2.Size = new System.Drawing.Size(82, 24);
            this.tss2.TabIndex = 6;
            this.tss2.Text = "1:1.00";
            // 
            // cmstripLayer
            // 
            this.cmstripLayer.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmstripLayer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重命名ToolStripMenuItem,
            this.查看属性表ToolStripMenuItem1,
            this.增加图层ToolStripMenuItem,
            this.删除图层ToolStripMenuItem1});
            this.cmstripLayer.Name = "cmstripLayer";
            this.cmstripLayer.Size = new System.Drawing.Size(209, 148);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(208, 36);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // 查看属性表ToolStripMenuItem1
            // 
            this.查看属性表ToolStripMenuItem1.Name = "查看属性表ToolStripMenuItem1";
            this.查看属性表ToolStripMenuItem1.Size = new System.Drawing.Size(208, 36);
            this.查看属性表ToolStripMenuItem1.Text = "查看属性表";
            this.查看属性表ToolStripMenuItem1.Click += new System.EventHandler(this.查看属性表ToolStripMenuItem1_Click);
            // 
            // 增加图层ToolStripMenuItem
            // 
            this.增加图层ToolStripMenuItem.Name = "增加图层ToolStripMenuItem";
            this.增加图层ToolStripMenuItem.Size = new System.Drawing.Size(208, 36);
            this.增加图层ToolStripMenuItem.Text = "增加图层";
            this.增加图层ToolStripMenuItem.Click += new System.EventHandler(this.增加图层ToolStripMenuItem_Click);
            // 
            // 删除图层ToolStripMenuItem1
            // 
            this.删除图层ToolStripMenuItem1.Name = "删除图层ToolStripMenuItem1";
            this.删除图层ToolStripMenuItem1.Size = new System.Drawing.Size(208, 36);
            this.删除图层ToolStripMenuItem1.Text = "删除图层";
            this.删除图层ToolStripMenuItem1.Click += new System.EventHandler(this.删除图层ToolStripMenuItem1_Click);
            // 
            // LinkMapControl1
            // 
            this.LinkMapControl1.BackColor = System.Drawing.Color.White;
            this.LinkMapControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LinkMapControl1.BoundaryColor = System.Drawing.Color.Black;
            this.LinkMapControl1.DisplayScale = 1D;
            this.LinkMapControl1.FillColor = System.Drawing.Color.Tomato;
            this.LinkMapControl1.Location = new System.Drawing.Point(328, 152);
            this.LinkMapControl1.MapNameSet = "默认工程";
            this.LinkMapControl1.Margin = new System.Windows.Forms.Padding(2);
            this.LinkMapControl1.Name = "LinkMapControl1";
            this.LinkMapControl1.Polygon = new LinkMapObject.Polygon[0];
            this.LinkMapControl1.SelectedFea = ((System.Collections.Generic.List<object>)(resources.GetObject("LinkMapControl1.SelectedFea")));
            this.LinkMapControl1.SelectedPolygon = new LinkMapObject.Polygon[0];
            this.LinkMapControl1.SelfMouseWheel = true;
            this.LinkMapControl1.Size = new System.Drawing.Size(914, 600);
            this.LinkMapControl1.TabIndex = 4;
            this.LinkMapControl1.TrackingColor = System.Drawing.Color.DarkGreen;
            this.LinkMapControl1.TrackingFinshed += new LinkMapObject.LinkMapControl.TrackingFinishedHandle(this.LinkMapControl1_TrackingFinshed);
            this.LinkMapControl1.TrackingPolylineFinshed += new LinkMapObject.LinkMapControl.TrackingPolylineFinishedHandle(this.LinkMapControl1_TrackingPolylineFinshed);
            this.LinkMapControl1.TrackingPointFinshed += new LinkMapObject.LinkMapControl.TrackingPointFinishedHandle(this.LinkMapControl1_TrackingPointFinshed);
            this.LinkMapControl1.DispalyCsaleChanged += new LinkMapObject.LinkMapControl.DispalyScaleChangeHandle(this.LinkMapControl1_DispalyCsaleChanged);
            this.LinkMapControl1.SelectingFinshed += new LinkMapObject.LinkMapControl.SelectingFinishedHandle(this.LinkMapControl1_SelectingFinshed);
            this.LinkMapControl1.GetTreeViewIndex += new LinkMapObject.LinkMapControl.GetTreeViewIndexHandle(this.LinkMapControl1_GetTreeViewIndex);
            this.LinkMapControl1.Load += new System.EventHandler(this.LinkMapControl1_Load);
            this.LinkMapControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LinkMapControl1_MouseMove);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1250, 788);
            this.Controls.Add(this.tss2);
            this.Controls.Add(this.LinkPointLocation);
            this.Controls.Add(this.LinkMapControl1);
            this.Controls.Add(this.LinkLayerBox);
            this.Controls.Add(this.ScripLink);
            this.Controls.Add(this.Linkmenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Linkmenu;
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "LinkMap";
            this.Linkmenu.ResumeLayout(false);
            this.Linkmenu.PerformLayout();
            this.ScripLink.ResumeLayout(false);
            this.ScripLink.PerformLayout();
            this.cmstripLayer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Linkmenu;
        private System.Windows.Forms.ToolStripMenuItem LinkFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LinkEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LinkLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStrip ScripLink;
        private System.Windows.Forms.ToolStripButton btnLinkZoomIn;
        private System.Windows.Forms.ToolStripButton btnLinkZoomOut;
        private System.Windows.Forms.ToolStripButton btnLinkEdit;
        private System.Windows.Forms.ToolStripButton btnLinkSelcet;
        private System.Windows.Forms.ToolStripButton btnLinkDrawPoints;
        private System.Windows.Forms.ToolStripButton btnLinkDrawPolyline;
        private System.Windows.Forms.ToolStripButton btnLinkDrawPolygon;
        private System.Windows.Forms.ToolStripButton btnLinkDelete;
        private System.Windows.Forms.ToolStripButton btnLinkPan;
        private System.Windows.Forms.ToolStripMenuItem LinkSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在选定位置添加点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 依据属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 依据几何查询ToolStripMenuItem;
        private System.Windows.Forms.TreeView LinkLayerBox;
        private LinkMapObject.LinkMapControl LinkMapControl1;
        private System.Windows.Forms.Label LinkPointLocation;
        private System.Windows.Forms.Label tss2;
        private System.Windows.Forms.ToolStripMenuItem 查看属性表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑属性表ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmstripLayer;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看属性表ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 增加图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除图层ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 注记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加注记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重设地图名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 简单符号法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 唯一值符号法ToolStripMenuItem;
    }
}

