using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _1.dal.Table;

namespace _1.dal.Configurations
{
    internal class ChucVuConfi : IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.ToTable("ChucVu"); //set name table if u dont want to use the name of class
            builder.HasKey(c => c.id);// set primary key
        }
    }
}
