﻿using System;
namespace Core.Entities
{
	public class Druggist:BaseEntity
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public int Age { get; set; }

		public int Experience { get; set; }

		public DrugStore DrugStore { get; set; }
	}
}

