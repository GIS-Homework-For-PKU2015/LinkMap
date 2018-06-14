namespace LinkMap.GUI {
    partial class renameMapPrioj {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.renameTextBox = new System.Windows.Forms.TextBox();
            this.btnOKrename = new System.Windows.Forms.Button();
            this.btnCrename = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // renameTextBox
            // 
            this.renameTextBox.Location = new System.Drawing.Point(21, 57);
            this.renameTextBox.Name = "renameTextBox";
            this.renameTextBox.Size = new System.Drawing.Size(291, 21);
            this.renameTextBox.TabIndex = 0;
            // 
            // btnOKrename
            // 
            this.btnOKrename.Location = new System.Drawing.Point(59, 151);
            this.btnOKrename.Name = "btnOKrename";
            this.btnOKrename.Size = new System.Drawing.Size(75, 23);
            this.btnOKrename.TabIndex = 1;
            this.btnOKrename.Text = "确认";
            this.btnOKrename.UseVisualStyleBackColor = true;
            this.btnOKrename.Click += new System.EventHandler(this.btnOKrename_Click);
            // 
            // btnCrename
            // 
            this.btnCrename.Location = new System.Drawing.Point(214, 151);
            this.btnCrename.Name = "btnCrename";
            this.btnCrename.Size = new System.Drawing.Size(75, 23);
            this.btnCrename.TabIndex = 2;
            this.btnCrename.Text = "取消";
            this.btnCrename.UseVisualStyleBackColor = true;
            this.btnCrename.Click += new System.EventHandler(this.btnCrename_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "新地图名称：";
            // 
            // renameMapPrioj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 235);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrename);
            this.Controls.Add(this.btnOKrename);
            this.Controls.Add(this.renameTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "renameMapPrioj";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "renameMapPrioj";
            this.Load += new System.EventHandler(this.renameMapPrioj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox renameTextBox;
        private System.Windows.Forms.Button btnOKrename;
        private System.Windows.Forms.Button btnCrename;
        private System.Windows.Forms.Label label1;
    }
}