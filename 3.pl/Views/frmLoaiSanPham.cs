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
    public partial class frmLoaiSanPham : Form
    {
        private iLoaiSanPhamSer lspSer;
        Guid idClick;
        public frmLoaiSanPham()
        {
            InitializeComponent();
            lspSer = new LoaiSanPhamSer();
        }
        public void LoadData(string input)
        {
            int stt = 1;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "stt";
            dataGridView1.Columns[1].Name = "id";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Name = "maLsp";
            dataGridView1.Columns[3].Name = "tenLsp";
            dataGridView1.Rows.Clear();
            foreach(var x in lspSer.GetAllLsp(input))
            {
                dataGridView1.Rows.Add(stt++, x.id, x.ma, x.ten);
            }
        }
        public LoaiSanPhamView GetData()
        {
            return new LoaiSanPhamView()
            {
                id = Guid.NewGuid(),
                ma = txtMaLsp.Text,
                ten=txtTenLsp.Text,
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lspSer.Add(GetData()));
            LoadData(null);
            txtMaLsp.Text = null;
            txtTenLsp.Text = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var temp=GetData();
            temp.id = idClick;
            temp.ma = txtMaLsp.Text;
            temp.ten = txtTenLsp.Text;
            MessageBox.Show(lspSer.Update(temp));
            LoadData(null);
            txtMaLsp.Text = null;
            txtTenLsp.Text = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var temp = GetData();
            temp.id = idClick;
            MessageBox.Show(lspSer.Delete(temp));
            LoadData(null);
            txtMaLsp.Text = null;
            txtTenLsp.Text = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaLsp.Text = null;
            txtTenLsp.Text = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex=e.RowIndex;
            if (e.RowIndex == -1) return;
            if (rowIndex == lspSer.GetAllLsp().Count) return;
            idClick = Guid.Parse(dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
            var temp = lspSer.GetAllLsp().FirstOrDefault(c => c.id == idClick);
            txtMaLsp.Text = temp.ma;
            txtTenLsp.Text = temp.ten;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
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

        private void txtTenLsp_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLsp.Text)) return;
            txtMaLsp.Text = Utility.ZenMaTuDong(txtTenLsp.Text) + lspSer.GetAllLsp().Count;
        }

        private void txtTenLsp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLsp.Text)) return;
            txtTenLsp.Text = Utility.VietHoaFullName(txtTenLsp.Text);
        }
    }
}
