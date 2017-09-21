using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class BlogEditorController : Controller
    {
        public MVCBlog.Models.BlogContext db = new MVCBlog.Models.BlogContext();

        // GET: BlogPoster
        public ActionResult Poster()
        {
            return View();
        }

        public ActionResult Editor(int id)
        {
            return View(db.BlogTable.Find(id));
        }
    }
}