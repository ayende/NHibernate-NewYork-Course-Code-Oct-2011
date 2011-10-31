using System.Linq;
using System.Web.Mvc;
using Course.Models;
using NHibernate.Linq;

namespace Course.Controllers
{
	public class PartsController : NHibernateController
	{

		public ActionResult Move(int id)
		{
			var part = session.Get<Part>(id);
			var nextUserId = part.User.Id + 1;
			part.User = session.Load<User>(nextUserId);

			return Json(new
			{
				MovedTo = part.User.Name
			});

		}

		public ActionResult Report(int id, bool desc)
		{
			var part = session.Get<Part>(id);

			return Json(new
			{
				part.Id,
				SerialNumber = part.SerialNumber,
				HasUser = part.User != null,
				Desc = desc ? part.Description : null
			});
		}

		public ActionResult New(int userId)
		{
			var user = session.Get<User>(userId);
			var part = new Part
			{
				Name = "tire",
				Description = "Have some coffee",
				PartNumber = "il-123",
				User = user,
				SerialNumber = "1230-123-14-23"
				
			};
			user.Parts.Add(part);
			session.Save(part);

			return Json(new { Create = true });
		}

		public ActionResult Attach(int x, int y)
		{
			var xp = session.Get<Part>(x);
			var yp = session.Get<Part>(y);

			xp.References.Add(yp);
			yp.References.Add(xp);

			return Json(new {Attached = true});
		}

		public ActionResult Load(int id)
		{
			var user = session.Get<Part>(id);
			return Json(user);
		}

		public ActionResult List(int start = 0)
		{
			var users = session.Query<Part>()
				.Skip(start)
				.Take(15)
				.ToList();

			return Json(users);
		}
	}
}