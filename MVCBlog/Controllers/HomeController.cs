using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {

        public MVCBlog.Models.BlogContext db = new MVCBlog.Models.BlogContext();

        // GET: HomeS
        public ActionResult Index(int? page)
        {
            int pageIndex = page ?? 1;

            var data = db.BlogTable.OrderBy(x => x.ID).ToPagedList(pageIndex,10);
            //var model = db.BlogTables.ToList();
            return View(data);
        }

        public ActionResult GetPage(int id)
        {
            return View(db.BlogTable.Find(id));
        }

        //This is for reading a Blog Post not actually posting it.
        public ActionResult BlogPostPage()
        {
            return View();
        }

        public ActionResult GetCategories()
        {
            ViewBag.CategoryName = db.CategoryTable.ToList();

                return View();
        }
     
    }
}