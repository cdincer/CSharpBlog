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
    public class CommentPostController : Controller
    {
        public MVCBlog.Models.BlogContext db = new MVCBlog.Models.BlogContext();

        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CommentPoster(int? id)
        {

            //var blog2 = context.Blogs
            //            .Where(b => b.Name == "ADO.NET Blog")
            //            .Include("Posts")
            //            .FirstOrDefault();
            CommentPostModel pageModel = new CommentPostModel();

            var dummyItems = db.BlogTable.FirstOrDefault(x => x.ID == id);





            pageModel.Items = dummyItems;
            pageModel.Items2 = new CommentPost();
            pageModel.UserIdContainer = "";
            return View(pageModel);
        
    }

        [HttpPost]
        public ActionResult CommentPoster(CommentPostModel NewComment)
        {
            int usermodelidintcontainer = int.Parse( NewComment.UserIdContainer);


            var sentCommentpost = new CommentPost
            {
                BlogPostId = NewComment.Items.ID,
                Comment = NewComment.Items2.Comment,
               UserModelId = usermodelidintcontainer

            };



            db.CommentTable.Add(sentCommentpost);
            db.SaveChanges();


            return View();
        }
    }
}