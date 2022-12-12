using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _1.dal.Table;

namespace _1.dal.Configurations
{
    internal class LoaiSanPhamConfi : IEntityTypeConfiguration<LoaiSanPham>
    {
        public void Configure(EntityTypeBuilder<LoaiSanPham> builder)
        {
            builder.ToTable("LoaiSanPham");
            builder.HasKey(c => c.id);
        }
    }
}
