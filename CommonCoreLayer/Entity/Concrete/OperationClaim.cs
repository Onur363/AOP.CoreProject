using CommonCoreLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Entity.Concrete
{
    public class OperationClaim:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
