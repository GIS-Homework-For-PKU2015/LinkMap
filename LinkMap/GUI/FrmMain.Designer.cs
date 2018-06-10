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
            this.SuspendLayout();
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmMain";
            this.ResumeLayout(false);

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
        private LinkMapObject.LinkMapControl LinkMapControl1;
        private System.Windows.Forms.Label LinkPointLocation;
    }
}

