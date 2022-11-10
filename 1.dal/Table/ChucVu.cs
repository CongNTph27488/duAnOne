using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.dal.Table
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [StringLength(20)]
        public string ma { get; set; }
        [StringLength(50)]
        public string ten { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}
