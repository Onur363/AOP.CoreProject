﻿using CommonCoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Entities.Dto
{
    public class UserForRegisterDto:IDto
    {
        public string Email { get; set; }
        public string  Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
