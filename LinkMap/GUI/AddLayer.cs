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
    public partial class AddLayer : Form
    {
        public string LinkLayerName="";
        public string type;

        public AddLayer()
        {
            InitializeComponent();
            typebox.SelectedIndex = 0;
        }

        private void btnGetLayerName_Click(object sender, EventArgs e)
        {
            LinkLayerName=this.LinkLayerNameBox.Text;
            type = this.typebox.Text;
            this.Close();
        }


    }
}
