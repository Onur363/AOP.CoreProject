﻿using CommonCoreLayer.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {

    }
}
