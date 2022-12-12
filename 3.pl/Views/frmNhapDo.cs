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
    public partial class frmNhapDo : Form
    {
        private iHoaDonSer hdSer;
        private iNhanVienSer nvSer;
        private iSanPhamSer spSer;
        private iHoaDonChiTietSer hdCtSer;
        List<HoaDonChiTietView> lst;
        Guid idClick;
        public frmNhapDo()
        {
            InitializeComponent();
            hdSer = new HoaDonSer();
            nvSer = new NhanVienSer();
            spSer = new SanPhamSer();
            hdCtSer = new HoaDonChiTietSer();
            lst = new List<HoaDonChiTietView>();
        }

        public void LoadData(string input)
        {
            int stt = 1;
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "stt";
            dataGridView1.Columns[1].Name = "id";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Name = "maSp";
            dataGridView1.Columns[3].Name = "tenSp";
            dataGridView1.Columns[4].Name = "soLuong";
            dataGridView1.Columns[5].Name = "giaBan";
            dataGridView1.Rows.Clear();
            foreach(var x in lst)
            {
                dataGridView1.Rows.Add(stt++, x.id, x.maSp, x.tenSp, x.soLuong, x.giaBan);
            }
        }

        public void TinhTien()
        {
            if (lst != null)
            {
                int tien = 0;
                foreach (var item in lst)
                {
                    tien += Convert.ToInt32(item.giaBan) * item.soLuong;
                }
                txtTongTien.Text = tien.ToString() + "VNĐ";

            }
            else
            {
                txtTongTien.Text = "";
            }
        }
    }
}
