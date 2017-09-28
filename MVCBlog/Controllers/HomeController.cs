using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MVCBlog.Models;
using System.Data.Entity;

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


        public ActionResult GetPage2(int? id)
        {
            //var blog2 = context.Blogs
            //            .Where(b => b.Name == "ADO.NET Blog")
            //            .Include("Posts")
            //            .FirstOrDefault();

            var dummyItems = db.BlogTable.FirstOrDefault(x=> x.ID==id);

            var dummyItems2 = db.CategoryTable.FirstOrDefault(x => x.Id == dummyItems.CategoryId);

            var dummyItems3 = db.CommentTable.Include(xa=>xa.UserModel).Where(x=>x.BlogPostId== dummyItems.ID);
        


            var pageModel = new PageViewModel
            {
                Items = dummyItems,
               

                Items2 = dummyItems2,
                Items3 = dummyItems3
            };

            return View(pageModel);
        }

        //This is for reading a Blog Post not actually posting it.
        public ActionResult BlogPostPage()
        {
            return View();

        }
        public ActionResult BlogFilteredPage(int? Id)
        {
            var returnedlist = db.BlogTable.Where(x => x.CategoryId == Id);
            return View(returnedlist);
        }



        [HttpGet]
        public ActionResult Index2(int? page)
        {
            var dummyItems = db.BlogTable.OrderBy(x => x.ID);
            var dummyItems2 = db.CategoryTable.OrderBy(x => x.CategoryName);
            var dummyItems3 = db.CommentTable.OrderBy(x => x.BlogPost);
            var count = db.BlogTable
            .OrderBy(x=>x.ID).Count();
            var pager = new Pager(count, page);

           

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager,

                Items2 = dummyItems2,
                Items3 = dummyItems3
            };

            return View(viewModel);
        }


    }
}



