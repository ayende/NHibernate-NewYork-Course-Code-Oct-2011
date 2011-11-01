using System.Web.Mvc;
using Course.Models;
using NHibernate.Linq;
using System.Linq;

namespace Course.Controllers
{
	public class AdminController : NHibernateController
	{
		public ActionResult Update()
		{
			var u = NHibernateSession.Query<User>().FirstOrDefault();
			u.Name = "Ayende";
			u.Email = "Ayende@Ayende.com";
			return Content("updated");
		}

		public ActionResult Op()
		{
			for (int i = 0; i < 50; i++)
			{
				var user = new User
				{
					Name = "ayende",
					Email = "abc"
				};
				NHibernateSession.Save(user);
			}

			return Json(new {});
		 }
	}
}