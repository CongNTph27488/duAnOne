using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [InverseProperty(nameof(LoaiSp.SanPhams))]
        public LoaiSp loaiSps { get; set; }

        [StringLength(20)]
        public string ma { get; set; }
        [StringLength(50)]
        public string ten { get; set; }
        public decimal giaBan { get; set; }

        public ICollection<GioHangCt> GioHangCts { get; set; }
        public ICollection<HoaDonCt> HoaDonCts { get; set; }
    }
}
