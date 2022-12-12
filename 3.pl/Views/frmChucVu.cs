using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using _1.dal.Table;
using _2.bus.IServices;
using _2.bus.Services;
using _2.bus.ViewModel;
using _3.pl.Utilities;

namespace _3.pl.Views
{
    public partial class frmChucVu : Form
    {
        private iChucVuSer cvSer;
        Guid idClick;
        public frmChucVu()
        {
            InitializeComponent();
            cvSer = new ChucVuSer();
            LoadData(null);
        }
        public void LoadData(string input)
        {
            int stt = 1;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name="stt";
            dataGridView1.Columns[1].Name="idCv";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Name="maCv";
            dataGridView1.Columns[3].Name="tenCv";
            dataGridView1.Rows.Clear();
            foreach(var x in cvSer.GetAllCv(input))
            {
                dataGridView1.Rows.Add(stt++, x.id, x.ma, x.ten);
            }
        }
        public ChucVuView GetData()
        {
            return new ChucVuView()
            {
                id = Guid.NewGuid(),
                ma = txtMaCv.Text,
                ten = txtTenCv.Text,
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cvSer.Add(GetData()));
            LoadData(null);
            txtMaCv.Text = null;
            txtTenCv.Text = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var temp = GetData();
            temp.id = idClick;
            temp.ma = txtMaCv.Text;
            temp.ten = txtTenCv.Text;
            MessageBox.Show(cvSer.Update(temp));
            LoadData(null);
            txtMaCv.Text = null;
            txtTenCv.Text = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var temp = GetData();
            temp.id = idClick;
            MessageBox.Show(cvSer.Delete(temp));
            LoadData(null);
            txtMaCv.Text = null;
            txtTenCv.Text = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int rowIndex=e.RowIndex;
            if (rowIndex == cvSer.GetAllCv().Count) return;
            idClick = Guid.Parse(dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
            var temp = cvSer.GetAllCv().FirstOrDefault(c => c.id == idClick);
            txtMaCv.Text = temp.ma;
            txtTenCv.Text = temp.ten;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text ="";
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = "tim kiem";
            LoadData(null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text)) return;
            LoadData(txtSearch.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaCv.Text = null;
            txtTenCv.Text = null;
            txtSearch.Text = null;
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            Application.Exit();
            //Form1 frmMain = new Form1();
            //frmMain.Hide();
        }

        private void txtTenCv_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenCv.Text)) return;
            txtTenCv.Text = Utility.VietHoaFullName(txtTenCv.Text);
        }

        private void txtTenCv_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenCv.Text)) return;
            txtMaCv.Text = Utility.ZenMaTuDong(txtTenCv.Text) + cvSer.GetAllCv().Count;
        }
    }
}
