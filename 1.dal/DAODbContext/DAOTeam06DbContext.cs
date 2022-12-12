using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using _1.dal.Table;
using _1.dal.Configurations;

namespace _1.dal.DAODbContext
{
    public class DAOTeam06DbContext:DbContext
    {
        
        public DbSet<LoaiSanPham> loaiSps { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<ChucVu> chucVus { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<HoaDonChiTiet> hoaDonCts { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //apply for each class
        //    modelBuilder.ApplyConfiguration(new NhanVienConfi());
        //    modelBuilder.ApplyConfiguration(new HoaDonConfi());
        //    modelBuilder.ApplyConfiguration(new HoaDonChiTietConfi());
        //    modelBuilder.ApplyConfiguration(new LoaiSanPhamConfi());
        //    modelBuilder.ApplyConfiguration(new SanPhamConfi());
        //    modelBuilder.ApplyConfiguration(new ChucVuConfi());

        //    //apply config for each model
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuider)
        {
            base.OnConfiguring(optionBuider.
                UseSqlServer("Data Source=CONGPC;Initial Catalog=Dao_team06_it17305_remake;" + "Persist Security Info=True;User ID=cong_agile;Password=1"));
        }
    }
}
