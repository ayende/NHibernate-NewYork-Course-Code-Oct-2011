namespace Course.Models
{
	public class Part
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual string PartNumber { get; set; }
	}
}