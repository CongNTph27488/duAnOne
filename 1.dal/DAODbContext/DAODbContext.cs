using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using _1.dal.Table;

namespace _1.dal.DaoDbContext
{
    public class DAODbContext : DbContext
    {
        public DbSet<LoaiSp> loaiSps { get; set; }  
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<CuaHang> cuaHangs { get; set; }
        public DbSet<ChucVu> chucVus { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<GioHang> gioHangs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<GioHangCt> gioHangCts { get; set; }
        public DbSet<HoaDonCt> hoaDonCts { get; set; }

        public DAODbContext()
        {

        }
       protected override void OnConfiguring(DbContextOptionsBuilder optionBuider)
        {
            base.OnConfiguring(optionBuider.
                UseSqlServer("Data Source=CONGPC;Initial Catalog=DAO_tem06_it17305;" + "Persist Security Info=True;User ID=cong_agile;Password=1"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //apply cho từng class

            // Apply cac config cho cac model
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfiguration(new CuaHang)

            // Phương thức này sẽ áp dụng tất cả các config hiện có
        }
    }
}
