using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.dal.Table
{
    [Table ("GioHangCt")]
    public class GioHangCt
    {
        [Key]
        public Guid id { get; set; }
        [Required]

        public Guid idGh { get; set; }        
        [ForeignKey(nameof(idGh))]
        [InverseProperty(nameof(GioHang.GioHangCts))]
        public GioHang gioHangs { get; set; }

        public Guid idSp { get; set; }
        [ForeignKey(nameof(idSp))]
        [InverseProperty (nameof(SanPham.GioHangCts))]
        public SanPham sanPhams { get; set; }

        public int soLuong { get; set; }
        public decimal thanhTien { get; set; }
    }
}
