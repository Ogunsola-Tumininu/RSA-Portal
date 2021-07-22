using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace PalRSA
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest()
        
        {
            ////  if (!Request.IsLocal)
            //{
            //    if (!Context.Request.IsSecureConnection)
            //    {
            //       // Response.Redirect(Context.Request.Url.ToString().Replace("http:", "https:"));
            //       // Response.Redirect(Context.Request.Url.ToString().Replace("https:", "http:"));
            //    }
            //    //else
            //    //{
            //    //    Response.Redirect(Context.Request.Url.ToString().Replace("https:", "http:"));
            //    //}
            //}

        }
        protected void Application_Start()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12; //Sola asked me to add

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                //WebSecurity.CreateUserAndAccount("admin", "admin");
                //Roles.CreateRole("Administrator");
                //Roles.AddUserToRole("Admin", "Administrator");
            }
            
            //WebSecurity.CreateUserAndAccount("ose", "ose");
            //Roles.AddUserToRole("ose", "Customer");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
