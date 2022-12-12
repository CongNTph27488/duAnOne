using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.dal.Table
{
    [Table("LoaiSanPham")]
    public class LoaiSanPham
    {
        [Key]
        public Guid id { get; set; }
        [StringLength(20)]
        public string ma { get; set; }
        [StringLength(50)]
        public string ten { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
