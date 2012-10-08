using System.Web;
using System.Web.Optimization;

namespace mvc4mobile {
    public class BundleMobileConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquerymobile")
                .Include("~/Scripts/jquery.mobile-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/Mobile/css")
                .Include("~/Content/Site.Mobile.css"));
            
            bundles.Add(new StyleBundle("~/Content/jquerymobile/css")
                .Include("~/Content/jquery.mobile-{version}.css"));

            bundles.Add(new StyleBundle("~/Content/Responsive")
                .Include("~/Content/Responsive.css"));

            bundles.Add(new StyleBundle("~/Content/Reset")
                .Include("~/Content/reset.css"));
        }
    }
}