using System.Web.Mvc;
using Course.Models;
using NHibernate.Linq;
using System.Linq;

namespace Course.Controllers
{
	public class UsersController : NHibernateController
	{

		public ActionResult InInGroup(int id, int groupId)
		{
			var u = NHibernateSession.Get<User>(id);
			var grp = NHibernateSession.Load<Group>(groupId);
			return Json(new { IsInGroup = u.Groups.Contains(grp) });
		}

		public ActionResult GroupCount(int id)
		{
			var u = NHibernateSession.Get<User>(id);
			return Json(new {GroupCount = u.Groups.Count});
		}

		public ActionResult NewGroup()
		{
			NHibernateSession.Save(new Group
			{
				Name = "Group"
			});
			return Json(new { Create = true });
		}
		public ActionResult Group(int id, int userId)
		{
			var g = NHibernateSession.Load<Group>(id);
			var u = NHibernateSession.Get<User>(userId);

			u.Groups.Add(g);
			return Json(new { Create = true });
		}


		 public ActionResult New()
		 {
		 	NHibernateSession.Save(new User
		 	{
		 		Name = "ayende",
		 		Email = "ayende@ayende.com"
		 	});

		 	return Json(new {Create = true});
		 }

		public ActionResult Load(int id)
		{
			var user = NHibernateSession.Get<User>(id);
			return Json(user);
		}

		public ActionResult List(int start = 0)
		{
			var users = NHibernateSession.Query<User>()
				.Skip(start)
				.Take(15)
				.ToList();

			return Json(users);
		}
	}
}