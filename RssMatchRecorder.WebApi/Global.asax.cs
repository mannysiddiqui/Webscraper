using System;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using RssMatchRecorder.DataAccess;
using RssMatchRecorder.DataAccess.Sql;
using Unity;
using Unity.AspNet.WebApi;

namespace RssMatchRecorder.WebApi
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();



            GlobalConfiguration.Configure(ConfigHttp);
        }

        private void ConfigHttp(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            RegisterDependencies(config);

            RegisterRoutes(config);
        }

        private static void RegisterRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("SearchRss", "search", new {controller = "RssSearch", action = "Search", feedId = (int?) null, keyword = (string) null, startDate = (DateTime?) null, endDate = (DateTime?) null });
        }

        private void RegisterDependencies(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IRssRepository, RssSqlRepository>();

            config.DependencyResolver = new UnityDependencyResolver(container);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}