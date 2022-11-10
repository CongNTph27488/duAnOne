using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.dal.Table
{
    [Table("CuaHang")]
    public class CuaHang
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [StringLength(20)]
        public string ma { get; set; }
        [StringLength(50)]
        public string ten { get; set; }
        [StringLength(50)]
        public string diaChi { get; set; }
        [StringLength(50)]
        public string thanhPho { get; set; }
        [StringLength(50)]
        public string quocGia { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}
