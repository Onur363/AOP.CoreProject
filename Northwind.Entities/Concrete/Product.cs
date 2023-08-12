using CommonCoreLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Entities.Concrete
{
    public class Product:IEntity
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Quantity { get; set; }
        public virtual int CategoryID { get; set; }
        public virtual decimal Price { get; set; }
        public virtual short Stock { get; set; }
    }
}
