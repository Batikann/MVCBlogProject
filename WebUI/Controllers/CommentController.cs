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

namespace WebUI.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        CommentValidator commentValidator = new CommentValidator();

        public PartialViewResult CommentList(int id)
        {
            var commentList = commentManager.GetCommentByBlogId(id);
            return PartialView(commentList);
        }
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult LeaveComment(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            commentManager.CommentAdd(comment);
            return PartialView(comment);
        }
    }
}