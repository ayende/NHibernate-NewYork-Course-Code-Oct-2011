using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Course.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Mapping;
using NHibernate.Tool.hbm2ddl;

namespace Course.Tests
{
	public class InMemoryTests : IDisposable
	{
		private static ISessionFactory sessionFactory;
		private static Configuration configuration;
		private SQLiteConnection connection;

		private static void InitSessionFactory()
		{
			if (sessionFactory != null) 
				return;
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

		public ISession OpenSession()
		{
			return sessionFactory.OpenSession(connection);
		}

		public InMemoryTests()
		{
			InitSessionFactory();
			connection = new SQLiteConnection("data source=:memory:");
			connection.Open();
			new SchemaExport(configuration).Execute(false, true, false, connection, null);
	
		}

		public void Dispose()
		{
			connection.Dispose();
		}
	}

}