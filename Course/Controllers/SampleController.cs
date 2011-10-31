using System.Web.Mvc;
using Course.Models;

namespace Course.Controllers
{
	public class SampleController : NHibernateController
	{
		public ActionResult Index()
		{
			session.Save(new Part
			{
				Name = "Tire Iron",
				Description = "Use to kill at least 5000 people a year",
				PartNumber = "TI-5000"
			});

			return Json(new {Created = true}, JsonRequestBehavior.AllowGet);
		}
	}
}