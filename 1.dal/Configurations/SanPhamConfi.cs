using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _1.dal.Table;

namespace _1.dal.Configurations
{
    internal class SanPhamConfi : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPham");
            builder.HasKey(c => c.id);

            builder.Property(c => c.idLsp).IsRequired();
            builder.HasOne(c => c.loaiSps).WithMany().HasForeignKey(c => c.idLsp);
        }
    }
}
