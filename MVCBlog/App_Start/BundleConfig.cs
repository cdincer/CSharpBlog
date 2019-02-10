using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCBlog.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            #region SiteLayout

            bundles.Add(new StyleBundle("~/style/bundles").Include(
              "~/thirdparty/bootstrap/css/bootstrap.css",
              "~/thirdparty/bootstrap/css/bootstrap.min.css",
              "~/css/blog-home.css",
              "~/Summernote/css/bootstrap.css",
              "~/Summernote/css/summernote.css"
              ));

            bundles.Add(new ScriptBundle("~/script/bundles").Include(
                "~/thirdparty/jquery/jquery.js",
                "~/thirdparty/jquery/jquery.min.js",
                "~/thirdparty/popper/popper.min.js",
                "~/thirdparty/bootstrap/js/bootstrap.min.js",
                "~/js/clean-blog.min.js",
                "~/thirdparty/Summernote/js/bootstrap.js",
                "~/thirdparty/Summernote/js/jquery.js",
                "~/thirdparty/Summernote/js/summernote.js"
                ));

            #endregion

            #region AdminLayout

     
            #endregion



            BundleTable.EnableOptimizations = true;
}
}
}
 