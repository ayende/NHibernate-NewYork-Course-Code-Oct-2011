using NHibernate.Event;
using NHibernate.Event.Default;

namespace Course.Models
{
	public class NonNegativeUserListener : 
		IPreUpdateEventListener, IPreInsertEventListener
	{
		public bool OnPreUpdate(PreUpdateEvent @event)
		{
			User user = @event.Entity as User;
			if (user == null)
				return false;

			return user.Attributes.Age < 0;
		}

		public bool OnPreInsert(PreInsertEvent @event)
		{
			User user = @event.Entity as User;
			if (user == null)
				return false;

			return user.Attributes.Age < 0;
		}
	}

	public class UserSoftDeletes : DefaultDeleteEventListener
	{
		protected override void DeleteEntity(IEventSource session, object entity, NHibernate.Engine.EntityEntry entityEntry, bool isCascadeDeleteEnabled, NHibernate.Persister.Entity.IEntityPersister persister, Iesi.Collections.ISet transientEntities)
		{
			var user = entity as User;
			if (user == null)
			{
				base.DeleteEntity(session,
					entity,
					entityEntry,
					isCascadeDeleteEnabled,
					persister,
					transientEntities);
				return;
			}

			CascadeBeforeDelete(session,
				persister,
				entity,
				entityEntry,
				transientEntities);

			user.Attributes.Deleted = true;

			CascadeAfterDelete(session,
				persister,
				entity,
				transientEntities);
		}
	}
}