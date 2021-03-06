﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MVCBlog.Models;
using System.Data.Entity;
using System.Web.Security;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {

        public MVCBlog.Models.BlogContext db = new MVCBlog.Models.BlogContext();

        // GET: HomeS
       

        public ActionResult GetPage(int? id)
        {
            //var blog2 = context.Blogs
            //            .Where(b => b.Name == "ADO.NET Blog")
            //            .Include("Posts")
            //            .FirstOrDefault();

            var dummyItems = db.BlogTable.FirstOrDefault(x => x.ID == id);

            var dummyItems2 = db.CategoryTable.FirstOrDefault(x => x.Id == dummyItems.CategoryId);

            var dummyItems3 = db.CommentTable.Include(xa => xa.UserModel).Where(x => x.BlogPostId == dummyItems.ID);



            var pageModel = new PageViewModel
            {
                Items = dummyItems,


                Items2 = dummyItems2,
                Items3 = dummyItems3
            };

            return View(pageModel);
        }

        public ActionResult AdminPanel()
        {
            return View();

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
        public ActionResult Index(int? page)
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
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Home");
        }

    }
}



