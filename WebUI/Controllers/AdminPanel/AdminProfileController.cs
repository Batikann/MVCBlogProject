using BusinessLayer.Concrete;
using BusinessLayer.Utilities.Helper;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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

        public  ActionResult UpdateAdminProfile(Admin admin)
        {
            string mail = (string)Session["AdminMail"];
            var profilValues = adminManager.GetAdminByEmail(mail);
            admin.IsEmailVerified = true;
            if (admin.AdminImage==null )
            {
                admin.AdminImage = profilValues.AdminImage;
            }
            if (admin.DateOfBirth == null)
            {
                admin.DateOfBirth = profilValues.DateOfBirth;
            }
            if (admin.Password==null)
            {
                admin.Password = profilValues.Password;
            }
            adminManager.Update(admin);
            return RedirectToAction("AdminAuthorProfile");
  
            
        }
    }
}