using System.Web.Mvc;
using Course.Models;

namespace Course.Controllers
{
	public class SampleController : Controller
	{
		public ActionResult Index()
		{
			using (var session = MvcApplication.SessionFactory.OpenSession())
			using (session.BeginTransaction())
			{
				session.Save(new Part
				{
					Name = "Tire Iron",
					Description = "Use to kill at least 5000 people a year",
					PartNumber = "TI-5000"
				});
				session.Transaction.Commit();
			}

			return Json(new {Created = true}, JsonRequestBehavior.AllowGet);
		}
	}
}