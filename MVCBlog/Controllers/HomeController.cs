using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {

        private MVCBlog.Models.BlogContext db = new MVCBlog.Models.BlogContext();

        // GET: HomeS
        public ActionResult Index()
        {
            return View(db.BlogTables);
        }


        //This is for reading a Blog Post not actually posting it.
        public ActionResult BlogPostPage()
        {
            return View();
        }
    }
}