using CommonCoreLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Entity.Concrete
{
    public class User:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual byte[] PasswordSalt { get; set; }// girilen password ü şifrelemek ve kuvvetlendirmek için
        public virtual byte[] PasswordHash { get; set; }
        public virtual bool Status { get; set; }
    }
}
