using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBlog.Models
{
    public class BlogPost
    {
        public int ID { get; set; }
        public string PostTitle { get; set; }

        [AllowHtml]
        public string PostContent { get; set; }
        public DateTime PostDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public ICollection<CommentPost> CommentPosts { get; set; }


    }
}