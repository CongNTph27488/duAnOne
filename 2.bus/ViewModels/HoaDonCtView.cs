using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.dal.Table;

namespace _2.bus.ViewModels
{
    public class HoaDonCtView
    {
        public HoaDonCt hdCt { get; set; }
        public HoaDon hd { get; set; }
        public SanPham sp { get; set; }
        public Guid id { get; set; }
        public Guid idHd { get; set; }
        public Guid idSp { get; set; }
        public int soLuong { get; set; }
        public decimal thanhTien { get; set; }

        public NhanVien nv { get; set; }
        public Guid idNv { get; set; }
        public string ma { get; set; }
        public DateTime ngTao { get; set; }
        public DateTime ngThanhToan { get; set; }


    }
}
