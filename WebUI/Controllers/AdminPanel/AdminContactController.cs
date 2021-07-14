using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers.AdminPanel
{
    public class AdminContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        public ActionResult Inbox()
        {
            var inboxContact = contactManager.GetContact();
            return View(inboxContact);
        }
        public ActionResult InboxDetails(int id)
        {
            var getbyContact = contactManager.GetContactByID(id);
            return View(getbyContact);
        }

        public PartialViewResult InboxPartial()
        {
            return PartialView();
        }
    }
}