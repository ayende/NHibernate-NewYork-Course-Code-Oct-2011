using System.Web.Mvc;
using Course.Controllers;
using Course.Models;
using Xunit;

namespace Course.Tests
{
	public class RealTests : InMemoryTests
	{
		[Fact]
		public void WillReturnUserEmail()
		{
			using (var s = OpenSession())
			{
				using (var tx = s.BeginTransaction())
				{
					s.Save(new User
					{
						Name = "ayende",
						Email = "ayende@ayende.com"
					});
					tx.Commit();
				}
			}

			using (var s = OpenSession())
			{
				var controller = new RealController
					{
						NHibernateSession = s
					};
				var jsonResult = (JsonResult)controller.Index();
				var emailProp = jsonResult.Data.GetType().GetProperty("Email");


				var actual = emailProp.GetValue(jsonResult.Data, null);
				Assert.Equal("ayende@ayende.com", actual);
			}
		}

		[Fact]
		public void WillReturnParts()
		{
			using (var s = OpenSession())
			{
				using (var tx = s.BeginTransaction())
				{
					s.Save(new User
					{
						Name = "ayende",
						Email = "ayende@ayende.com"
					});
					tx.Commit();
				}
			}
			using (var s = OpenSession())
			{

				var controller = new RealController
				{
					NHibernateSession = s
				};
				var jsonResult = (JsonResult)controller.Index();
				var emailProp = jsonResult.Data.GetType().GetProperty("Email");


				var actual = emailProp.GetValue(jsonResult.Data, null);
				Assert.Equal("ayende@ayende.com", actual);
			}
		}
	}
}
