using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

namespace ServerHost
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var idProvider = new CustomUserIdProvider();

            //GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
