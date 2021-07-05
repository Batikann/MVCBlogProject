using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public PartialViewResult AuthorAbout()
        {
            return PartialView();
        }
        public PartialViewResult AuthorPopularPosts()
        {
            return PartialView();
        }
    }
}