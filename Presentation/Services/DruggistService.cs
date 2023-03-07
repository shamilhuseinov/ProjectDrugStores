using System;
using Core.Entities;
using Core.Helpers;
using Data.Repository.Concrete;

namespace Presentation.Services
{
	public class DruggistService
	{
		public DruggistService()
		{
			_drugStoreRepository = new DrugStoreRepository();
			_druggistRepository = new DruggistRepository();
            _drugStoreService = new DrugStoreService();
			
		}
        public readonly DrugStoreRepository _drugStoreRepository;
		public readonly DruggistRepository _druggistRepository;
        public readonly DrugStoreService _drugStoreService;

        int id;
		public void Create()
		{
			if (_drugStoreRepository.GetAll().Count!=0)
			{
                id++;
                ConsoleHelper.WriteWithColor("Enter name of the Druggist", ConsoleColor.Cyan);
                string name = Console.ReadLine();

                ConsoleHelper.WriteWithColor("Enter surname of the Druggist", ConsoleColor.Cyan);
                string surname = Console.ReadLine();

            DruggistAgeDescription: ConsoleHelper.WriteWithColor("Enter age of the Druggist", ConsoleColor.Cyan);
                int age;
                bool issucceeded = int.TryParse(Console.ReadLine(), out age);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Age is not in a correct format", ConsoleColor.Red);
                    goto DruggistAgeDescription;
                }

                if (age < 18 || age > 65)
                {
                    ConsoleHelper.WriteWithColor("There should not be any druggist whose age is less than 18 or more than 65", ConsoleColor.Red);
                    goto DruggistAgeDescription;
                }

            DruggistExperienceDescription: ConsoleHelper.WriteWithColor("Enter experience of the Druggist", ConsoleColor.Cyan);

                int experience;
                issucceeded = int.TryParse(Console.ReadLine(), out experience);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Experience is not in a correct format", ConsoleColor.Red);
                    goto DruggistExperienceDescription;
                }

                if (age - experience < 18)
                {
                    ConsoleHelper.WriteWithColor("Age of a druggist should be at least 18 years more than experience", ConsoleColor.Red);
                    goto DruggistExperienceDescription;
                }

                _drugStoreService.GetAll();
            DrugStoreIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the drugStore at which the druggist works", ConsoleColor.Cyan);
                int drugStoreId;
                issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id of the Drug store is not in a correct format", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

                var drugStore = _drugStoreRepository.Get(drugStoreId);
                if (drugStore is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drugstore in this id", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

                var druggist = new Druggist
                {
                    Id = id,
                    Name = name,
                    Surname = surname,
                    Age = age,
                    Experience = experience,
                    DrugStore = drugStore
                };

                _druggistRepository.Create(druggist);

                ConsoleHelper.WriteWithColor($"Druggist(Id: {druggist.Id}, Name: {druggist.Name}, Surname: {druggist.Surname}, Age: {druggist.Age}, Experience: {druggist.Experience}, DrugStore Id: {druggist.DrugStore.Id}, DrugStore Name: {druggist.DrugStore.Name}) has been created successfully", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteWithColor("First, you should create a drug store", ConsoleColor.Red);
            }
			
        }

		public void Update()
		{
            if (_druggistRepository.GetAll().Count==0)
            {
                ConsoleHelper.WriteWithColor("There is not any Druggist to update", ConsoleColor.Red);
            }
            else
            {
                GetAll();
                UpdateDruggistDescription: ConsoleHelper.WriteWithColor("Enter Id of the druggist that you want to update", ConsoleColor.Blue);
                int druggistId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out druggistId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Druggist Id is not in a correct format", ConsoleColor.Red);
                    goto UpdateDruggistDescription;
                }

                var druggist = _druggistRepository.Get(druggistId);
                if (druggist is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any druggist in this Id", ConsoleColor.Red);
                    goto UpdateDruggistDescription;
                }

                ConsoleHelper.WriteWithColor("Enter new name", ConsoleColor.Cyan);
                string name = Console.ReadLine();

                ConsoleHelper.WriteWithColor("Enter new surname", ConsoleColor.Cyan);
                string surname = Console.ReadLine();

                AgeDescription: ConsoleHelper.WriteWithColor("Enter new age", ConsoleColor.Cyan);
                int age;
                issucceeded = int.TryParse(Console.ReadLine(), out age);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Age is not in a correct format", ConsoleColor.Red);
                    goto AgeDescription;
                }
                if (age<18||age>65)
                {
                    ConsoleHelper.WriteWithColor("Age of a druggist should not be less than 18 or more than 65", ConsoleColor.Red);
                    goto AgeDescription;
                }

            ExperienceDescription: ConsoleHelper.WriteWithColor("Enter new experience", ConsoleColor.Cyan);
                int experience;
                issucceeded = int.TryParse(Console.ReadLine(), out experience);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Experience is not in a correct format", ConsoleColor.Red);
                    goto ExperienceDescription;
                }

                if (age-experience<18)
                {
                    ConsoleHelper.WriteWithColor("Age of a druggist should be at least 18 years more than experience", ConsoleColor.Red);
                    goto ExperienceDescription;
                }

                _drugStoreService.GetAll();
                DrugStoreDescription: ConsoleHelper.WriteWithColor("Enter id of the new drug store", ConsoleColor.Cyan);

                int drugStoreId;
                issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Drug store Id is not in a correct format", ConsoleColor.Red);
                    goto DrugStoreDescription;
                }

                var drugStore = _drugStoreRepository.Get(drugStoreId);
                if (drugStore is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drug store in this id", ConsoleColor.Red);
                    goto DrugStoreDescription;
                }

                druggist.Name = name;
                druggist.Surname = surname;
                druggist.Age = age;
                druggist.Experience = experience;
                druggist.DrugStore = drugStore;

                _druggistRepository.Update(druggist);

                ConsoleHelper.WriteWithColor($"Druggist has been updated successfully. New name: {druggist.Name}, New surname: {druggist.Surname}, New age: {druggist.Age}, new experience: {druggist.Experience}, Id of the new DrugStore: {druggist.DrugStore.Id}, Name of the new DrugStore: {druggist.DrugStore.Name}", ConsoleColor.Green);
            }
        }

		public void Delete()
		{
            if (_druggistRepository.GetAll().Count!=0)
            {
                GetAll();
                DeleteDruggistDescription: ConsoleHelper.WriteWithColor("Enter Id of the Druggist that you want to delete", ConsoleColor.Blue);
                int druggistId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out druggistId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Druggist Id is not in a correct format", ConsoleColor.Red);
                    goto DeleteDruggistDescription;
                }

                var druggist = _druggistRepository.Get(druggistId);
                if (druggist is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any druggist in this id", ConsoleColor.Red);
                    goto DeleteDruggistDescription;
                }

                _druggistRepository.Delete(druggist);

                ConsoleHelper.WriteWithColor($"Druggist(Id: {druggist.Id}, Name: {druggist.Name}, Surname: {druggist.Surname}, Age: {druggist.Age}, Experience: {druggist.Experience}, DrugStore Id: {druggist.DrugStore.Id}, DrugStore Name: {druggist.DrugStore.Name}) has been deleted successfully", ConsoleColor.Green);

            }
            else
            {
                ConsoleHelper.WriteWithColor("There is not any druggist to delete", ConsoleColor.Red);
            }
        }

		public void GetAll()
		{
            var druggists = _druggistRepository.GetAll();
            if (druggists.Count==0)
            {
                ConsoleHelper.WriteWithColor("There is not any druggist to get",ConsoleColor.Red);
            }
            else
            {
                ConsoleHelper.WriteWithColor("--All Druggists--", ConsoleColor.Blue);

                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteWithColor($"Id: {druggist.Id}, Name: {druggist.Name}, Surname: {druggist.Surname}, Age: {druggist.Age}, Experience: {druggist.Experience}, DrugStore Id: {druggist.DrugStore.Id}, DrugStore Name: {druggist.DrugStore.Name}", ConsoleColor.Cyan);
                }
            }
		}

		public void GetAllByDrugStore()
		{
            if (_druggistRepository.GetAll().Count==0)
            {
                ConsoleHelper.WriteWithColor("There is not any druggist to get", ConsoleColor.Red);
            }
            else
            {
                _drugStoreService.GetAll();
                DrugStoreIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the Drug Store", ConsoleColor.Cyan);
                int drugStoreId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Drug store Id is not in a correct format", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

                var drugStore = _drugStoreRepository.Get(drugStoreId);
                if (drugStore is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drug store in this id", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

                var druggists = _druggistRepository.GetAll().Where(d=>d.DrugStore==drugStore);
                if (druggists.Count()==0)
                {
                    ConsoleHelper.WriteWithColor("There is not any druggist in this drug store", ConsoleColor.Red);
                    goto DrugStoreIdDescription;
                }

                foreach (var druggist in druggists)
                {
                    ConsoleHelper.WriteWithColor($"Id: {druggist.Id}, Name: {druggist.Name}, Surname: {druggist.Surname}, Age: {druggist.Age}, Experience: {druggist.Experience}, DrugStore Id: {druggist.DrugStore.Id}, DrugStore Name: {druggist.DrugStore.Name}", ConsoleColor.Cyan);

                }
            }
        }
	}
}

