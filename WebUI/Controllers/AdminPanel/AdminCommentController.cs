using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.AdminPanel
{
    public class AdminCommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public ActionResult GetCommentByBlog(int id)
        {
            var commentList = commentManager.GetCommentByBlogId(id);
            return View(commentList);
        }
    }
}