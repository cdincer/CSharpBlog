using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCBlog.Models
{
    public class CommentPost
    {
        public int Id { get; set; }

        [AllowHtml]
        public string Comment { get; set; }

        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }


        public int UserModelId { get; set; }
        public virtual UserModel UserModel { get; set; }

    }
}