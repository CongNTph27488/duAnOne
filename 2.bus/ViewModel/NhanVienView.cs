using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;

namespace _2.bus.ViewModel
{
    public class NhanVienView
    {
        public NhanVien nv { get; set; }
        public Guid id { get; set; }       
        public string ma { get; set; }
        public string ho { get; set; }
        public string tenDem { get; set; }
        public string ten { get; set; }
        public DateTime ngSinh { get; set; }
        public string gioiTinh { get; set; }
        public string sdt { get; set; }
        public string diaChi { get; set; }
        public string thanhPho { get; set; }
        public string quocGia { get; set; }
        public DateTime ngVaoLam { get; set; }
        public int caLam { get; set; }
        public int soGioLam { get; set; }
        public int trangThai { get; set; }

        public ChucVu cv { get; set; }
        public Guid? idCv { get; set; }
        public string maCv { get; set; }
        public string tenCv { get; set; }
    }
}
