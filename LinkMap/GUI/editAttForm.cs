using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*编辑属性表的弹出窗体；
 * 总结：相关操作都要对数据源的DataTable _dt 进行操作，不要直接操作editDataGV.Columns等，因为这样更新不到_dt里
 * 
 * */
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
            
        }

        private void btnAddCol_Click (object sender, EventArgs e) {
            addColToAtt colNewForm = new addColToAtt();
            if (colNewForm.ShowDialog() == DialogResult.OK) {
                DataColumn dc = new DataColumn(colNewForm.AddColName);
                //目前不对列名是否和之前的重复进行判断；也就是说目前运行重复
                switch (colNewForm.AddType) {
                    case "String":
                        dc.DataType = typeof(string);
                        break;
                    case "Int":
                        dc.DataType = typeof(int);
                        break;
                    case "Date":
                        dc.DataType = typeof(DateTime);
                        break;
                    default:
                        dc.DataType = typeof(string);
                        break;
                }
                _dt.Columns.Add(dc);
                editDataGV.Refresh();
            }

            
             
        }

        private void btnDelCol_Click (object sender, EventArgs e) {
            _dt.Columns.RemoveAt(editDataGV.CurrentCell.ColumnIndex);
            //区分 _dt.Columns == editDataGV.DataSource.Columns != editDataGV.Columns 
            editDataGV.Refresh();
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
        //窗体关闭时，目前只有点击右上角的x一种关闭方式
        private void editAttForm_FormClosed (object sender, FormClosedEventArgs e) {
            this.DialogResult = DialogResult.OK;

        }
    }
}
