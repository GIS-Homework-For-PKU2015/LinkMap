using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkMap.GUI
{
    public partial class ValueRanderer : Form
    {
        public ValueRanderer()
        {
            InitializeComponent();
        }

        public int valueindex = 1;

        private void button1_Click(object sender, EventArgs e)
        {
                    valueindex = int.Parse(textBox1.Text);
            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
