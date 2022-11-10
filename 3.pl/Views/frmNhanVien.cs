using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3.pl.Utilities;
using _2.bus.iServices;
using _2.bus.Services;
using _1.dal.Table;
using _2.bus.ViewModels;

namespace _3.pl.Views
{
    public partial class frmNhanVien : Form
    {
        private iNhanVienSer iNvSer;
        private iCuaHangSer iChSer;
        private iChucVuSer iCvSer;
        public frmNhanVien()
        {
            InitializeComponent();
            iNvSer = new NhanVienSer();
            iChSer = new CuaHangSer();
            iCvSer = new ChucVuSer();
            rbtnNam.Checked = true;
            rbtnOn.Checked = true;
            LoadComboBox();
            LoadData(null);
        }
        public void LoadComboBox()
        {
            foreach (var item in iCvSer.GetAllCv())
            {
                cmbChucVu.Items.Add(item.ten);
            }
            cmbChucVu.SelectedIndex = 0;
            foreach (var item in iChSer.GetAllCh())
            {
                cmbCuaHang.Items.Add(item.ten);
            }
            cmbChucVu.SelectedIndex = 0;

            foreach (var item in iNvSer.lstThanhPho())
            {
                cmbThanhPho.Items.Add(item);
            }
            cmbThanhPho.SelectedIndex = 0;
            foreach(var item in iNvSer.lstQuocGia())
            {
                cmbQuocGia.Items.Add(item);
            }
            cmbQuocGia.SelectedIndex = 0;
        }
        public void LoadData(string input)
        {
            int stt = 1;
            dataGridView1.ColumnCount = 13;
            dataGridView1.Columns[0].Name = "stt";
            dataGridView1.Columns[1].Name = "id";
            dataGridView1.Columns[2].Name = "ma";
            dataGridView1.Columns[3].Name = "ho va ten";
            dataGridView1.Columns[4].Name = "ng sinh";
            dataGridView1.Columns[5].Name = "gioi tinh";
            dataGridView1.Columns[6].Name = "sdt";
            dataGridView1.Columns[7].Name = "chuc vu";
            dataGridView1.Columns[8].Name = "dia chi";
            dataGridView1.Columns[9].Name = "thanh pho";
            dataGridView1.Columns[10].Name = "quoc gia";
            dataGridView1.Columns[11].Name = "trang thai";
            dataGridView1.Columns[12].Name = "cua hang";
            dataGridView1.Rows.Clear();
            foreach(var x in iNvSer.GetAllNv())
            {
                dataGridView1.Rows.Add(stt++,x.nv.id,x.nv.ma,x.nv.ho+" "+x.nv.tenDem+" "+x.nv.ten,x.nv.ngSinh,x.nv.gioiTinh=="Nam"?"Nam":"Nu",x.nv.sdt,x.cv.ten,x.nv.diaChi,x.nv.thanhPho,x.nv.quocGia,x.nv.trangThai==0?"On":"Off",x.ch.ten);
            }
        }
        public NhanVienView GetData()
        {
            return new NhanVienView()
            {
                id = Guid.Empty,
                ma = txtMa.Text,
                ho = txtHo.Text,
                tenDem = txtTenDem.Text,
                ten = txtTen.Text,
                ngSinh = dtmNgSinh.Value,
                gioiTinh = rbtnNam.Checked?"Nam":"Nu",
                sdt = txtSdt.Text,
                idCv = iCvSer.GetAllCv()[cmbChucVu.SelectedIndex].id,
                diaChi = txtDiaChi.Text,
                thanhPho = cmbThanhPho.Text,
                quocGia = cmbQuocGia.Text,
                trangThai = rbtnOn.Checked?1:0,
                idCh = iChSer.GetAllCh()[cmbCuaHang.SelectedIndex].id,
            };
        }

        private void txtHo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHo.Text)) return;
            txtHo.Text=Utility.VietHoaFullName(txtHo.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlog = MessageBox.Show("?","confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            MessageBox.Show(iNvSer.Add(GetData()));
            LoadData(null);
        }

        private void txtTenDem_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenDem.Text)) return;
            txtTenDem.Text = Utility.VietHoaFullName(txtTenDem.Text);
        }

        private void txtTen_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text)) return;
            txtTen.Text = Utility.VietHoaFullName(txtTen.Text);
        }

        private void txtHo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            frmChucVu frmCv = new frmChucVu();
            frmCv.Show();
            this.Hide();
        }

        private void btnCuaHang_Click(object sender, EventArgs e)
        {
            frmCuaHang frmCh = new frmCuaHang();
            frmCh.Show();
            this.Hide();
        }
    }
}
