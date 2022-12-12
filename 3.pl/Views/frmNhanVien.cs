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


namespace _3.pl.Views
{
    public partial class frmNhanVien : Form
    {
        private iChucVuSer cvSer;
        private iNhanVienSer nvSer;
        Guid idClick;
        public frmNhanVien()
        {
            InitializeComponent();
            cvSer = new ChucVuSer();
            nvSer = new NhanVienSer();
            //rbtnNam.Checked=true;
            //rbtnDangLam.Checked = true;
            LoadData(null);
            LoadChucVu();
        }

        public void LoadChucVu()
        {
            foreach (var x in cvSer.GetAllCv())
            {
                cmbChucVu.Items.Add(x.ten);
            }
            cmbChucVu.SelectedIndex = 0;
        }
        public void LoadData(string input)
        {
            int stt = 1;
            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[0].Name = "stt";
            dataGridView1.Columns[1].Name = "id";
            dataGridView1.Columns[1].Visible=false;
            dataGridView1.Columns[2].Name = "maNv";
            dataGridView1.Columns[3].Name = "ho va ten";
            dataGridView1.Columns[4].Name = "ngSinh";
            dataGridView1.Columns[5].Name = "gioiTinh";
            dataGridView1.Columns[6].Name = "sdt";
            dataGridView1.Columns[7].Name = "diaChi";
            dataGridView1.Columns[8].Name = "thanhPho";
            dataGridView1.Columns[9].Name = "quocGia";
            dataGridView1.Columns[10].Name = "chucVu";
            dataGridView1.Columns[11].Name = "trangThai";
            dataGridView1.Rows.Clear();
            foreach (var x in nvSer.GetAllNv(input))
            {
                dataGridView1.Rows.Add(stt++, x.id, x.ma, x.ho + " " + x.tenDem + " " + x.ten, x.ngSinh, (x.gioiTinh == "Nam" ? "Nam" : "Nu"), x.sdt, x.diaChi, x.thanhPho, x.quocGia, x.tenCv, x.trangThai == 0 ? "Danglam" : "Nghi");
            }
        }
        public NhanVienView GetData()
        {
            return new NhanVienView()
            {
                id = Guid.NewGuid(),
                ma = txtMaNv.Text,
                ho = txtHoNv.Text,
                tenDem = txtTenDemNv.Text,
                ten = txtTenDemNv.Text,
                ngSinh = dtNgSinh.Value,
                gioiTinh = rbtnNam.Checked ? "Nam" : "Nu",
                sdt = txtSdt.Text,
                diaChi = txtDiaChi.Text,
                thanhPho = txtThanhPho.Text,
                quocGia = txtQuocGia.Text,
                tenCv = cmbChucVu.Text,
                trangThai = rbtnDangLam.Checked ? 1 : 0,
                idCv = cvSer.GetAllCv()[cmbChucVu.SelectedIndex].id,
            };
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.RowIndex == -1) return;
            if (rowIndex == nvSer.GetAllNv().Count) return;
            idClick = Guid.Parse(dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
            var temp = nvSer.GetAllNv().FirstOrDefault(c=>c.id==idClick);
            txtMaNv.Text = temp.ma;
            txtHoNv.Text = temp.ho;
            txtTenDemNv.Text = temp.tenDem;
            txtTenNv.Text = temp.ten;
            dtNgSinh.Value = temp.ngSinh;

            if (temp.gioiTinh == "Nam")
            {
                rbtnNam.Checked = true;
            }
            else
            {
                rbtnNu.Checked = true;
            };

            txtSdt.Text = temp.sdt;

            //if (temp.sdt.Length >= 10||temp.sdt.StartsWith()!=0) 
            //{ 
            //    return; 
            //}

            txtDiaChi.Text = temp.diaChi;
            txtThanhPho.Text = temp.thanhPho;
            txtQuocGia.Text = temp.quocGia;
            cmbChucVu.Text = temp.tenCv;

            if (temp.trangThai == 07)
            {
                rbtnDangLam.Checked = true;
            }
            else
            {
                rbtnNghiViec.Checked = true;
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nvSer.Add(GetData()));
            LoadData(null);
            txtMaNv.Text = null;
            txtHoNv.Text = null;
            txtTenDemNv.Text = null;
            txtTenNv.Text = null;
            dtNgSinh.Value = DateTime.Today;
            //temp.gioiTinh = rbtnNam.;
            txtSdt.Text = null;
            txtDiaChi.Text = null;
            txtThanhPho.Text = null;
            txtQuocGia.Text = null;
            cmbChucVu.Text = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var temp = GetData();
            temp.id = idClick;
            temp.ma = txtMaNv.Text;
            temp.ho = txtHoNv.Text;
            temp.tenDem = txtTenDemNv.Text;
            temp.ten = txtTenNv.Text;
            temp.ngSinh = dtNgSinh.Value;
            //temp.gioiTinh = rbtnNam.Checked;
            temp.sdt = txtSdt.Text;
            temp.diaChi = txtDiaChi.Text;
            temp.thanhPho = txtThanhPho.Text;
            temp.quocGia = txtQuocGia.Text;
            temp.tenCv = cmbChucVu.Text;
            MessageBox.Show(nvSer.Update(temp));
            LoadData(null);
            txtMaNv.Text = null;
            txtHoNv.Text = null;
            txtTenDemNv.Text = null;
            txtTenNv.Text = null;
            dtNgSinh.Value = DateTime.Today;
            //temp.gioiTinh = rbtnNam.;
            txtSdt.Text = null;
            txtDiaChi.Text = null;
            txtThanhPho.Text = null;
            txtQuocGia.Text = null;
            cmbChucVu.Text = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var temp = GetData();
            temp.id = idClick;
            MessageBox.Show(nvSer.Delete(temp));
            LoadData(null);
            txtMaNv.Text = null;
            txtHoNv.Text = null;
            txtTenDemNv.Text = null;
            txtTenNv.Text = null;
            dtNgSinh.Value = DateTime.Today;
            //temp.gioiTinh = rbtnNam.;
            txtSdt.Text = null;
            txtDiaChi.Text = null;
            txtThanhPho.Text = null;
            txtQuocGia.Text = null;
            cmbChucVu.Text = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaNv.Text = null;
            txtHoNv.Text = null;
            txtTenDemNv.Text = null;
            txtTenNv.Text = null;
            dtNgSinh.Value = DateTime.Today;
            //temp.gioiTinh = rbtnNam.;
            txtSdt.Text = null;
            txtDiaChi.Text = null;
            txtThanhPho.Text = null;
            txtQuocGia.Text = null;
            cmbChucVu.Text = null;
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            frmChucVu frmCv = new frmChucVu();
            frmCv.ShowDialog();
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
            if (string.IsNullOrEmpty(txtSearch.Text)) return;
            LoadData(txtSearch.Text);
        }
    }
}
