using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.AdminPanel
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult AdminCategoryIndex()
        {
            var categoryList = categoryManager.GetAllCategory();
            return View(categoryList);
        }
    }
}