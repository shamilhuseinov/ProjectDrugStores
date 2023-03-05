using System;
namespace Core.Entities
{
	public class Owner:BaseEntity
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public List<DrugStore> Drugstores { get; set; }
	}
}

