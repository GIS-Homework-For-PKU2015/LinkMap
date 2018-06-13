namespace LinkMap.GUI {
    partial class attributeForm {
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
            this.attDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.attDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // attDataGridView
            // 
            this.attDataGridView.AllowUserToAddRows = false;
            this.attDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attDataGridView.Location = new System.Drawing.Point(0, 0);
            this.attDataGridView.Name = "attDataGridView";
            this.attDataGridView.RowTemplate.Height = 23;
            this.attDataGridView.Size = new System.Drawing.Size(546, 411);
            this.attDataGridView.TabIndex = 0;
            // 
            // attributeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 411);
            this.Controls.Add(this.attDataGridView);
            this.Name = "attributeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "attributeForm";
            this.Load += new System.EventHandler(this.attributeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.attDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView attDataGridView;
    }
}