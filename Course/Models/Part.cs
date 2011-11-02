using System.Collections.Generic;
using NHibernate.Search.Attributes;
using NHibernate.Search.Bridge.Builtin;

namespace Course.Models
{
	[Indexed]
	public class Part
	{
		[DocumentId]
		public virtual int Id { get; set; }
		[Field(Store = Store.Yes)]
		public virtual string Name { get; set; }
		[Field(Store = Store.Yes)]
		public virtual string Description { get; set; }
		[Field(Index = Index.No, Store = Store.Yes)]
		public virtual string SerialNumber { get; set; }
		[Field(Index = Index.No, Store = Store.Yes)]
		public virtual string PartNumber { get; set; }
		[Field(Index = Index.No, Store = Store.Yes)]
		[FieldBridge(typeof(ValueTypeBridge<decimal>))]
		public virtual decimal Price { get; set; }
		[IndexedEmbedded]
		public virtual User User { get; set; }
		public virtual ICollection<Part> References { get; set; }
	}
}