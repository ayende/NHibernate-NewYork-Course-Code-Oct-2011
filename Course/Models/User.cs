using System.Collections.Generic;

namespace Course.Models
{
	public class User
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Email { get; set; }
		public virtual ICollection<Group> Groups { get; set; }
		public virtual ICollection<Part> Parts { get; set; }

		public virtual Address WorkAddress { get; set; }

		public virtual Address HomeAddress { get; set; }
	}

	public class Address
	{
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string State { get; set; }
		public string City { get; set; }
	}

	public class Admin : User
	{
		public virtual string Password { get; set; }
	}
}