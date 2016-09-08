using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;

using PhotoIndex.API.App_Start;
using PhotoIndex.Data;

namespace PhotoIndex.API
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/fwlink/?LinkId=301868
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrapper.Configure();
            Database.SetInitializer(new PhotoIndexDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
