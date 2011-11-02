using System.Collections.Generic;
using System.Web.Mvc;
using Course.Models;
using NHibernate.Linq;
using System.Linq;
using NHibernate.Criterion;

namespace Course.Controllers
{
	public class AdminController : NHibernateController
	{
		public ActionResult Test()
		{
			return Content(typeof (Part).IsSerializable.ToString());
		}
		public ActionResult Search(SearchParams args)
		{
			var q = NHibernateSession.Query<Part>();

			if (args.Name != null)
				q = q.Where(x => x.Name == args.Name);

			if (args.MinPrice != null)
				q = q.Where(x => x.Price >= args.MinPrice.Value);

			if (args.MaxPrice != null)
				q = q.Where(x => x.Price <= args.MaxPrice.Value);

			if (args.Description != null)
				q = q.Where(x => x.Description == args.Description);

			if (args.UserId != null)
				q = q.Where(x => x.User.Id == args.UserId.Value);

			if(args.References != null && args.References.Count >0)
			{
				q = args.References.Aggregate(q, (current, reference) => 
					current.Where(x => x.References.Any(y => y.Id == reference)));
			}

			return Json(q.ToList());
		}

		public ActionResult Set()
		{
			NHibernateSession.CreateQuery("update User u set u.Name = :name where u.Name != :name")
				.SetString("name", "ayende")
				.ExecuteUpdate();
			return Content("done");
		}

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

	public class SearchParams
	{
		public string Name { get; set; }
		public int? UserId { get; set; }
		public List<int> References { get; set; }
		public string Description { get; set; }
		public decimal? MinPrice { get; set; }
		public decimal? MaxPrice { get; set; }
	}
}