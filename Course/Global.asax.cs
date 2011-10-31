using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using Configuration = NHibernate.Cfg.Configuration;
using Environment = System.Environment;

namespace Course
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static ISessionFactory SessionFactory;

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);

			SessionFactory = new Configuration()
				.AddAssembly(Assembly.GetExecutingAssembly())
				.DataBaseIntegration(properties =>
				{
					var connectionStringSettings = ConfigurationManager.ConnectionStrings[Environment.MachineName];
					properties.ConnectionStringName = connectionStringSettings != null ? 
						Environment.MachineName : 
						ConfigurationManager.ConnectionStrings[0].Name;

					properties.Dialect<MsSql2008Dialect>();
				})
				.BuildSessionFactory();
		}
	}
}