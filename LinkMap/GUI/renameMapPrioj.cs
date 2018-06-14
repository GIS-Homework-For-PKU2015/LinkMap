using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkMap.GUI {
    public partial class renameMapPrioj : Form {
        private string _name;
        public renameMapPrioj () {
            InitializeComponent();
        }
        public string Rname {
            get {
                return this.renameTextBox.Text;
            }
            set {
                _name = value;
                this.renameTextBox.Text = _name;
            }
        }
        private void btnOKrename_Click (object sender, EventArgs e) {
            _name = this.renameTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void renameMapPrioj_Load (object sender, EventArgs e) {

        }

        private void btnCrename_Click (object sender, EventArgs e) {
            this.Close();
        }
    }
}
