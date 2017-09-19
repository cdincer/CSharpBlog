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
              "~/vendor/bootstrap/css/bootstrap.css",
              "~/vendor/bootstrap/css/bootstrap.min.css",
              "~/css/blog-home.css"
              ));

            bundles.Add(new ScriptBundle("~/script/bundles").Include(
                "~/vendor/jquery/jquery.js",
                "~/vendor/jquery/jquery.min.js",
                "~/vendor/popper/popper.min.js",
                "~/vendor/bootstrap/js/bootstrap.min.js",
                "~/js/clean-blog.min.js"
                ));

            #endregion

            #region AdminLayout

     
            #endregion



            BundleTable.EnableOptimizations = true;
}
}
}
 