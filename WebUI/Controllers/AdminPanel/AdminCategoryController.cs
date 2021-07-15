using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        CategoryValidator categoryValidator = new CategoryValidator();
        public ActionResult AdminCategoryIndex()
        {
            var categoryList = categoryManager.GetAllCategory();
            return View(categoryList);
        }

        public ActionResult AdminAddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAddCategory(Category category)
        {
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                categoryManager.AddCategory(category);
                return RedirectToAction("AdminCategoryIndex");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(category);
        }

        public ActionResult UpdateCategory(int id)
        {
            var categoryName = categoryManager.GetByCategoryID(id);
            return View(categoryName);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                categoryManager.UpdateCategory(category);
                return RedirectToAction("AdminCategoryIndex");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(category);
        }


        public ActionResult ChangeStatusCategory(int id)
        {
            var category = categoryManager.GetByCategoryID(id);
            categoryManager.ChangeCategoryStatus(category);
            return RedirectToAction("AdminCategoryIndex");
        }


    }
}