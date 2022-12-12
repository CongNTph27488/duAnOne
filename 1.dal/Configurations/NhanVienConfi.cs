using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _1.dal.Table;

namespace _1.dal.Configurations
{
    internal class NhanVienConfi : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("NhanVien");
            builder.HasKey(c => c.id);

            builder.Property(c => c.idCv).IsRequired();
            builder.HasOne(c => c.chucVu).WithMany().HasForeignKey(b => b.idCv);// set foreign key
        }
    }
}
