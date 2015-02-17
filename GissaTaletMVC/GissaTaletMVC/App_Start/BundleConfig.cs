using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace GissaTaletMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/myscript.js"
                        ));
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap-theme.min.css",
                        "~/Content/mystyle.css"
                        ));

            BundleTable.EnableOptimizations = true;
        }
    }
}