using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _iCategoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _iCategoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return _iCategoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _iCategoryDal.Get(c => c.CategoryID == id);
        }
    }
}
