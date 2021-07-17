using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.AdminPanel
{
    public class AdminProfileController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public  ActionResult AdminAuthorProfile()
        {
            return View();
        }

        public PartialViewResult Partial1(string id)
        {
            id = (string)Session["AdminMail"];
            var profilValues = adminManager.GetAdminByEmail(id);
            return PartialView(profilValues);
        }
    }
}