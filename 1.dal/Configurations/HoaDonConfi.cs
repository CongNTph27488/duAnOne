using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _1.dal.Table;

namespace _1.dal.Configurations
{
    internal class HoaDonConfi : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(c => c.id);

            builder.Property(c => c.idNv).IsRequired();
            builder.HasOne(c => c.nhanViens).WithMany().HasForeignKey(c => c.idNv);
        }
    }
}
