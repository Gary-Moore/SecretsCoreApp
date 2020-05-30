using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SecretsFrameworkApp.Web.Infrastructure
{
    public class HSTSAttribute : RequireHttpsAttribute
    {
        public TimeSpan MaxAge { get; private set; }
        public bool IncludeSubdomains { get; private set; }
        public bool Preload { get; private set; }

        public HSTSAttribute(TimeSpan? maxAge, bool includeSubdomains, bool preload = false):base()
        {
            MaxAge = maxAge ?? TimeSpan.FromDays(30);
            IncludeSubdomains = includeSubdomains;
            Preload = preload;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsSecureConnection)
            {
                var headerBuilder = new StringBuilder($"max-age={MaxAge.TotalSeconds}");

                if(IncludeSubdomains)
                {
                    headerBuilder.Append("; includeSubdomains");
                }

                if (Preload)
                {
                    headerBuilder.Append("; preload");
                }

                filterContext.HttpContext.Response.Headers.Add("Strict-Transport-Security", headerBuilder.ToString());
            }
            else
            {
                HandleNonHttpsRequest(filterContext);
            }
        }
    }
}