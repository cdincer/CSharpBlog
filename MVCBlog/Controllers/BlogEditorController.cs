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
            var NewBlogPost = new BlogPosterViewModel();
            NewBlogPost.Items = new BlogPost();
            NewBlogPost.Items2 = db.CategoryTable.OrderBy(x => x.CategoryName).ToList();

            ViewBag.ListOfCategories = new SelectList(NewBlogPost.Items2,"ID", "CategoryName");
            return View(NewBlogPost);
        }

        public ActionResult CategoryPoster()
        {


            return View();

        }
        [HttpPost]
        public ActionResult CategoryPoster(Category NewCategory)
        {
            db.CategoryTable.Add(NewCategory);
            db.SaveChanges();


            return View();

        }

        public ActionResult BlogList()
        {
            var data = db.BlogTable.OrderBy(x => x.ID);
            return View(data);
        }

        [HttpPost]
        public ActionResult Poster(BlogPosterViewModel PostNew)
        {
            BlogPost addPost = PostNew.Items;
            addPost.CategoryId = int.Parse(PostNew.CategoryCarrier);
            db.BlogTable.Add(addPost);
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