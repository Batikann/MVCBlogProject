using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.AdminPanel
{
    public class AdminAuthorController : Controller
    {
        AuthorManager authorManager = new AuthorManager(new EfAdminDal());
        public ActionResult AuthorList()
        {
            var authorList = authorManager.GetAuthorList();
            return View(authorList);
        }
    }
}