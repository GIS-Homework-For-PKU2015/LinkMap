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
            this.searchTBox.Location = new System.Drawing.Point(65, 20);
            this.searchTBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchTBox.Name = "searchTBox";
            this.searchTBox.Size = new System.Drawing.Size(196, 21);
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
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "SQL语句";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "查询结果：";
            // 
            // sqlDataGridView
            // 
            this.sqlDataGridView.AllowUserToAddRows = false;
            this.sqlDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sqlDataGridView.Location = new System.Drawing.Point(11, 91);
            this.sqlDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sqlDataGridView.Name = "sqlDataGridView";
            this.sqlDataGridView.RowTemplate.Height = 37;
            this.sqlDataGridView.Size = new System.Drawing.Size(299, 207);
            this.sqlDataGridView.TabIndex = 4;
            // 
            // btnDoSearch
            // 
            this.btnDoSearch.Location = new System.Drawing.Point(266, 18);
            this.btnDoSearch.Name = "btnDoSearch";
            this.btnDoSearch.Size = new System.Drawing.Size(44, 23);
            this.btnDoSearch.TabIndex = 5;
            this.btnDoSearch.Text = "查";
            this.btnDoSearch.UseVisualStyleBackColor = true;
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 309);
            this.Controls.Add(this.btnDoSearch);
            this.Controls.Add(this.sqlDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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