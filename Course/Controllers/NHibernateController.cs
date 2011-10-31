using System.Web.Mvc;
using NHibernate;

namespace Course.Controllers
{
	public class NHibernateController : Controller
	{
		public ISession NHibernateSession { get; set; }

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			NHibernateSession = MvcApplication.SessionFactory.OpenSession();
			NHibernateSession.BeginTransaction();
		}

		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.Exception == null)
				NHibernateSession.Transaction.Commit();
			NHibernateSession.Dispose();
		}

		protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
		{
			return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
		}
	}
}