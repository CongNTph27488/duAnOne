using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.dal.Table
{
    [Table("HoaDonChiTiet")]
    public class HoaDonChiTiet
    {
        [Key]
        public Guid id { get; set; }
        [Required]

        public Guid idHd { get; set; }
        [ForeignKey(nameof(idHd))]
        [InverseProperty(nameof(HoaDon.HoaDonCts))]
        public HoaDon hoaDons { get; set; }

        public Guid idSp { get; set; }
        [ForeignKey(nameof(idSp))]
        [InverseProperty(nameof(SanPham.HoaDonCts))]
        public SanPham sanPhams { get; set; }

        public int soLuong { get; set; }
        public decimal thanhTien { get; set; }
    }
}
