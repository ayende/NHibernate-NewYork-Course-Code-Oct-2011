using System;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using NHibernate;
using NHibernate.Event;
using NHibernate.Event.Default;

namespace Course.Models
{
	public class AuditLogListener : IPreUpdateEventListener
	{
		public bool OnPreUpdate(PreUpdateEvent @event)
		{
			var sb = new StringBuilder();
			sb.Append(@event.Persister.EntityName)
			  .Append(" #").Append(@event.Id)
				.Append(" was changed by ")
				.Append(WindowsIdentity.GetCurrent().Name).Append(" at ")
				.Append(DateTime.Now.ToString("dd MMM, yyyy", CultureInfo.InvariantCulture))
				.AppendLine();
			for (int i = 0; i < @event.State.Length; i++)
			{
				var propertyType = @event.Persister.PropertyTypes[i];
				var equal = propertyType.IsEqual(@event.State[i], @event.OldState[i], EntityMode.Poco);

				if(equal)
					continue;

				sb.Append("\t").Append(@event.Persister.PropertyNames[i])
					.Append(": ")
					.Append(@event.OldState[i])
					.Append(" -> ")
					.Append(@event.State[i])
					.AppendLine();
			}

			using(var child = @event.Session.GetSession(EntityMode.Poco))
			{
				child.Save(new AuditLogEntry
				{
					ChangeDescription = sb.ToString(),
					EntityId = (int) @event.Id,
					EntityName = @event.Persister.EntityName,
				});
				child.Flush();
			}

			return false;
		}
	}
}