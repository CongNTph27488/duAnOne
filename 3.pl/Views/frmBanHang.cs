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
    public partial class frmBanHang : Form
    {
        private iHoaDonSer hdSer;
        private iNhanVienSer nvSer;
        private iSanPhamSer spSer;
        private iHoaDonChiTietSer hdCtSer;
        List<HoaDonChiTietView> lst = new List<HoaDonChiTietView>();
        frmNhapDo frmNd;
        Guid idClick;

        public frmBanHang()
        {
            InitializeComponent();
            hdSer = new HoaDonSer();
            nvSer = new NhanVienSer();
            spSer = new SanPhamSer();
            hdCtSer = new HoaDonChiTietSer();
            frmNd = new frmNhapDo();
            LoadSp(null);
            LoadData(null);
        }

        public void LoadSp(string input)
        {
            int stt = 1;
            dgridLoadSp.ColumnCount = 6;
            dgridLoadSp.Columns[0].Name = "stt";
            dgridLoadSp.Columns[1].Name = "idSp";
            dgridLoadSp.Columns[1].Visible = false;
            dgridLoadSp.Columns[2].Name = "maSp";
            dgridLoadSp.Columns[3].Name = "tenSp";
            dgridLoadSp.Columns[4].Name = "giaBan";
            dgridLoadSp.Columns[5].Name = "tenLsp";
            dgridLoadSp.Rows.Clear();
            foreach (var x in spSer.GetAllSp(input))
            {
                dgridLoadSp.Rows.Add(stt++, x.id, x.ma, x.ten,x.giaBan, x.tenLsp);
            }
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
            foreach (var x in lst)
            {
                dataGridView1.Rows.Add(stt++, x.id, x.maSp, x.tenSp, x.soLuong, x.giaBan);
            }
            TinhTien();
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

        public void AddSanPham(Guid idClick)
        {
            var sp = spSer.GetAllSp().FirstOrDefault(c => c.id == idClick);
            var data = lst.FirstOrDefault(c => c.idSp == sp.id);
            if (data == null)
            {
                HoaDonChiTietView hdctView = new HoaDonChiTietView()
                {
                    idSp = sp.id,
                    maSp = sp.ma,
                    tenSp = sp.ten,
                    giaBan = sp.giaBan,
                    soLuong = 1,
                };
                lst.Add(hdctView);
            }
            else
            {
                data.soLuong++;
            }
            frmNd.LoadData(null);
        }

        private void dgridLoadSp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgridLoadSp.Rows[e.RowIndex];
                idClick = spSer.GetAllSp().FirstOrDefault(x => x.id == Guid.Parse(r.Cells[1].Value.ToString())).id;
                var obj = spSer.GetAllSp().FirstOrDefault(x => x.id == idClick);
                //if (obj.TrangThai == 1)
                //{
                //    MessageBox.Show("Sản phẩm đã nghỉ bán");
                //}
                //else
                //{

                AddSanPham(idClick);
                //}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData(null);
        }
    }
}
