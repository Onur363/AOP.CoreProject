using CommonCoreLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Entity.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int OperationClaimId { get; set; }
    }
}
