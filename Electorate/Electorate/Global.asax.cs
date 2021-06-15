using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Routing;


namespace Electorate
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterRoutes(RouteTable.Routes);

            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            newCulture.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }

        void RegisterRoutes(RouteCollection routes)
        {

            routes.MapPageRoute("", "", "~/WebForms/wfMain.aspx");
            routes.MapPageRoute("", "Main/", "~/WebForms/wfMain.aspx");          
            routes.MapPageRoute("", "Login/", "~/WebForms/wfLogin.aspx");          
            routes.MapPageRoute("", "SupportBase/", "~/WebForms/wfSupportBase.aspx");                  

        }
    }
}