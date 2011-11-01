using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace Course.Models
{
	public class User
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Email { get; set; }
		public virtual ICollection<Group> Groups { get; set; }
		public virtual ICollection<Part> Parts { get; set; }

		private Hashtable attributes;

		public virtual dynamic Attributes
		{
			get
			{
				attributes = attributes ?? new Hashtable();
				return new DynamicHashtable(attributes);
			}
		}

		public virtual Address WorkAddress { get; set; }

		public virtual Address HomeAddress { get; set; }
	}

	public class DynamicHashtable : DynamicObject
	{
		private readonly Hashtable attributes;

		public DynamicHashtable(Hashtable attributes)
		{
			this.attributes = attributes;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = attributes[binder.Name];
			return true;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			attributes[binder.Name] = value;
			return true;
		}
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