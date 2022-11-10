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
    public partial class frmChucVu : Form
    {
        private iChucVuSer iCvSer;
        Guid idClick;
        public frmChucVu()
        {
            InitializeComponent();
            iCvSer = new ChucVuSer();
            LoadData(null);
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text)) return;
            txtMa.Text = Utility.ZenMaTuDong(txtTen.Text) + iCvSer.GetAllCv().Count;
        }

        private void txtTen_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text)) return;
            txtTen.Text = Utility.VietHoaFullName(txtTen.Text);
        }
        public void LoadData(string input)
        {
            int stt=1;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "stt";
            dataGridView1.Columns[1].Name = "id";
            dataGridView1.Columns[2].Name = "ma";
            dataGridView1.Columns[3].Name = "ten";
            dataGridView1.Rows.Clear();
            foreach(var x in iCvSer.GetAllCv())
            {
                dataGridView1.Rows.Add(stt++,x.id,x.ma,x.ten);
            }
        }
        public ChucVuView GetData()
        {
            return new ChucVuView()
            {
                id = Guid.Empty,
                ma = txtMa.Text,
                ten = txtTen.Text,
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlog = MessageBox.Show("?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (string.IsNullOrEmpty(txtMa.Text)) return;
            if (string.IsNullOrEmpty(txtTen.Text)) return;
            MessageBox.Show(iCvSer.Add(GetData()));
            LoadData(null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dlog = MessageBox.Show("?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            var temp = GetData();
            temp.id = idClick;
            temp.ma = txtMa.Text;
            temp.ten = txtTen.Text;
            MessageBox.Show(iCvSer.Update(temp));
            LoadData(null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlog = MessageBox.Show("?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            var temp = GetData();
            temp.id = idClick;
            MessageBox.Show(iCvSer.Delete(temp));
            LoadData(null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex=e.RowIndex;
            if (e.RowIndex == -1) return;
            if (rowIndex == iCvSer.GetAllCv().Count) return;
            idClick = Guid.Parse(dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());   
            var temp=iCvSer.GetAllCv().FirstOrDefault(c=>c.id==idClick);
            txtMa.Text = temp.ma;
            txtTen.Text = temp.ten;
        }

        private void txtMa_Leave(object sender, EventArgs e)
        {
            //if(string.IsNullOrEmpty(txtMa.Text)) return;
            //txtMa.Text=Utility.ZenMaTuDong(txtTen.Text)+iCvSer.GetAllCv().Count;
        }
    }
}
