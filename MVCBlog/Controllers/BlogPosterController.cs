using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class BlogPosterController : Controller
    {
        // GET: BlogPoster
        public ActionResult Index()
        {
            return View();
        }
    }
}