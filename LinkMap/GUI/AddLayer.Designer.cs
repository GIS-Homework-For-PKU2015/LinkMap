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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层名称";
            // 
            // LinkLayerNameBox
            // 
            this.LinkLayerNameBox.Location = new System.Drawing.Point(64, 96);
            this.LinkLayerNameBox.Name = "LinkLayerNameBox";
            this.LinkLayerNameBox.Size = new System.Drawing.Size(360, 35);
            this.LinkLayerNameBox.TabIndex = 1;
            // 
            // btnGetLayerName
            // 
            this.btnGetLayerName.Location = new System.Drawing.Point(64, 152);
            this.btnGetLayerName.Name = "btnGetLayerName";
            this.btnGetLayerName.Size = new System.Drawing.Size(128, 48);
            this.btnGetLayerName.TabIndex = 2;
            this.btnGetLayerName.Text = "确定";
            this.btnGetLayerName.UseVisualStyleBackColor = true;
            this.btnGetLayerName.Click += new System.EventHandler(this.btnGetLayerName_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(296, 152);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 48);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 492);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGetLayerName);
            this.Controls.Add(this.LinkLayerNameBox);
            this.Controls.Add(this.label1);
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
    }
}