using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        //This is for reading a Blog Post not actually posting it.
        public ActionResult BlogPostPage()
        {
            return View();
        }
    }
}