using System.Media;
using System.Web;
using NHibernate;

namespace Course
{
	public class RevengeOfTheDba : EmptyInterceptor
	{
		public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
		{
			var count = (int) (HttpContext.Current.Items["sql-count"] ?? 0);
			if (count > 30)
			{
				new SoundPlayer(@"C:\Users\Ayende\Downloads\scream.wav").PlaySync();
			}
			HttpContext.Current.Items["sql-count"] = count + 1;
			return base.OnPrepareStatement(sql);
		}
	}
}