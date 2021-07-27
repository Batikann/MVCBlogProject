using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = categoryManager.GetAllCategory();
            return PartialView(categoryValues);
        }

        public ActionResult AllCategories()
        {
            var categoryValues = categoryManager.GetAllCategory();
            return View(categoryValues);
        }
    }
}