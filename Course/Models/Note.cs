namespace Course.Models
{
	public class Note
	{
		public virtual object Owner { get; set; }
		public virtual string Content { get; set; }
		public virtual int Id { get; set; }
	}
}