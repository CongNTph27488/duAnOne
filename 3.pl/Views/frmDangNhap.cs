using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.pl.Views
{
    public partial class frmDangNhap : Form
    {
        string taiKhoan = "congdz";
        string matKhau = "1";
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (checkLog(txtTaiKhoan.Text, txtMatKhau.Text))
            {
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }            
        }
        public bool checkLog(string taiKhoan,string matKhau)
        {
            if(taiKhoan== this.taiKhoan && matKhau == this.matKhau)
            {
                return true;
            }
            else
            {
                MessageBox.Show("lỗi");
                txtTaiKhoan.Focus();
                return false;
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
