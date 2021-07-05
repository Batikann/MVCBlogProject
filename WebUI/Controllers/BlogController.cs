using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult BlogList()
        {
            var blogList = blogManager.GetList();
            return PartialView(blogList);
        }
        public PartialViewResult FeaturedPost()
        {
            Random rand = new Random();
            int sayi = rand.Next(1, 4);
            if (sayi == 0)
            {
                sayi = rand.Next(1,4);
            }
            var posttitle1 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi).
                Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi).
              Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi).
              Select(y => y.BlogDate).FirstOrDefault();
            var blogcategoryName1 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi).
              Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.blogcategoryName1 = blogcategoryName1;
            return PartialView();
        }
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
        public PartialViewResult MailSubscribe()
        {
            return PartialView();
        }

        public ActionResult BlogDetails()
        {
            return View();
        }

        public PartialViewResult BlogCover()
        {
            return PartialView();
        }

        public PartialViewResult BlogReadAll()
        {
            return PartialView();
        }

        public ActionResult BlogByCategory()
        {
            return View();
        }


    }
}