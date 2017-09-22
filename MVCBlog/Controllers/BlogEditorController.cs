using MVCBlog.Models;
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



        public ActionResult BlogList()
        {
            var data = db.BlogTable.OrderBy(x => x.ID);
            return View(data);
        }

        [HttpPost]
        public ActionResult Poster(BlogPost PostNew)
        {
            db.BlogTable.Add(PostNew);
            db.SaveChanges();
                
                return RedirectToAction("Index","Home");
        }


        public ActionResult Editor(int id)
        {
            return View(db.BlogTable.Find(id));
        }

        [HttpPost]
        public ActionResult Editor(BlogPost UpdatedPost)
        {
            var original = db.BlogTable.Find(UpdatedPost.ID);
            if (UpdatedPost != null)
            {
                original.PostContent = UpdatedPost.PostContent;
                original.PostDate = UpdatedPost.PostDate;
                original.PostTitle = UpdatedPost.PostTitle;
                
                db.SaveChanges();


            }

            return RedirectToAction("Index", "Home");

        }
    }
}