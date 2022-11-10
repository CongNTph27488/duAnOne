using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;

namespace _2.bus.ViewModels
{
    public class GioHangView
    {
        public GioHang gh { get; set; }
        public NhanVien nv { get; set; }
        public Guid id { get; set; }
        public Guid idNv { get; set; }
        public string ma { get; set; }
        public DateTime ngTao { get; set; }
        public DateTime ngThanhToan { get; set; }
        public int tinhTrang { get; set; }
        //Nhan Vien
        public CuaHang ch { get; set; }
        public ChucVu cv { get; set; }
        public Guid idCh { get; set; }
        public Guid idCv { get; set; }
        public string maNv{ get; set; }
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
    }
}
