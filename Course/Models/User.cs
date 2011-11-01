using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace Course.Models
{
	public class User
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Email { get; set; }
		public virtual ICollection<Group> Groups { get; set; }
		public virtual ICollection<Part> Parts { get; set; }
	}

	public class Admin : User
	{
		public virtual bool IsSuperAdmin { get; set; }
	}
}