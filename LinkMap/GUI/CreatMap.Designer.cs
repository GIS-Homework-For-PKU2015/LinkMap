namespace LinkMap
{
    partial class CreatMap
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MapWidthBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.MapLengthBox = new System.Windows.Forms.TextBox();
            this.MapSacleTextBox = new System.Windows.Forms.TextBox();
            this.MapNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOKnewMap = new System.Windows.Forms.Button();
            this.btnCnewMap = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.MapWidthBox);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.MapLengthBox);
            this.groupBox1.Controls.Add(this.MapSacleTextBox);
            this.groupBox1.Controls.Add(this.MapNameTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(260, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新建地图";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 112);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 16);
            this.button1.TabIndex = 11;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 140);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 21);
            this.textBox1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "地图描述";
            // 
            // MapWidthBox
            // 
            this.MapWidthBox.Location = new System.Drawing.Point(180, 84);
            this.MapWidthBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MapWidthBox.Name = "MapWidthBox";
            this.MapWidthBox.Size = new System.Drawing.Size(62, 21);
            this.MapWidthBox.TabIndex = 8;
            this.MapWidthBox.Text = "600";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 112);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(94, 21);
            this.textBox2.TabIndex = 7;
            // 
            // MapLengthBox
            // 
            this.MapLengthBox.Location = new System.Drawing.Point(112, 84);
            this.MapLengthBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MapLengthBox.Name = "MapLengthBox";
            this.MapLengthBox.Size = new System.Drawing.Size(62, 21);
            this.MapLengthBox.TabIndex = 6;
            this.MapLengthBox.Text = "800";
            // 
            // MapSacleTextBox
            // 
            this.MapSacleTextBox.Location = new System.Drawing.Point(112, 56);
            this.MapSacleTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MapSacleTextBox.Name = "MapSacleTextBox";
            this.MapSacleTextBox.Size = new System.Drawing.Size(130, 21);
            this.MapSacleTextBox.TabIndex = 5;
            this.MapSacleTextBox.Text = "1:1";
            // 
            // MapNameTextBox
            // 
            this.MapNameTextBox.Location = new System.Drawing.Point(112, 28);
            this.MapNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MapNameTextBox.Name = "MapNameTextBox";
            this.MapNameTextBox.Size = new System.Drawing.Size(130, 21);
            this.MapNameTextBox.TabIndex = 4;
            this.MapNameTextBox.Text = "默认工程";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 112);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "存储路径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "地图大小";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "地图比例尺";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地图名称";
            // 
            // btnOKnewMap
            // 
            this.btnOKnewMap.Location = new System.Drawing.Point(50, 209);
            this.btnOKnewMap.Name = "btnOKnewMap";
            this.btnOKnewMap.Size = new System.Drawing.Size(75, 23);
            this.btnOKnewMap.TabIndex = 1;
            this.btnOKnewMap.Text = "确认";
            this.btnOKnewMap.UseVisualStyleBackColor = true;
            this.btnOKnewMap.Click += new System.EventHandler(this.btnOKnewMap_Click);
            // 
            // btnCnewMap
            // 
            this.btnCnewMap.Location = new System.Drawing.Point(173, 209);
            this.btnCnewMap.Name = "btnCnewMap";
            this.btnCnewMap.Size = new System.Drawing.Size(75, 23);
            this.btnCnewMap.TabIndex = 2;
            this.btnCnewMap.Text = "取消";
            this.btnCnewMap.UseVisualStyleBackColor = true;
            this.btnCnewMap.Click += new System.EventHandler(this.btnCnewMap_Click);
            // 
            // CreatMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 249);
            this.Controls.Add(this.btnCnewMap);
            this.Controls.Add(this.btnOKnewMap);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CreatMap";
            this.Text = "CreatMap";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MapWidthBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox MapLengthBox;
        private System.Windows.Forms.TextBox MapSacleTextBox;
        private System.Windows.Forms.TextBox MapNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOKnewMap;
        private System.Windows.Forms.Button btnCnewMap;
    }
}