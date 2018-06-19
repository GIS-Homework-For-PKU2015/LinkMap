namespace LinkMap.GUI {
    partial class addColToAtt {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addColToAtt));
            this.btnNewColOK = new System.Windows.Forms.Button();
            this.btnNewColCancel = new System.Windows.Forms.Button();
            this.addNewColTBox = new System.Windows.Forms.TextBox();
            this.newTypeCBox = new System.Windows.Forms.ComboBox();
            this.newColNameLbl = new System.Windows.Forms.Label();
            this.newColTypeLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNewColOK
            // 
            this.btnNewColOK.Location = new System.Drawing.Point(37, 185);
            this.btnNewColOK.Name = "btnNewColOK";
            this.btnNewColOK.Size = new System.Drawing.Size(75, 23);
            this.btnNewColOK.TabIndex = 0;
            this.btnNewColOK.Text = "确认";
            this.btnNewColOK.UseVisualStyleBackColor = true;
            this.btnNewColOK.Click += new System.EventHandler(this.btnNewColOK_Click);
            // 
            // btnNewColCancel
            // 
            this.btnNewColCancel.Location = new System.Drawing.Point(182, 185);
            this.btnNewColCancel.Name = "btnNewColCancel";
            this.btnNewColCancel.Size = new System.Drawing.Size(75, 23);
            this.btnNewColCancel.TabIndex = 1;
            this.btnNewColCancel.Text = "取消";
            this.btnNewColCancel.UseVisualStyleBackColor = true;
            this.btnNewColCancel.Click += new System.EventHandler(this.btnNewColCancel_Click);
            // 
            // addNewColTBox
            // 
            this.addNewColTBox.Location = new System.Drawing.Point(76, 47);
            this.addNewColTBox.Name = "addNewColTBox";
            this.addNewColTBox.Size = new System.Drawing.Size(181, 21);
            this.addNewColTBox.TabIndex = 2;
            this.addNewColTBox.Text = "newCol1";
            // 
            // newTypeCBox
            // 
            this.newTypeCBox.FormattingEnabled = true;
            this.newTypeCBox.Items.AddRange(new object[] {
            "String",
            "Int",
            "Date"});
            this.newTypeCBox.Location = new System.Drawing.Point(76, 96);
            this.newTypeCBox.Name = "newTypeCBox";
            this.newTypeCBox.Size = new System.Drawing.Size(106, 20);
            this.newTypeCBox.TabIndex = 3;
            this.newTypeCBox.Text = "String";
            // 
            // newColNameLbl
            // 
            this.newColNameLbl.AutoSize = true;
            this.newColNameLbl.Location = new System.Drawing.Point(35, 50);
            this.newColNameLbl.Name = "newColNameLbl";
            this.newColNameLbl.Size = new System.Drawing.Size(35, 12);
            this.newColNameLbl.TabIndex = 4;
            this.newColNameLbl.Text = "列名:";
            // 
            // newColTypeLbl
            // 
            this.newColTypeLbl.AutoSize = true;
            this.newColTypeLbl.Location = new System.Drawing.Point(35, 99);
            this.newColTypeLbl.Name = "newColTypeLbl";
            this.newColTypeLbl.Size = new System.Drawing.Size(35, 12);
            this.newColTypeLbl.TabIndex = 5;
            this.newColTypeLbl.Text = "类型:";
            // 
            // addColToAtt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 232);
            this.Controls.Add(this.newColTypeLbl);
            this.Controls.Add(this.newColNameLbl);
            this.Controls.Add(this.newTypeCBox);
            this.Controls.Add(this.addNewColTBox);
            this.Controls.Add(this.btnNewColCancel);
            this.Controls.Add(this.btnNewColOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addColToAtt";
            this.ShowInTaskbar = false;
            this.Text = "增加列";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewColOK;
        private System.Windows.Forms.Button btnNewColCancel;
        private System.Windows.Forms.TextBox addNewColTBox;
        private System.Windows.Forms.ComboBox newTypeCBox;
        private System.Windows.Forms.Label newColNameLbl;
        private System.Windows.Forms.Label newColTypeLbl;
    }
}