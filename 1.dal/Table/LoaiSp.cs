using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.dal.Table
{
    [Table("LoaiSp")]
    public class LoaiSp
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
