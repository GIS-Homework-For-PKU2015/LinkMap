namespace LinkMap
{
    partial class Search
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.searchTBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlDataGridView = new System.Windows.Forms.DataGridView();
            this.btnDoSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sqlDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTBox
            // 
            this.searchTBox.Location = new System.Drawing.Point(130, 40);
            this.searchTBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchTBox.Name = "searchTBox";
            this.searchTBox.Size = new System.Drawing.Size(358, 35);
            this.searchTBox.TabIndex = 0;
            this.searchTBox.Text = "NAME=\'杭州市\'";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "SQL语句";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "查询结果：";
            // 
            // sqlDataGridView
            // 
            this.sqlDataGridView.AllowUserToAddRows = false;
            this.sqlDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sqlDataGridView.Location = new System.Drawing.Point(22, 182);
            this.sqlDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sqlDataGridView.Name = "sqlDataGridView";
            this.sqlDataGridView.RowTemplate.Height = 37;
            this.sqlDataGridView.Size = new System.Drawing.Size(598, 414);
            this.sqlDataGridView.TabIndex = 4;
            // 
            // btnDoSearch
            // 
            this.btnDoSearch.Location = new System.Drawing.Point(504, 36);
            this.btnDoSearch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnDoSearch.Name = "btnDoSearch";
            this.btnDoSearch.Size = new System.Drawing.Size(116, 46);
            this.btnDoSearch.TabIndex = 5;
            this.btnDoSearch.Text = "查询";
            this.btnDoSearch.UseVisualStyleBackColor = true;
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 618);
            this.Controls.Add(this.btnDoSearch);
            this.Controls.Add(this.sqlDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.sqlDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView sqlDataGridView;
        private System.Windows.Forms.Button btnDoSearch;
    }
}