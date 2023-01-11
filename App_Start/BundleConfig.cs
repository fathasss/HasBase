using System.Web;
using System.Web.Optimization;

namespace HasB4bBase
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/JQuery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/JQuery/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/AngularJs/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                        "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/b4bApp").Include(
                        "~/Scripts/b4bApp.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/bootstrap.min.css"));
        }
    }
}
