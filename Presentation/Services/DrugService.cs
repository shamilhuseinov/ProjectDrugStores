using System;
using Core.Entities;
using Core.Helpers;
using Data.Repository.Concrete;

namespace Presentation.Services
{
	public class DrugService
	{
		public readonly DrugRepository _drugRepository;
		public readonly DrugStoreRepository _drugStoreRepository;
		public readonly DrugStoreService _drugStoreService;

		public DrugService()
		{
			_drugRepository = new DrugRepository();
			_drugStoreRepository = new DrugStoreRepository();
			_drugStoreService = new DrugStoreService();
		}

		int id;
		public void Create()
		{
			if (_drugStoreRepository.GetAll().Count!=0)
			{
                id++;

				ConsoleHelper.WriteWithColor("Enter Name of the drug", ConsoleColor.Cyan);
                string name = Console.ReadLine();

                DrugPriceDescription: ConsoleHelper.WriteWithColor("Enter Price of the drug", ConsoleColor.Cyan);
                decimal price;
                bool issucceeded = decimal.TryParse(Console.ReadLine(), out price);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Drug price is not in a correct format", ConsoleColor.Red);
                    goto DrugPriceDescription;
                }

                if (price <= 0)
                {
                    ConsoleHelper.WriteWithColor("Drug price should ot be equal or less than 0", ConsoleColor.Red);
                    goto DrugPriceDescription;
                }

                DrugCountDescription: ConsoleHelper.WriteWithColor("Enter Count of the drug", ConsoleColor.Cyan);
				int count;
				issucceeded = int.TryParse(Console.ReadLine(), out count);

				if (!issucceeded)
				{
                    ConsoleHelper.WriteWithColor("Drug count is not in a correct format", ConsoleColor.Red);
					goto DrugCountDescription;
                }

				if (count<=0)
				{
                    ConsoleHelper.WriteWithColor("Drug count should not be equal or less than 0", ConsoleColor.Red);
                    goto DrugCountDescription;
                }

                _drugStoreService.GetAll();
            DrugStoreIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the drug store of the drug", ConsoleColor.Cyan);

				
				int drugStoreId;
				issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
				if (!issucceeded)
				{
                    ConsoleHelper.WriteWithColor("Drug store Id is not in a correct format", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

				var drugStore = _drugStoreRepository.Get(drugStoreId);
				if (drugStore is null)
				{
                    ConsoleHelper.WriteWithColor("There is not any drug store in this Id", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

				var drug = new Drug
				{
					Id=id,
					Name=name,
					Price=price,
					Count=count,
					DrugStore=drugStore
				};

				_drugRepository.Create(drug);

                ConsoleHelper.WriteWithColor($"Drug(Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, Count: {drug.Count}, DrugStore Id: {drug.DrugStore.Id}, DrugStore Name: {drug.DrugStore.Name}) has been created successfully", ConsoleColor.Green);


            }
            else
			{
                ConsoleHelper.WriteWithColor("First, you should create a drug store", ConsoleColor.Red);
            }

        } 

        public void Update()
		{
			if (_drugRepository.GetAll().Count==0)
			{
				ConsoleHelper.WriteWithColor("There is not any drug to update", ConsoleColor.Red);
			}

			else
			{
				GetAll();
                DrugIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the drug that you want to update", ConsoleColor.Cyan);
				int drugId;
				bool issucceeded = int.TryParse(Console.ReadLine(), out drugId);
				if (!issucceeded)
				{
                    ConsoleHelper.WriteWithColor("Drug Id is not in a correct format", ConsoleColor.Red);
					goto DrugIdDescription;
                }

				var drug = _drugRepository.Get(drugId);
				if (drug is null)
				{
                    ConsoleHelper.WriteWithColor("There is not any drug in this Id", ConsoleColor.Red);
					goto DrugIdDescription;
                }

                ConsoleHelper.WriteWithColor("Enter new name", ConsoleColor.Cyan);
				string name = Console.ReadLine();

                GroupPriceDescription: ConsoleHelper.WriteWithColor("Enter new price", ConsoleColor.Cyan);
				decimal price;
				issucceeded = decimal.TryParse(Console.ReadLine(), out price);
				if (!issucceeded)
				{
                    ConsoleHelper.WriteWithColor("Price is not in a correct format", ConsoleColor.Red);
					goto GroupPriceDescription;
                }

				if (price<=0)
				{
                    ConsoleHelper.WriteWithColor("Price should not be equal or less than 0", ConsoleColor.Red);
                    goto GroupPriceDescription;
                }

                DrugCountDescription: ConsoleHelper.WriteWithColor("Enter new count", ConsoleColor.Cyan);
				int updatedCount;
				issucceeded = int.TryParse(Console.ReadLine(), out updatedCount);
				if (!issucceeded)
				{
                    ConsoleHelper.WriteWithColor("New count is not in a correct format", ConsoleColor.Red);
					goto DrugCountDescription;
                }

				if (updatedCount<=0)
				{
                    ConsoleHelper.WriteWithColor("New count should be more than 0", ConsoleColor.Red);
                    goto DrugCountDescription;
                }

            DrugStoreIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the new drug store", ConsoleColor.Cyan);

				_drugStoreService.GetAll();
				int drugStoreId;
				issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
				if (!issucceeded)
				{
                    ConsoleHelper.WriteWithColor("Drug store Id is not in a correct format", ConsoleColor.Red);
					goto DrugStoreIdDescription;
                }

				var drugStore = _drugStoreRepository.Get(drugStoreId);
				if (drugStore is null)
				{
                    ConsoleHelper.WriteWithColor("There is not any drug store in this Id", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

				drug.Name = name;
				drug.Price = price;
				drug.Count = updatedCount;
				drug.DrugStore = drugStore;

				_drugRepository.Update(drug);

                ConsoleHelper.WriteWithColor($"Drug has been updated successfully. New name: {drug.Name}, New price: {drug.Price}, New Count: {drug.Count}, Id of the new DrugStore: {drug.DrugStore.Id},Id of the new DrugStore: {drug.DrugStore.Id}, Name of the new DrugStore: {drug.DrugStore.Name}", ConsoleColor.Green);

            }
        }

		public void Delete()
		{
			if (_drugRepository.GetAll().Count == 0)
			{
				ConsoleHelper.WriteWithColor("There is not any drug to delete", ConsoleColor.Red);
			}

			else
			{
				GetAll();
			DrugIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the drug that you want to delete", ConsoleColor.Cyan);
				int drugId;
				bool issucceeded = int.TryParse(Console.ReadLine(), out drugId);
				if (!issucceeded)
				{
					ConsoleHelper.WriteWithColor("Drug Id is not in a correct format", ConsoleColor.Red);
					goto DrugIdDescription;
				}

				var drug = _drugRepository.Get(drugId);
				if (drug is null)
				{
					ConsoleHelper.WriteWithColor("There is not any drug in this id", ConsoleColor.Red);
					goto DrugIdDescription;
				}

                _drugRepository.Delete(drug);

                ConsoleHelper.WriteWithColor($"Drug(Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, DrugStore Id: {drug.DrugStore.Id}, DrugStore Name: {drug.DrugStore.Name}) has been deleted successfully", ConsoleColor.Green);
            }
		}

		public void GetAll()
		{
			if (_drugRepository.GetAll().Count!=0)
			{
                ConsoleHelper.WriteWithColor("--All Drugs--", ConsoleColor.Blue);
                var drugs = _drugRepository.GetAll();
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteWithColor($"Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, Count: {drug.Count}, DrugStore Id: {drug.DrugStore.Id}, DrugStore Name: {drug.DrugStore.Name}", ConsoleColor.Cyan);
                }
            }
			else
			{
                ConsoleHelper.WriteWithColor("There is not any drug to get", ConsoleColor.Red);
            }
        }

		public void GetAllByDrugStore()
		{
			if (_drugRepository.GetAll().Count==0)
			{
				ConsoleHelper.WriteWithColor("There is not any drug to get", ConsoleColor.Red);
			}

			else
			{
				_drugStoreService.GetAll();

                DrugStoreIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the drug store", ConsoleColor.Blue);
				int drugStoreId;
				bool issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
				if (!issucceeded)
				{
                    ConsoleHelper.WriteWithColor("Drug store Id is not in a corect format", ConsoleColor.Red);
					goto DrugStoreIdDescription;
                }

				var drugStore = _drugStoreRepository.Get(drugStoreId);
				if (drugStore is null)
				{
                    ConsoleHelper.WriteWithColor("There is not any drug store in this Id", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

				var drugs = _drugRepository.GetAll().Where(d => d.DrugStore == drugStore);
				if (drugs.Count()==0)
				{
                    ConsoleHelper.WriteWithColor("There is not any drug in this drug store", ConsoleColor.Red);
					goto DrugStoreIdDescription;
                }

				foreach (var drug in drugs)
				{
                    ConsoleHelper.WriteWithColor($"Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, Count: {drug.Count}, DrugStore Id: {drug.DrugStore.Id}, DrugStore Name: {drug.DrugStore.Name}", ConsoleColor.Cyan);
                }

            }

        }

		public void Filter()
		{
			if (_drugRepository.GetAll().Count!=0)
			{
            MaxPriceDescription: ConsoleHelper.WriteWithColor("Enter maximum price of drug", ConsoleColor.Blue);
                int maxPrice;
                bool issucceeded = int.TryParse(Console.ReadLine(), out maxPrice);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Maximum price is not in a correct format", ConsoleColor.Red);
                    goto MaxPriceDescription;
                }

                if (maxPrice <= 0)
                {
                    ConsoleHelper.WriteWithColor("Maximum price should be more than 0", ConsoleColor.Red);
                    goto MaxPriceDescription;
                }

                var drugs = _drugRepository.GetAll().Where(d => d.Price <= maxPrice);

				if (drugs.Count()==0)
				{
                    ConsoleHelper.WriteWithColor("There is not any drug whose price is less than your input", ConsoleColor.Red);
                    goto MaxPriceDescription;
                }

                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteWithColor($"Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, Count: {drug.Count}, DrugStore Id: {drug.DrugStore.Id}, DrugStore Name: {drug.DrugStore.Name}", ConsoleColor.Cyan);
                }
            }

			else
			{
                ConsoleHelper.WriteWithColor("There is not any drug to filer", ConsoleColor.Red);
            }

        }
	}
}

