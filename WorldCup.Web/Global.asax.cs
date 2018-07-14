using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using WorldCup.Service;

namespace WorldCup.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Seeding the database with initial data
            PlayerService.InitializeDatabase();

            //if (!ModelBinders.Binders.ContainsKey(typeof(Mvc.JQuery.DataTables.DataTablesParam)))
            //    ModelBinders.Binders.Add(typeof(Mvc.JQuery.DataTables.DataTablesParam), new Mvc.JQuery.DataTables.DataTablesModelBinder());
        }
    }
}
