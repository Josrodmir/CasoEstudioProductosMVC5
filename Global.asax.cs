using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using CasoEstudioProductosMVC5.Data;
using CasoEstudioProductosMVC5.Migrations;

namespace CasoEstudioProductosMVC5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventarioContext, Configuration>());
        }
    }
}
