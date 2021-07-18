using BusinessLayer.Concrete;
using BusinessLayer.Utilities.Helper;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
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
        [Authorize]
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
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                var newFileName = FileOperationsHelper.CreateNewFileName(fileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/Images/Gallery/" + newFileName + expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                blog.BlogImage = "/Images/Gallery/" + newFileName + expansion;
                blog.BlogDate = DateTime.Now;
                blogManager.Add(blog);
                return RedirectToAction("AdminBlogList");
            }
            return View(blog);

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
        public ActionResult AdminUpdateBlog(Blog blog)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                var newFileName = FileOperationsHelper.CreateNewFileName(fileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/Images/Gallery/" + newFileName + expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                blog.BlogImage = "/Images/Gallery/" + newFileName + expansion;
                blog.BlogDate = DateTime.Now;
                blogManager.Update(blog);
                return RedirectToAction("AdminBlogList");
            }

            return View(blog);
        }


        public ActionResult AdminMyBlog(string mail)
        {
            mail = (string)Session["AdminMail"];
            int id = context.Admins.Where(x => x.AdminMail == mail).Select(y => y.AdminID).FirstOrDefault();
            var myBlogs = blogManager.GetByAuthorMail(id);
            return View(myBlogs);
        }

    }
}