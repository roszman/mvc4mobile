using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using System.Web.Optimization;

namespace mvc4mobile
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //var displayModes = DisplayModeProvider.Instance.Modes;

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            /*
             * Jest błąd w aktualnej implementacji DisplayModeProvider'a, po paru minutach, niezależnie od rodzaju klienta aplikacja zaczyna serwować standardowe widoki,
             * to problem związany z cache'owaniem widoków. Fixem na to jest instalacja pakietu nugeta http://nuget.org/packages/Microsoft.AspNet.Mvc.FixedDisplayModes
             * */

            //Adding custom DisplayModes based on browser User-Agent string
            DisplayModeProvider.Instance.Modes
                .Insert(0, new DefaultDisplayMode("IE8")
                {
                    ContextCondition = context =>
                        context.Request.UserAgent.Contains("MSIE 8")
                });

            DisplayModeProvider.Instance.Modes
                .Insert(0, new DefaultDisplayMode("Android")
                {
                    ContextCondition = context =>
                        context.Request.UserAgent.Contains("Android")
                });

            BundleMobileConfig.RegisterBundles(BundleTable.Bundles);


        }
    }
}