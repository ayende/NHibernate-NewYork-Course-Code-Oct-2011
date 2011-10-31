using System.Web.Mvc;
using Course.Models;
using NHibernate.Linq;
using System.Linq;

namespace Course.Controllers
{
	public class UsersController : NHibernateController
	{
		 public ActionResult New()
		 {
		 	session.Save(new User
		 	{
		 		Name = "ayende",
		 		Email = "ayende@ayende.com"
		 	});

		 	return Json(new {Create = true});
		 }

		public ActionResult Load(int id)
		{
			var user = session.Get<User>(id);
			return Json(user);
		}

		public ActionResult List(int start = 0)
		{
			var users = session.Query<User>()
				.Skip(start)
				.Take(15)
				.ToList();

			return Json(users);
		}
	}
}