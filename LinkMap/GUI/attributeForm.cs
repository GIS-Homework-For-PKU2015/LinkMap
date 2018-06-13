using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkMap.GUI {
    public partial class attributeForm : Form {
        public attributeForm () {
            InitializeComponent();
        }
        public DataGridView aDataGridView {
            get {
                return this.attDataGridView;
            }
            set {
                this.attDataGridView = value;
            }
        }
        public void SetDGVsource (DataTable dt) {
            this.attDataGridView.DataSource = dt;
        }
        

        private void attributeForm_Load (object sender, EventArgs e) {

        }
    }
}
