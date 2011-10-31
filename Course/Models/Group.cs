using System.Collections.Generic;

namespace Course.Models
{
	public class Group
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
}