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
        public string layerType = "";
        public AddLayer()
        {
            InitializeComponent();
        }

        private void btnGetLayerName_Click(object sender, EventArgs e)
        {
            LinkLayerName=this.LinkLayerNameBox.Text;
            layerType = featypeCBox.Text;
            
            this.Close();
        }


    }
}
