using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult BlogList(int page=1)
        {
            var blogList = blogManager.GetList().ToPagedList(page, 4);
            return PartialView(blogList);
        }
        public PartialViewResult FeaturedPost()
        {
            Random rand = new Random();
            int sayi = rand.Next(1, 7);
            int sayi2 = rand.Next(1, 7);
            int sayi3 = rand.Next(1, 7);
            int sayi4 = rand.Next(1, 7);
            if (sayi == sayi2 || sayi == sayi3 || sayi == sayi4)
            {
                sayi = rand.Next(1, 7);
            }
            if (sayi2 == sayi || sayi2 == sayi3 || sayi2 == sayi4)
            {
                sayi2 = rand.Next(1, 7);
            }
            if (sayi3 == sayi || sayi3 == sayi2 || sayi3 == sayi4)
            {
                sayi3 = rand.Next(1, 7);
            }
            if (sayi4 == sayi || sayi4 == sayi2 || sayi4 == sayi3)
            {
                sayi4 = rand.Next(1, 7);
            }
            var posttitle1 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi).
                Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi).
              Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi).
              Select(y => y.BlogDate).FirstOrDefault();
            var blogcategoryName1 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi).
              Select(y => y.Category.CategoryName).FirstOrDefault();
            var blogpostid1 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi).
              Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.blogcategoryName1 = blogcategoryName1;
            ViewBag.blogpostid1= blogpostid1;
            //ViewBag.sayi = sayi;

            var posttitle2 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi2).
                Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi2).
              Select(y => y.BlogImage).FirstOrDefault();
            var blogdate2 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi2).
              Select(y => y.BlogDate).FirstOrDefault();
            var blogcategoryName2 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi2).
              Select(y => y.Category.CategoryName).FirstOrDefault();
            var blogpostid2 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi2).
              Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.blogdate2 = blogdate2;
            ViewBag.blogcategoryName2 = blogcategoryName2;
            ViewBag.blogpostid2 = blogpostid2;
            //ViewBag.sayi2 = sayi2;

            var posttitle3 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi3).
               Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi3).
              Select(y => y.BlogImage).FirstOrDefault();
            var blogdate3 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi3).
              Select(y => y.BlogDate).FirstOrDefault();
            var blogcategoryName3 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi3).
              Select(y => y.Category.CategoryName).FirstOrDefault();
            var blogpostid3 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi3).
              Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.blogdate3 = blogdate3;
            ViewBag.blogpostid3 = blogpostid3;
            //ViewBag.sayi3 = sayi3;


            var posttitle4 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi4).
               Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi4).
              Select(y => y.BlogImage).FirstOrDefault();
            var blogdate4 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi4).
              Select(y => y.BlogDate).FirstOrDefault();
            var blogcategoryName4 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi4).
              Select(y => y.Category.CategoryName).FirstOrDefault();
            var blogpostid4 = blogManager.GetList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == sayi4).
              Select(y => y.BlogID).FirstOrDefault();
            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.blogdate4 = blogdate4;
            ViewBag.blogcategoryName4 = blogcategoryName4;
            ViewBag.blogpostid4 = blogpostid4;
            //ViewBag.sayi4 = sayi4;
            return PartialView();
        }
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
        public ActionResult BlogDetails()
        {

            return View();
        }

        public PartialViewResult BlogCover(int id)
        {
            var blogDetailsList = blogManager.BlogByID(id);
            return PartialView(blogDetailsList);
        }

        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsList = blogManager.BlogByID(id);
            return PartialView(blogDetailsList);
        }

        public ActionResult BlogByCategory(int id)
        {
            var blogListById = blogManager.GetBlogByCategory(id);
            var categoryName = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            var categoryExplanation = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryExplanation).FirstOrDefault();
            ViewBag.CategoryName = categoryName;
            ViewBag.CategoryExplanation = categoryExplanation;
            return View(blogListById);
        }
        public ActionResult Test()
        {
            return View();
        }


    }
}