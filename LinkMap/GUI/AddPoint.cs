using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkMap
{
    public partial class AddPoint : Form
    {
        private double _ix;
        private double _iy;

        public double X {
            get {
                return _ix;
            }
        }
        public double Y {
            get {
                return _iy;
            }
        }

        public AddPoint()
        {
            InitializeComponent();
        }

        private void button1_Click (object sender, EventArgs e) {
            XYtoIxy();
            this.DialogResult = DialogResult.OK;
        }

        private void AddPoint_Load (object sender, EventArgs e) {
            XYtoIxy();
            
        }
        private void XYtoIxy () {
            try {
                _ix = Convert.ToDouble(this.XTextBox.Text);
                _iy = Convert.ToDouble(this.YTextBox.Text);
            }
            catch (Exception exp) {
                MessageBox.Show("请确认输入为数字！\n" + exp.ToString());
            }
        }
    }
}
