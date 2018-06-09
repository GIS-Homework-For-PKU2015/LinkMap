namespace LinkMap.GUI
{
    partial class AddLayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.LinkLayerNameBox = new System.Windows.Forms.TextBox();
            this.btnGetLayerName = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.featypeCBox = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层名称";
            // 
            // LinkLayerNameBox
            // 
            this.LinkLayerNameBox.Location = new System.Drawing.Point(32, 48);
            this.LinkLayerNameBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LinkLayerNameBox.Name = "LinkLayerNameBox";
            this.LinkLayerNameBox.Size = new System.Drawing.Size(182, 21);
            this.LinkLayerNameBox.TabIndex = 1;
            // 
            // btnGetLayerName
            // 
            this.btnGetLayerName.Location = new System.Drawing.Point(32, 147);
            this.btnGetLayerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGetLayerName.Name = "btnGetLayerName";
            this.btnGetLayerName.Size = new System.Drawing.Size(64, 24);
            this.btnGetLayerName.TabIndex = 2;
            this.btnGetLayerName.Text = "确定";
            this.btnGetLayerName.UseVisualStyleBackColor = true;
            this.btnGetLayerName.Click += new System.EventHandler(this.btnGetLayerName_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 147);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // featypeCBox
            // 
            this.featypeCBox.FormattingEnabled = true;
            this.featypeCBox.Items.AddRange(new object[] {
            "点要素",
            "线要素",
            "多边形",
            "多多边形",
            "未确定类型"});
            this.featypeCBox.Location = new System.Drawing.Point(90, 80);
            this.featypeCBox.Name = "featypeCBox";
            this.featypeCBox.Size = new System.Drawing.Size(124, 20);
            this.featypeCBox.TabIndex = 4;
            this.featypeCBox.Text = "多边形";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(32, 83);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 12);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "要素类型";
            // 
            // AddLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 246);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.featypeCBox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGetLayerName);
            this.Controls.Add(this.LinkLayerNameBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddLayer";
            this.Text = "AddLayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LinkLayerNameBox;
        private System.Windows.Forms.Button btnGetLayerName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox featypeCBox;
        private System.Windows.Forms.Label lblType;
    }
}