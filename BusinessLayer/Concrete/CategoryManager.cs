using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            _categoryDal.Add(category);
        }

        public void ChangeCategoryStatus(Category category)
        {
            if (category.CategoryStatus == false)
            {
                category.CategoryStatus = true;
                _categoryDal.Update(category);
            }
            else
            {
                category.CategoryStatus = false;
                _categoryDal.Update(category);
            }

        }

        public List<Category> GetAllCategory()
        {
            return _categoryDal.List();
        }

        public Category GetByCategoryID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
