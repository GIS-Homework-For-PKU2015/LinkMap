namespace LinkMap
{
    partial class Identity
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
            this.label2 = new System.Windows.Forms.Label();
            this.Xvalue = new System.Windows.Forms.Label();
            this.Yvalue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Long = new System.Windows.Forms.Label();
            this.面积 = new System.Windows.Forms.Label();
            this.Area = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FeatureType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Y坐标";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "X坐标";
            // 
            // Xvalue
            // 
            this.Xvalue.AutoSize = true;
            this.Xvalue.Location = new System.Drawing.Point(248, 112);
            this.Xvalue.Name = "Xvalue";
            this.Xvalue.Size = new System.Drawing.Size(166, 24);
            this.Xvalue.TabIndex = 2;
            this.Xvalue.Text = "X坐标（实例）";
            // 
            // Yvalue
            // 
            this.Yvalue.AutoSize = true;
            this.Yvalue.Location = new System.Drawing.Point(248, 160);
            this.Yvalue.Name = "Yvalue";
            this.Yvalue.Size = new System.Drawing.Size(166, 24);
            this.Yvalue.TabIndex = 3;
            this.Yvalue.Text = "Y坐标（实例）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "长度";
            // 
            // Long
            // 
            this.Long.AutoSize = true;
            this.Long.Location = new System.Drawing.Point(248, 216);
            this.Long.Name = "Long";
            this.Long.Size = new System.Drawing.Size(154, 24);
            this.Long.TabIndex = 5;
            this.Long.Text = "长度（实例）";
            // 
            // 面积
            // 
            this.面积.AutoSize = true;
            this.面积.Location = new System.Drawing.Point(104, 264);
            this.面积.Name = "面积";
            this.面积.Size = new System.Drawing.Size(58, 24);
            this.面积.TabIndex = 6;
            this.面积.Text = "面积";
            // 
            // Area
            // 
            this.Area.AutoSize = true;
            this.Area.Location = new System.Drawing.Point(248, 264);
            this.Area.Name = "Area";
            this.Area.Size = new System.Drawing.Size(154, 24);
            this.Area.TabIndex = 7;
            this.Area.Text = "面积（实例）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "要素类型";
            // 
            // FeatureType
            // 
            this.FeatureType.AutoSize = true;
            this.FeatureType.Location = new System.Drawing.Point(248, 312);
            this.FeatureType.Name = "FeatureType";
            this.FeatureType.Size = new System.Drawing.Size(202, 24);
            this.FeatureType.TabIndex = 9;
            this.FeatureType.Text = "要素类型（实例）";
            // 
            // Identity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 500);
            this.Controls.Add(this.FeatureType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Area);
            this.Controls.Add(this.面积);
            this.Controls.Add(this.Long);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Yvalue);
            this.Controls.Add(this.Xvalue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Identity";
            this.Text = "Identity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Xvalue;
        private System.Windows.Forms.Label Yvalue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Long;
        private System.Windows.Forms.Label 面积;
        private System.Windows.Forms.Label Area;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label FeatureType;
    }
}