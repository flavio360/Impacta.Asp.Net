using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Cap04_Lab01_Pagina_392.Startup))]

namespace Cap04_Lab01_Pagina_392
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                                           
                    AuthenticationType = "AppViagensOnlineCookie",
                    LoginPath = new PathString("/Admin/Login")
                });
        }
    }
}
