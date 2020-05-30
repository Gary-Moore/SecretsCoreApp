using System;
using System.Web;
using System.Web.Mvc;
using SecretsFrameworkApp.Web.Infrastructure;

namespace SecretsFrameworkApp.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HSTSAttribute(TimeSpan.FromMinutes(600),true, false ));
            filters.Add(new HandleErrorAttribute());
        }
    }
}
