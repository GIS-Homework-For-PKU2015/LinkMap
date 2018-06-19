namespace LinkMap.GUI {
    partial class editAttForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editAttForm));
            this.editDataGV = new System.Windows.Forms.DataGridView();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnAddCol = new System.Windows.Forms.Button();
            this.btnDelCol = new System.Windows.Forms.Button();
            this.btnSaveChange = new System.Windows.Forms.Button();
            this.btnNotSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editDataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // editDataGV
            // 
            this.editDataGV.AllowUserToAddRows = false;
            this.editDataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.editDataGV.Location = new System.Drawing.Point(4, 4);
            this.editDataGV.Name = "editDataGV";
            this.editDataGV.RowTemplate.Height = 23;
            this.editDataGV.Size = new System.Drawing.Size(607, 355);
            this.editDataGV.TabIndex = 0;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(221, 382);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "增加行";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.Location = new System.Drawing.Point(314, 382);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(75, 23);
            this.btnDelRow.TabIndex = 2;
            this.btnDelRow.Text = "删除行";
            this.btnDelRow.UseVisualStyleBackColor = true;
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnAddCol
            // 
            this.btnAddCol.Location = new System.Drawing.Point(23, 382);
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size(75, 23);
            this.btnAddCol.TabIndex = 3;
            this.btnAddCol.Text = "增加列";
            this.btnAddCol.UseVisualStyleBackColor = true;
            this.btnAddCol.Click += new System.EventHandler(this.btnAddCol_Click);
            // 
            // btnDelCol
            // 
            this.btnDelCol.Location = new System.Drawing.Point(118, 382);
            this.btnDelCol.Name = "btnDelCol";
            this.btnDelCol.Size = new System.Drawing.Size(75, 23);
            this.btnDelCol.TabIndex = 4;
            this.btnDelCol.Text = "删除列";
            this.btnDelCol.UseVisualStyleBackColor = true;
            this.btnDelCol.Click += new System.EventHandler(this.btnDelCol_Click);
            // 
            // btnSaveChange
            // 
            this.btnSaveChange.Location = new System.Drawing.Point(422, 382);
            this.btnSaveChange.Name = "btnSaveChange";
            this.btnSaveChange.Size = new System.Drawing.Size(75, 23);
            this.btnSaveChange.TabIndex = 5;
            this.btnSaveChange.Text = "保存";
            this.btnSaveChange.UseVisualStyleBackColor = true;
            this.btnSaveChange.Click += new System.EventHandler(this.btnSaveChange_Click);
            // 
            // btnNotSave
            // 
            this.btnNotSave.Location = new System.Drawing.Point(519, 382);
            this.btnNotSave.Name = "btnNotSave";
            this.btnNotSave.Size = new System.Drawing.Size(75, 23);
            this.btnNotSave.TabIndex = 6;
            this.btnNotSave.Text = "取消";
            this.btnNotSave.UseVisualStyleBackColor = true;
            this.btnNotSave.Click += new System.EventHandler(this.btnNotSave_Click);
            // 
            // editAttForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 430);
            this.Controls.Add(this.btnNotSave);
            this.Controls.Add(this.btnSaveChange);
            this.Controls.Add(this.btnDelCol);
            this.Controls.Add(this.btnAddCol);
            this.Controls.Add(this.btnDelRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.editDataGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "editAttForm";
            this.Text = "editAttForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.editAttForm_FormClosed);
            this.Load += new System.EventHandler(this.editAttForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editDataGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView editDataGV;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDelRow;
        private System.Windows.Forms.Button btnAddCol;
        private System.Windows.Forms.Button btnDelCol;
        private System.Windows.Forms.Button btnSaveChange;
        private System.Windows.Forms.Button btnNotSave;
    }
}