using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
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

			NHibernateProfiler.Initialize();

			SessionFactory = new Configuration()
				.DataBaseIntegration(properties =>
				{
					properties.SchemaAction = SchemaAutoAction.Update;
					properties.Dialect<MsSql2008Dialect>();

					var connectionStringSettings = ConfigurationManager.ConnectionStrings[Environment.MachineName];
					properties.ConnectionStringName = connectionStringSettings != null ? 
						Environment.MachineName : 
						ConfigurationManager.ConnectionStrings[0].Name;

				})
				.AddAssembly(Assembly.GetExecutingAssembly())
				.BuildSessionFactory();
		}
	}

	public class GetOuttttttt : INamingStrategy
	{
		private static string Enough(params string[] args)
		{
			using(var md5 = MD5.Create())
			{
				var computeHash = md5.ComputeHash(Encoding.UTF8.GetBytes(string.Join("/", args)));
				return "`" + BitConverter.ToString(computeHash) + "`";
			}
		}

		public string ClassToTableName(string className)
		{
			return Enough(className);
		}

		public string PropertyToColumnName(string propertyName)
		{
			return Enough(propertyName);
		}

		public string TableName(string tableName)
		{
			return Enough(tableName);
		}

		public string ColumnName(string columnName)
		{
			return Enough(columnName);
		}

		public string PropertyToTableName(string className, string propertyName)
		{
			return Enough(className, propertyName);
		}

		public string LogicalColumnName(string columnName, string propertyName)
		{
			return Enough(columnName, propertyName);
		}
	}
}