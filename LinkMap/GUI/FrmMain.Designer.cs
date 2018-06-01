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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.Linkmenu = new System.Windows.Forms.MenuStrip();
            this.LinkFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LinkEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在选定位置添加点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LinkLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LinkSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.依据属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.依据几何查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScripLink = new System.Windows.Forms.ToolStrip();
            this.btnLinkIdentity = new System.Windows.Forms.ToolStripButton();
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
            this.linkMapControl1 = new LinkMapObject.LinkMapControl();
            this.Linkmenu.SuspendLayout();
            this.ScripLink.SuspendLayout();
            this.SuspendLayout();
            // 
            // Linkmenu
            // 
            this.Linkmenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Linkmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LinkFileToolStripMenuItem,
            this.LinkEditToolStripMenuItem,
            this.LinkLayerToolStripMenuItem,
            this.LinkSearchToolStripMenuItem});
            this.Linkmenu.Location = new System.Drawing.Point(0, 0);
            this.Linkmenu.Name = "Linkmenu";
            this.Linkmenu.Size = new System.Drawing.Size(1150, 39);
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
            this.导出ToolStripMenuItem});
            this.LinkFileToolStripMenuItem.Name = "LinkFileToolStripMenuItem";
            this.LinkFileToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.LinkFileToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(160, 38);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(160, 38);
            this.导入ToolStripMenuItem.Text = "打开";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导入ToolStripMenuItem1
            // 
            this.导入ToolStripMenuItem1.Name = "导入ToolStripMenuItem1";
            this.导入ToolStripMenuItem1.Size = new System.Drawing.Size(160, 38);
            this.导入ToolStripMenuItem1.Text = "导入";
            this.导入ToolStripMenuItem1.Click += new System.EventHandler(this.导入ToolStripMenuItem1_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(160, 38);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(160, 38);
            this.导出ToolStripMenuItem.Text = "导出";
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
            this.删除图层ToolStripMenuItem});
            this.LinkLayerToolStripMenuItem.Name = "LinkLayerToolStripMenuItem";
            this.LinkLayerToolStripMenuItem.Size = new System.Drawing.Size(74, 35);
            this.LinkLayerToolStripMenuItem.Text = "图层";
            // 
            // 添加图层ToolStripMenuItem
            // 
            this.添加图层ToolStripMenuItem.Name = "添加图层ToolStripMenuItem";
            this.添加图层ToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.添加图层ToolStripMenuItem.Text = "添加图层";
            this.添加图层ToolStripMenuItem.Click += new System.EventHandler(this.添加图层ToolStripMenuItem_Click);
            // 
            // 删除图层ToolStripMenuItem
            // 
            this.删除图层ToolStripMenuItem.Name = "删除图层ToolStripMenuItem";
            this.删除图层ToolStripMenuItem.Size = new System.Drawing.Size(208, 38);
            this.删除图层ToolStripMenuItem.Text = "删除图层";
            this.删除图层ToolStripMenuItem.Click += new System.EventHandler(this.删除图层ToolStripMenuItem_Click);
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
            // ScripLink
            // 
            this.ScripLink.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ScripLink.ImeMode = System.Windows.Forms.ImeMode.On;
            this.ScripLink.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLinkIdentity,
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
            this.ScripLink.Size = new System.Drawing.Size(1150, 39);
            this.ScripLink.TabIndex = 1;
            this.ScripLink.Text = "toolStrip1";
            // 
            // btnLinkIdentity
            // 
            this.btnLinkIdentity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkIdentity.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkIdentity.Image")));
            this.btnLinkIdentity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkIdentity.Name = "btnLinkIdentity";
            this.btnLinkIdentity.Size = new System.Drawing.Size(36, 36);
            this.btnLinkIdentity.Text = "toolStripButton3";
            this.btnLinkIdentity.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnLinkZoomIn
            // 
            this.btnLinkZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkZoomIn.Image")));
            this.btnLinkZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkZoomIn.Name = "btnLinkZoomIn";
            this.btnLinkZoomIn.Size = new System.Drawing.Size(36, 36);
            this.btnLinkZoomIn.Text = "toolStripButton1";
            // 
            // btnLinkZoomOut
            // 
            this.btnLinkZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkZoomOut.Image")));
            this.btnLinkZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkZoomOut.Name = "btnLinkZoomOut";
            this.btnLinkZoomOut.Size = new System.Drawing.Size(36, 36);
            this.btnLinkZoomOut.Text = "toolStripButton2";
            // 
            // btnLinkPan
            // 
            this.btnLinkPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkPan.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkPan.Image")));
            this.btnLinkPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkPan.Name = "btnLinkPan";
            this.btnLinkPan.Size = new System.Drawing.Size(36, 36);
            this.btnLinkPan.Text = "toolStripButton10";
            // 
            // btnLinkSelcet
            // 
            this.btnLinkSelcet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkSelcet.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkSelcet.Image")));
            this.btnLinkSelcet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkSelcet.Name = "btnLinkSelcet";
            this.btnLinkSelcet.Size = new System.Drawing.Size(36, 36);
            this.btnLinkSelcet.Text = "toolStripButton9";
            // 
            // btnLinkEdit
            // 
            this.btnLinkEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkEdit.Image")));
            this.btnLinkEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkEdit.Name = "btnLinkEdit";
            this.btnLinkEdit.Size = new System.Drawing.Size(36, 36);
            this.btnLinkEdit.Text = "toolStripButton5";
            // 
            // btnLinkDrawPoints
            // 
            this.btnLinkDrawPoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkDrawPoints.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkDrawPoints.Image")));
            this.btnLinkDrawPoints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkDrawPoints.Name = "btnLinkDrawPoints";
            this.btnLinkDrawPoints.Size = new System.Drawing.Size(36, 36);
            this.btnLinkDrawPoints.Text = "toolStripButton6";
            // 
            // btnLinkDrawPolyline
            // 
            this.btnLinkDrawPolyline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkDrawPolyline.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkDrawPolyline.Image")));
            this.btnLinkDrawPolyline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkDrawPolyline.Name = "btnLinkDrawPolyline";
            this.btnLinkDrawPolyline.Size = new System.Drawing.Size(36, 36);
            this.btnLinkDrawPolyline.Text = "toolStripButton7";
            // 
            // btnLinkDrawPolygon
            // 
            this.btnLinkDrawPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkDrawPolygon.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkDrawPolygon.Image")));
            this.btnLinkDrawPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkDrawPolygon.Name = "btnLinkDrawPolygon";
            this.btnLinkDrawPolygon.Size = new System.Drawing.Size(36, 36);
            this.btnLinkDrawPolygon.Text = "toolStripButton8";
            // 
            // btnLinkDelete
            // 
            this.btnLinkDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkDelete.Image")));
            this.btnLinkDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkDelete.Name = "btnLinkDelete";
            this.btnLinkDelete.Size = new System.Drawing.Size(36, 36);
            this.btnLinkDelete.Text = "toolStripButton4";
            // 
            // LinkLayerBox
            // 
            this.LinkLayerBox.CheckBoxes = true;
            this.LinkLayerBox.Location = new System.Drawing.Point(24, 152);
            this.LinkLayerBox.Margin = new System.Windows.Forms.Padding(4);
            this.LinkLayerBox.Name = "LinkLayerBox";
            this.LinkLayerBox.Size = new System.Drawing.Size(176, 600);
            this.LinkLayerBox.TabIndex = 3;
            // 
            // linkMapControl1
            // 
            this.linkMapControl1.BackColor = System.Drawing.Color.White;
            this.linkMapControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkMapControl1.BoundaryColor = System.Drawing.Color.Black;
            this.linkMapControl1.DisplayScale = 1D;
            this.linkMapControl1.FillColor = System.Drawing.Color.Tomato;
            this.linkMapControl1.Location = new System.Drawing.Point(256, 152);
            this.linkMapControl1.Margin = new System.Windows.Forms.Padding(2);
            this.linkMapControl1.Name = "linkMapControl1";
            this.linkMapControl1.Polygon = new LinkMapObject.Polygon[0];
            this.linkMapControl1.SelectedPolygon = new LinkMapObject.Polygon[0];
            this.linkMapControl1.SelfMouseWheel = true;
            this.linkMapControl1.Size = new System.Drawing.Size(800, 600);
            this.linkMapControl1.TabIndex = 4;
            this.linkMapControl1.TrackingColor = System.Drawing.Color.DarkGreen;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 797);
            this.Controls.Add(this.linkMapControl1);
            this.Controls.Add(this.LinkLayerBox);
            this.Controls.Add(this.ScripLink);
            this.Controls.Add(this.Linkmenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Linkmenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "LinkMap";
            this.Linkmenu.ResumeLayout(false);
            this.Linkmenu.PerformLayout();
            this.ScripLink.ResumeLayout(false);
            this.ScripLink.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton btnLinkIdentity;
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
        private LinkMapObject.LinkMapControl linkMapControl1;
    }
}

