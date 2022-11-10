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
    public partial class frmCuaHang : Form
    {
        private iCuaHangSer iChSer;
        Guid idClick;
        public frmCuaHang()
        {
            InitializeComponent();
            iChSer = new CuaHangSer();
            
            LoadData(null);
        }
        public void LoadData(string input)
        {
            int stt = 1;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "stt";
            dataGridView1.Columns[1].Name = "id";
            dataGridView1.Columns[2].Name = "ma";
            dataGridView1.Columns[3].Name = "ten";
            dataGridView1.Rows.Clear();
            foreach(var item in iChSer.GetAllCh())
            {
                dataGridView1.Rows.Add(stt++, item.id, item.ma, item.ten);
            }
        }

        public CuaHangView GetData()
        {
            return new CuaHangView()
            {
                id = Guid.NewGuid(),
                ma = txtMa.Text,
                ten = txtTen.Text,
            };
        }

        private void txtTen_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text)) return;
            txtTen.Text=Utility.VietHoaFullName(txtTen.Text);
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text)) return;
            txtMa.Text=Utility.ZenMaTuDong(txtTen.Text)+iChSer.GetAllCh().Count;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(iChSer.Add(GetData()));
            LoadData(null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var temp = GetData();
            temp.id = idClick;
            temp.ma=txtMa.Text;
            temp.ten = txtTen.Text;
            MessageBox.Show(iChSer.Update(temp));
            LoadData(null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var temp = GetData();
            temp.id = idClick;
            MessageBox.Show(iChSer.Delete(temp));
            LoadData(null);
        }


    }
}
