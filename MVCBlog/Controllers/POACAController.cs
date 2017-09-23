using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlog.Models;

namespace MVCBlog.Controllers
{
    public class POACAController : Controller
    {
        public MVCBlog.Models.BlogContext db = new MVCBlog.Models.BlogContext();

        // GET: POACA
        public ActionResult GetFull()
        {

            PostAndCategoriesVM PocaList = new PostAndCategoriesVM();
            PocaList.BlogPostList = GetBlogPostList();
            PocaList.CategoryList = GetBlogCategoryList();
            return View(PocaList);
        }


        public List<BlogPost> GetBlogPostList()
        {

            var data = db.BlogTable.OrderBy(x => x.PostContent);

            List<BlogPost> ListOfBlogPost = (List<BlogPost>) data;

            return ListOfBlogPost;

        }


        public List<Category> GetBlogCategoryList()
        {

            var data = db.CategoryTable.OrderBy(x => x.CategoryName);

            List<Category> ListOfCategoryPost = (List<Category>)data;

            return ListOfCategoryPost;
            
        }



    }
}