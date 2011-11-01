using System.Web.Mvc;
using Course.Models;
using NHibernate.Linq;
using System.Linq;

namespace Course.Controllers
{
	public class AdminController : NHibernateController
	{
		public ActionResult Op()
		 {
		 	NHibernateSession.Save(new User
		 	{
		 		Name = "ayende",
				Email = "abc"
		 	});
			NHibernateSession.Save(new Admin
			{
				Name = "admin",
				Email = "das",
				Password = "abcaqsdads"
			});

			NHibernateSession.Get<User>(11);
			NHibernateSession.Get<Admin>(111);


			NHibernateSession.Query<Admin>().ToList();
			NHibernateSession.Query<User>().ToList();

			return Json(new {});
		 }
	}
}