using System.Web.Mvc;
using Course.Models;
using NHibernate.Criterion;
using NHibernate.Linq;
using System.Linq;

namespace Course.Controllers
{
	public class RealController : NHibernateController
	{
		 public ActionResult Index(int start = 0)
		 {
			 var users = NHibernateSession.QueryOver<User>()
		 		.Where(x => x.Name == "ayende")
		 		.Future();

			var parts = NHibernateSession.QueryOver<Part>()
		 		.Skip(start)
		 		.Take(25)
		 		.Future();

		 	var totalParts = NHibernateSession.QueryOver<Part>()
				.Select(Projections.RowCountInt64())
		 		.FutureValue<long>();
			 

		 	return Json(new
		 	{
		 		Email =  users.Select(x=>x.Email).FirstOrDefault(),
		 		Parts = parts.Select(p=>new
		 		{
		 			p.Name,
					p.PartNumber,
					p.SerialNumber
		 		}).ToArray(),
				TotalPartCount = totalParts.Value
		 	});
		 }
	}
}