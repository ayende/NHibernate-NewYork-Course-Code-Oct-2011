using System.Web.Mvc;
using NHibernate;

namespace Course.Controllers
{
	public class NHibernateController : Controller
	{
		protected ISession session;

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			session = MvcApplication.SessionFactory.OpenSession();
			session.BeginTransaction();
		}

		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.Exception == null)
				session.Transaction.Commit();
			session.Dispose();
		}

		protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
		{
			return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
		}
	}
}