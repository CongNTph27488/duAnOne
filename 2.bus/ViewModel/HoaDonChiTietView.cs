using System;
using System.Collections.Generic;
using System.Text;
using _1.dal.Table;

namespace _2.bus.ViewModel
{
    public class HoaDonChiTietView
    {
        public HoaDonChiTiet hdCt { get; set; }
        public Guid id { get; set; }
        public int soLuong { get; set; }
        public decimal thanhTien { get; set; }

        public HoaDon hd { get; set; }
        public Guid? idHd { get; set; }
        public string maHd { get; set; }
        public DateTime ngTaoHd { get; set; }
        public DateTime ngThanhToanHd { get; set; }

        public NhanVien nv { get; set; }
        public Guid? idNv { get; set; }

        public SanPham sp { get; set; }
        public Guid? idSp { get; set; }
        public string maSp { get; set; }
        public string tenSp { get; set; }
        public decimal giaBan { get; set; }

        public LoaiSanPham lsp { get; set; }
        public Guid? idLsp { get; set; }
    }
}
