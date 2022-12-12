using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1.dal.Table
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [StringLength(20)]
        public string ma { get; set; }

        public Guid idCv { get; set; }
        [ForeignKey(nameof(idCv))]
        [InverseProperty(nameof(ChucVu.NhanViens))]
        public ChucVu chucVu { get; set; }

        [StringLength(50)]
        public string ho { get; set; }
        [StringLength(50)]
        public string tenDem { get; set; }
        [StringLength(50)]
        public string ten { get; set; }
        public DateTime ngSinh { get; set; }
        [StringLength(20)]
        public string gioiTinh { get; set; }
        [StringLength(20)]
        public string sdt { get; set; }
        [StringLength(50)]
        public string diaChi { get; set; }
        [StringLength(50)]
        public string thanhPho { get; set; }
        [StringLength(50)]
        public string quocGia { get; set; }
        public int trangThai { get; set; }

        //public ICollection<GioHang> GioHangs { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }
    }
}
