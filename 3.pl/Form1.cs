using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3.pl.Views;

namespace _3.pl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lbChucVu_Click(object sender, EventArgs e)
        {
            frmChucVu frmCv = new frmChucVu();
            frmCv.Show();
            this.Hide();
        }

        private void lbLoaiSp_Click(object sender, EventArgs e)
        {
            frmLoaiSanPham frmLsp = new frmLoaiSanPham();
            frmLsp.Show();
            this.Hide();
        }

        private void lbNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNv = new frmNhanVien();
            frmNv.Show();
            this.Hide();
        }

        private void lbBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang frmBh=new frmBanHang();
            frmBh.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void qlSp_Click(object sender, EventArgs e)
        {
            frmSanPham frmSp = new frmSanPham();
            frmSp.ShowDialog();
        }
    }
}
