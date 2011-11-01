using System.IO;
using Course.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace Course.Tests
{
	public class InMemoryTests
	{
		private static ISessionFactory sessionFactory;
		private static Configuration configuration;

		public ISession OpenSession()
		{
			if (sessionFactory == null)
			{
				configuration = new Configuration()
					.DataBaseIntegration(properties =>
					{
						properties.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
						properties.Dialect<SQLiteDialect>();
						properties.ConnectionString = "data source=:memory:";
					})
					.AddAssembly(typeof (Part).Assembly);
				sessionFactory = configuration
					.BuildSessionFactory();
			}
			var openSession = sessionFactory.OpenSession();
			new SchemaExport(configuration).Execute(false, true, false, openSession.Connection, null);
			return openSession;
		}
	}
}