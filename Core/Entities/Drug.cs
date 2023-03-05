using System;
namespace Core.Entities
{
	public class Drug:BaseEntity
	{
		public string Name { get; set; }

		public decimal Price { get; set; }

		public int Count { get; set; }

		public DrugStore DrugStore { get; set; }
	}
}

