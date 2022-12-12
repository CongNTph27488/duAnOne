using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.dal.Table
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public Guid id { get; set; }
        [Required]

        public Guid idLsp { get; set; }
        [ForeignKey(nameof(idLsp))]
        [InverseProperty(nameof(LoaiSanPham.SanPhams))]
        public LoaiSanPham loaiSps { get; set; }

        [StringLength(20)]
        public string ma { get; set; }
        [StringLength(50)]
        public string ten { get; set; }
        public decimal giaBan { get; set; }

        //public ICollection<GioHangCt> GioHangCts { get; set; }
        public ICollection<HoaDonChiTiet> HoaDonCts { get; set; }
    }
}
