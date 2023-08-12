using CommonCoreLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Entities.Concrete
{
    public class Category:IEntity
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
