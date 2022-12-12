using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _1.dal.Table;

namespace _1.dal.Configurations
{
    internal class HoaDonChiTietConfi : IEntityTypeConfiguration<HoaDonChiTiet>
    {
        public void Configure(EntityTypeBuilder<HoaDonChiTiet> builder)
        {
            builder.ToTable("HoaDonChiTiet");
            builder.HasKey(c => c.id);

            builder.Property(c => c.idHd).IsRequired();
            builder.HasOne(c => c.hoaDons).WithMany().HasForeignKey(c => c.idHd);

            builder.Property(c => c.idSp).IsRequired();
            builder.HasOne(c=>c.sanPhams).WithMany().HasForeignKey(c => c.idSp);
        }
    }
}
