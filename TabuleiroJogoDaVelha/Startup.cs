using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.Owin.Host.HttpListener;
using Microsoft.Owin.Hosting;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Web.Http.SelfHost;

[assembly: OwinStartup(typeof(TabuleiroJogoDaVelha.Startup))]
namespace TabuleiroJogoDaVelha
{
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //configura a web api para auto-hospedagem
            var config = new HttpConfiguration();
            //var config = new HttpSelfHostConfiguration("http://localhost:9000");

   

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
           );

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
            new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            app.UseErrorPage();
            app.UseWelcomePage("/");
            app.UseWebApi(config);
        }

       
    }
}
