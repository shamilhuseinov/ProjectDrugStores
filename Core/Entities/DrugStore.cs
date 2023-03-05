using System;
namespace Core.Entities
{
	public class DrugStore:BaseEntity
	{
		public string Name { get; set; }

		public string Address { get; set; }

		public string ContactNumber { get; set; }

		public string Email { get; set; }

		public List<Druggist> Druggists { get; set; }

		public List<Drug> Drugs { get; set; }

		public Owner Owner { get; set; }
	}
}

