using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkMap.GUI {
    public partial class editAttForm : Form {
        DataTable _dt = new DataTable();
        DataTable _dtcopy = new DataTable();
        public editAttForm () {
            InitializeComponent();
        }

        public DataTable upDateDT () {
            return _dt;
        }

        public DataTable eafDT {
            get {
                return _dt;
            }
            set {
                _dt=value;
                _dtcopy = _dt.Copy();
                this.editDataGV.DataSource = _dt;
            }
        }

        private void referashDGV () {
            
        }

        private void btnAddRow_Click (object sender, EventArgs e) {
            this.editDataGV.Rows.Add();
        }

        private void btnDelRow_Click (object sender, EventArgs e) {
            foreach (DataGridViewRow row in editDataGV.SelectedRows) {
                editDataGV.Rows.Remove(row);
            }
        }

        private void btnAddCol_Click (object sender, EventArgs e) {
            editDataGV.Columns.Add("cname","whatcn");
            
        }

        private void btnDelCol_Click (object sender, EventArgs e) {
            foreach (DataGridViewColumn col in editDataGV.SelectedColumns) {
                editDataGV.Columns.Remove(col); ;
            }
        }

        private void btnSaveChange_Click (object sender, EventArgs e) {
            _dtcopy = _dt.Copy();
            
        }

        private void btnNotSave_Click (object sender, EventArgs e) {
            _dt = _dtcopy.Copy();
            editDataGV.DataSource = _dt;
            editDataGV.Refresh();
        }

        private void editAttForm_Load (object sender, EventArgs e) {
            this.btnAddRow.Visible = false;
            this.btnDelRow.Visible = false;
            this.btnAddRow.Enabled= false;
            this.btnDelRow.Enabled = false;

        }
    }
}
