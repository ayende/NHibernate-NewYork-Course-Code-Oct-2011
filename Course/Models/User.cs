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

		public virtual string WorkAddressLine1 { get; set; }
		public virtual string WorkAddressLine2 { get; set; }
		public virtual string WorkAddressState { get; set; }
		public virtual string WorkAddressCity { get; set; }

		public virtual string HomeAddressLine1 { get; set; }
		public virtual string HomeAddressLine2 { get; set; }
		public virtual string HomeAddressState { get; set; }
		public virtual string HomeAddressCity { get; set; }
	}

	public class Admin : User
	{
		public virtual string Password { get; set; }
	}
}