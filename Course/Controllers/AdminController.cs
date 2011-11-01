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
		 	});
			NHibernateSession.Save(new Admin
			{
				Name = "admin"
			});

			NHibernateSession.Get<User>(1);
			NHibernateSession.Get<Admin>(1);


			NHibernateSession.Query<Admin>().ToList();
			NHibernateSession.Query<User>().ToList();

			return Json(new {});
		 }
	}
}