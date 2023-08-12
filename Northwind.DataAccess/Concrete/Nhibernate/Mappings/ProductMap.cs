using FluentNHibernate.Mapping;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess.Concrete.Nhibernate.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();
            Id(p => p.ID).Column("ProductID");
            Map(p => p.Name).Column("ProductName");
            Map(p => p.Price).Column("UnitPrice");
            Map(p => p.Quantity).Column("QuantityPerUnit");
            Map(p => p.Stock).Column("UnitsInStock");
            Map(p => p.CategoryID).Column("CategoryID");
        }
    }
}
