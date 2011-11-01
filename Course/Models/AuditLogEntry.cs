namespace Course.Models
{
	public class AuditLogEntry
	{
		public virtual int Id { get; set; }
		public virtual string EntityName { get; set; }
		public virtual int EntityId { get; set; }
		public virtual string ChangeDescription { get; set; }
	}
}