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

        public ActionResult AdminCommentList()
        {
            var commentList = commentManager.GetCommentStatusTrue();
            return View(commentList);
        }

        public ActionResult AdminFalseCommentList()
        {
            var commentList = commentManager.GetCommentStatusFalse();
            return View(commentList);
        }

        public ActionResult DeleteComment(int id)
        {
            var getComment = commentManager.GetCommentById(id);
            commentManager.CommentChangeStatusFalse(getComment);
            return RedirectToAction("AdminCommentList");
        }

        public ActionResult ConfirmComment(int id)
        {
            var getComment = commentManager.GetCommentById(id);
            commentManager.CommentChangeStatusTrue(getComment);
            return RedirectToAction("AdminCommentList");
        }
    }
}