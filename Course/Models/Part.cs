using System.Collections.Generic;

namespace Course.Models
{
	public class Part
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual string SerialNumber { get; set; }
		public virtual string PartNumber { get; set; }
		public virtual decimal Price { get; set; }
		public virtual User User { get; set; }
		public virtual ICollection<Part> References { get; set; }
	}
}