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
    public partial class CreatMap : Form
    {
        private string _mapName="";
        private string _disc = "";
        private string _savePath = "";
        public CreatMap()
        {
            InitializeComponent();
        }
        public string mapName {
            get {
                return _mapName;
            }
            set {
                _mapName = value;
            }
        }
        public string Desc {
            get {
                return _disc;
            }
            set {
                _disc = value;
            }
        }
        public string SavePath {
            get {
                return _savePath;
            }
            set {
                _savePath = value;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //选择文件路径
        private void button1_Click (object sender, EventArgs e) {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter= "LinkMap工程文件(*.egis)|*.egis";

            if (sv.ShowDialog() == DialogResult.OK) {
                _savePath = sv.FileName;
                textBox2.Text = _savePath;
            }

        }

        private void btnOKnewMap_Click (object sender, EventArgs e) {
            _mapName = this.MapNameTextBox.Text;
            _disc = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCnewMap_Click (object sender, EventArgs e) {

        }
    }
}
