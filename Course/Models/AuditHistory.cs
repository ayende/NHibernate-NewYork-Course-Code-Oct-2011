using System.Collections;
using NHibernate;
using NHibernate.Event;

namespace Course.Models
{
	public class AuditHistory : PreUpdateDeleteListener<User>
	{
		protected override void PreUpdate(PreUpdateEvent @event)
		{
			var old = new Hashtable();
			for (int i = 0; i < @event.OldState.Length; i++)
			{
				old[@event.Persister.PropertyNames[i]] = @event.OldState[i];
			}

			using(var child = @event.Session.GetSession(EntityMode.Map))
			{
				child.Save(@event.Persister.EntityName + "History", old);
				child.Flush();
			}
		}
	}

	public abstract class PreUpdateDeleteListener<T> : IPreUpdateEventListener
	{
		public bool OnPreUpdate(PreUpdateEvent @event)
		{
			if (@event.Entity is T)
				PreUpdate(@event);

			return false;
		}

		protected abstract void PreUpdate(PreUpdateEvent @event);
	}
}