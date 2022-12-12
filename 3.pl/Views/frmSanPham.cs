using _2.bus.IServices;
using _2.bus.Services;
using _2.bus.ViewModel;
using _3.pl.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace _3.pl.Views
{
    public partial class frmSanPham : Form
    {
        private iSanPhamSer spSer;
        private iLoaiSanPhamSer lspSer;
        private frmBanHang frmBh;
        Guid idClick;
        public frmSanPham()
        {
            InitializeComponent();
            spSer = new SanPhamSer();
            lspSer = new LoaiSanPhamSer();
            frmBh=new frmBanHang();
            LoadData(null);
            LoadLsp();
        }

        public void LoadLsp()
        {
            foreach(var x in lspSer.GetAllLsp())
            {
                cmbLoaiSp.Items.Add(x.ten);
            }
            cmbLoaiSp.SelectedIndex = 0;
        }
        public void LoadData(string input)
        {
            int stt = 1;
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "stt";
            dataGridView1.Columns[1].Name = "idSp";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Name = "maSp";
            dataGridView1.Columns[3].Name = "tenSp";
            dataGridView1.Columns[4].Name = "giaBan";
            dataGridView1.Columns[5].Name = "tenLsp";
            dataGridView1.Rows.Clear();
            foreach (var x in spSer.GetAllSp(input))
            {
                dataGridView1.Rows.Add(stt++, x.id, x.ma, x.ten,x.giaBan,x.tenLsp);
            }
        }

        public SanPhamView GetData()
        {
            return new SanPhamView()
            {
                id = Guid.NewGuid(),
                ma = txtMaSp.Text,
                ten = txtTenSp.Text,
                giaBan = Convert.ToDecimal(txtGiaBan.Text),
                tenLsp = cmbLoaiSp.Text,
                idLsp = lspSer.GetAllLsp()[cmbLoaiSp.SelectedIndex].id,
            };
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.RowIndex == -1) return;
            if (rowIndex == spSer.GetAllSp().Count) return;
            idClick = Guid.Parse(dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
            var temp = spSer.GetAllSp().FirstOrDefault(c => c.id == idClick);
            txtMaSp.Text = temp.ma;
            txtTenSp.Text = temp.ten;
            txtGiaBan.Text = Convert.ToString(temp.giaBan);
            cmbLoaiSp.Text = temp.tenLsp;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(spSer.Add(GetData()));
            LoadData(null);
            txtMaSp.Text = null;
            txtTenSp.Text = null;
            txtGiaBan.Text = null;
            txtSearch.Text = null;
            cmbLoaiSp.Text = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var temp = GetData(); 
            temp.id = idClick;
            temp.ma = txtMaSp.Text;
            temp.ten = txtTenSp.Text;
            temp.giaBan = Convert.ToDecimal(txtGiaBan.Text);
            temp.tenLsp = cmbLoaiSp.Text;
            MessageBox.Show(spSer.Update(temp));
            LoadData(null);
            txtMaSp.Text = null;
            txtTenSp.Text = null;
            txtGiaBan.Text = null;
            txtSearch.Text = null;
            cmbLoaiSp.Text = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var temp = GetData(); 
            temp.id = idClick;
            MessageBox.Show(spSer.Delete(temp));
            LoadData(null);
            txtMaSp.Text = null;
            txtTenSp.Text = null;
            txtGiaBan.Text = null;
            txtSearch.Text = null;
            cmbLoaiSp.Text = null;
        }

        private void txtTenSp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSp.Text)) return;
            txtTenSp.Text = Utility.VietHoaFullName(txtTenSp.Text);
        }

        private void txtTenSp_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSp.Text)) return;
            txtMaSp.Text = Utility.ZenMaTuDong(txtTenSp.Text) + lspSer.GetAllLsp().Count;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = "tim kiem";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text)) return;
            LoadData(txtSearch.Text);
        }

        private void btnLoaiSp_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham frmLsp = new frmLoaiSanPham();
            frmLsp.Show();
        }
    }
}
