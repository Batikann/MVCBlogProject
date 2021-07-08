using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AuthorController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = blogManager.BlogByID(id);
            return PartialView(authorDetails);
        }
        public PartialViewResult AuthorPopularPosts(int id)
        {
            var blogAuthorID = blogManager.GetList().Where(x => x.BlogID == id).Select(y => y.AdminID).FirstOrDefault();
            var authorBlogs = blogManager.GetBlogByAuthor(blogAuthorID);
            return PartialView(authorBlogs);
        }
    }
}