﻿using BusinessLayer.Concrete;
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
    public class AdminBlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        BlogDBContext context = new BlogDBContext();
        BlogValidator blogValidator = new BlogValidator();
        public ActionResult AdminBlogList()
        {
            var blogList = blogManager.GetList();
            return View(blogList);
        }

        public ActionResult AdminAddBlog()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in context.Admins.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UserName,
                                               Value = x.AdminID.ToString()
                                           }).ToList();
            ViewBag.values2 = values2;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AdminAddBlog(Blog blog)
        {

            blog.BlogDate = DateTime.Now;
            blogManager.Add(blog);
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult AdminUpdateBlog(int id)
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in context.Admins.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UserName,
                                                Value = x.AdminID.ToString()
                                            }).ToList();
            ViewBag.values2 = values2;
            var findBlog = blogManager.GetById(id);
            return View(findBlog);
        }

        [HttpPost]
        [ValidateInput(false)]
        public  ActionResult AdminUpdateBlog(Blog blog)
        {
            blog.BlogDate = DateTime.Now;
            blogManager.Update(blog);
            return RedirectToAction("AdminBlogList");
        }

    }
}