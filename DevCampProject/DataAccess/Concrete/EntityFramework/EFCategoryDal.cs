using Core.DataAccess.EF;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal: EFRepositoryBase<Category,NortwindContext>, ICategoryDal
    {
    }
}
