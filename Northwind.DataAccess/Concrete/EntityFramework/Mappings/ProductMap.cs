using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(@"Products", @"dbo");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).HasColumnName("ProductID");
            builder.Property(x => x.Name).HasColumnName("ProductName");
            builder.Property(x => x.Price).HasColumnName("UnitPrice");
            builder.Property(x => x.Quantity).HasColumnName("QuantityPerUnit");
            builder.Property(x => x.Stock).HasColumnName("UnitsInStock");

        }
    }
}
