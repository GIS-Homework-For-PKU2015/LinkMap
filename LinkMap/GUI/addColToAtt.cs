using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*编辑属性表功能中增加列的弹出框
 * 
 * 
 * */
namespace LinkMap.GUI {
    public partial class addColToAtt : Form {
        private string _newColName="newCol1";
        private string _colType;
        public addColToAtt () {
            InitializeComponent();
        }
        public string AddColName {
            get {
                return _newColName;
            }
        }
        public string AddType {
            get {
                return _colType;
            }
        }
        //确定
        private void btnNewColOK_Click (object sender, EventArgs e) {
            _newColName = this.addNewColTBox.Text;
            _colType = this.newTypeCBox.Text;

            this.DialogResult = DialogResult.OK;
        }
        //取消
        private void btnNewColCancel_Click (object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            //this.Close();
        }
    }
}
