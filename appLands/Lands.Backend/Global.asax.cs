

namespace Lands.Backend
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Lands.Backend.Helpers;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.CheckRolesAndSuperUser();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CheckRolesAndSuperUser()
        {
            UserHelper.CheckRole("Admin");
            UserHelper.CheckRole("User");
            UserHelper.CheckSuperUser();
        }
    }
}
