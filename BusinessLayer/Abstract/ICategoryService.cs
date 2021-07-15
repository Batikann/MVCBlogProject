using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void ChangeCategoryStatus(Category category);
        Category GetByCategoryID(int id);
    }
}
