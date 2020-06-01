using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using SecretsFrameworkApp.Web.Infrastructure;

[assembly: OwinStartup(typeof(SecretsFrameworkApp.Web.Startup))]

namespace SecretsFrameworkApp.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseSecurityHeaders();
        }
    }
}
