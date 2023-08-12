using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(@"Categories", @"dbo");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).HasColumnName("CategoryID");
            builder.Property(x => x.Name).HasColumnName("CategoryName");
            builder.Property(x => x.Description).HasColumnName("Description");
        }
    }
}
