﻿namespace LinkMapObject
{
    partial class LinkMapControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LinkMapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DoubleBuffered = true;
            this.Name = "LinkMapControl";
            this.Size = new System.Drawing.Size(394, 370);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LinkMapControl_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LinkMapControl_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LinkMapControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LinkMapControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LinkMapControl_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
