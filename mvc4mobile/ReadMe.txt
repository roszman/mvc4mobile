trzeba dodac viewstart.cshtml @{
    Layout = "~/Views/Shared/_Layout.cshtml";}

Jest błąd w aktualnej implementacji DisplayModeProvider'a, po paru minutach, niezależnie od rodzaju klienta aplikacja zaczyna serwować standardowe widoki,
to problem związany z cache'owaniem mobilnych widoków. Fixem na to jest instalacja pakietu nugeta http://nuget.org/packages/Microsoft.AspNet.Mvc.FixedDisplayModes

Aby zainstalować JQuery mobile z Package Manager Console: Install-Package jQuery.Mobile.MVC.

The jQuery.Mobile.MVC NuGet package installs the following:

The App_Start\BundleMobileConfig.cs file, which is needed to reference the jQuery JavaScript and CSS files added. You must follow the instructions below and reference the mobile bundle defined in this file.
jQuery Mobile CSS files.
A ViewSwitcher controller widget (Controllers\ViewSwitcherController.cs).
jQuery Mobile JavaScript files.
A jQuery Mobile-styled layout file (Views\Shared\_Layout.Mobile.cshtml).
A view-switcher partial view (MvcMobile\Views\Shared\_ViewSwitcher.cshtml) that provides a link at the top of each page to switch from desktop view to mobile view and vice versa.
Several .png  and .gif image files in the Content\images folder.
Open the Global.asax file and add the following code as the last line of the Application_Start method.

BundleMobileConfig.RegisterBundles(BundleTable.Bundles);

To enable default mobile view, you must add the following line as the last line in the Application_Start method in Global.asax.cs:
BundleMobileConfig.RegisterBundles(BundleTable.Bundles), bez tego nie zadziała jQuery i jego mobilne style (chyba, trzeba sprawdzić);
a zeby to zadziałało to:
<add namespace="System.Web.Optimization"/> trzeba dodać w web.config, w system.web.webPages.razor>pages>namespaces

dodatkowo trzeba w App_Start/BundleMobileConfig.RegisterBundles dodac 
	bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));
inaczej nie zadziałają jQuerowe mobilne templaty



if there is no mobile version of some_view.cshtml, the desktop view is rendered in mobile layout _Layout.Mobile.cshtml, it can be globally switched off by:
You can globally disable a default (non-mobile) view from rendering inside a mobile layout 
    by setting RequireConsistentDisplayMode to true in the Views\_ViewStart.cshtml file, like this:
    DisplayModeProvider.Instance.RequireConsistentDisplayMode = true;
or
You can disable consistent display mode in a view by setting RequireConsistentDisplayMode to false in the view file. 
The following markup in the Views\Home\AllSpeakers.cshtml file sets RequireConsistentDisplayMode to false:
DisplayModeProvider.Instance.RequireConsistentDisplayMode = false;