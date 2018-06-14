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
    public partial class Search : Form
    {
        private DataTable _innerDT;
        private string _sqlText = "id=5";
        public Search()
        {
            InitializeComponent();
        }
        public DataTable searchDT {
            set {
                _innerDT = value;
            }
        }
        private void btnDoSearch_Click (object sender, EventArgs e) {
            try {
                _sqlText = searchTBox.Text;
                DataRow[] drs = _innerDT.Select(_sqlText);
                DataTable dtw = new DataTable();
                foreach (DataColumn dc in _innerDT.Columns) {
                    dtw.Columns.Add(dc.ColumnName);
                }
                foreach (DataRow dr in drs) {
                    DataRow row = dtw.NewRow();
                    object[] olst = dr.ItemArray;
                    for (int i=0;i<olst.Length;i++) {
                        row[i] = Convert.ToString(olst[i]);
                    }
                    dtw.Rows.Add(row);
                }
                sqlDataGridView.DataSource = dtw;
            }
            catch (Exception exp) {
                
            }
        }
    }
}
