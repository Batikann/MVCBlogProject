using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class MailSubscribeController : Controller
    {
        
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail subscribeMail)
        {
            return PartialView();
        }
    }
}