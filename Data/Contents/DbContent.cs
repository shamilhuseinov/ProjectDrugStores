using System;
using Core.Entities;

namespace Data.Contents
{
	public static class DbContent
	{
		static DbContent()
		{
			Owners = new List<Owner>();
			DrugStores = new List<DrugStore>();
			Drugs = new List<Drug>();
			Druggists = new List<Druggist>();
			Admins = new List<Admin>();
		}

		public static List<Owner> Owners { get; set; }

		public static List<DrugStore> DrugStores { get; set; }

		public static List<Drug> Drugs { get; set; }

		public static List<Druggist> Druggists { get; set; }

		public static List<Admin> Admins { get; set; }
	}
}

