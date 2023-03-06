using System;
using Core.Entities;
using Core.Extensions;
using Core.Helpers;
using Data.Contents;
using Data.Repository.Concrete;

namespace Presentation.Services
{
	public class DrugStoreService
	{
		public readonly OwnerRepository _ownerRepository;
		public readonly DrugStoreRepository _drugStoreRepository;
        public readonly OwnerService _ownerService;
        public readonly DrugRepository _drugRepository;

		public DrugStoreService()
		{
			_ownerRepository = new OwnerRepository();
			_drugStoreRepository = new DrugStoreRepository();
            _ownerService = new OwnerService();
            _drugRepository = new DrugRepository();
        }
		int id;
		public void Create()
		{
			if (_ownerRepository.GetAll().Count!=0)
			{
                id++;
                ConsoleHelper.WriteWithColor("Enter name of the DrugStore", ConsoleColor.Cyan);
                string name = Console.ReadLine();

                ConsoleHelper.WriteWithColor("Enter address of the DrugStore", ConsoleColor.Cyan);
                string address = Console.ReadLine();

            ContactNumberDescription: ConsoleHelper.WriteWithColor("Enter contact number of the DrugStore", ConsoleColor.Cyan);

                string contactNumber = Console.ReadLine();

                if (!contactNumber.IsCorrectNumber())
                {
                    ConsoleHelper.WriteWithColor("Contact number is not in a correct format", ConsoleColor.Red);
                    goto ContactNumberDescription;
                }

            EmailDescription: ConsoleHelper.WriteWithColor("Enter Email of the DrugStore", ConsoleColor.Cyan);

                string email = Console.ReadLine();
                if (!email.IsEmail())
                {
                    ConsoleHelper.WriteWithColor("Email is not in a correct format", ConsoleColor.Red);
                    goto EmailDescription;
                }
                if (_drugStoreRepository.IsDublicateEmail(email))
                {
                    ConsoleHelper.WriteWithColor("This email has already been used", ConsoleColor.Red);
                    goto EmailDescription;
                }

                _ownerService.GetAll();

            OwnerIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the DrugStore owner", ConsoleColor.Cyan);
                int ownerId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out ownerId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Owner Id is not in a correct format", ConsoleColor.Red);
                    goto OwnerIdDescription;
                }

                var drugStoreOwner = _ownerRepository.Get(ownerId);
                if (drugStoreOwner is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any owner in this Id", ConsoleColor.Red);
                    goto OwnerIdDescription;
                }

                var drugStore = new DrugStore
                {
                    Id=id,
                    Name = name,
                    Address=address,
                    ContactNumber=contactNumber,
                    Email=email,
                    Owner=drugStoreOwner
                };

                _drugStoreRepository.Create(drugStore);

                ConsoleHelper.WriteWithColor($"DrugStore has been created successfully with Name: {drugStore.Name}, Address: {drugStore.Address}, ContactNumber: {drugStore.ContactNumber}, Email: {drugStore.Email},Owner Id: {drugStore.Owner.Id}, Owner Name: {drugStore.Owner.Name}", ConsoleColor.Green);

            }
            else
            {
                ConsoleHelper.WriteWithColor("First, you should create an owner", ConsoleColor.Red);
            }

        }

        public void Update()
		{
            if (_drugStoreRepository.GetAll().Count!=0)
            {
                GetAll();

            UpdateDrugStoreDescription: ConsoleHelper.WriteWithColor("Enter id of the drug store that you want to update", ConsoleColor.Blue);
                int drugStoreId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Drug store Id is not in a correct format", ConsoleColor.Red);
                    goto UpdateDrugStoreDescription;
                }
                var drugstore = _drugStoreRepository.Get(drugStoreId);

                if (drugstore is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drugstore in this id", ConsoleColor.Red);
                    goto UpdateDrugStoreDescription;
                }

                ConsoleHelper.WriteWithColor("Enter new name", ConsoleColor.Cyan);
                string name = Console.ReadLine();

                ConsoleHelper.WriteWithColor("Enter new address", ConsoleColor.Cyan);
                string address = Console.ReadLine();

            ContactNumberDescription: ConsoleHelper.WriteWithColor("Enter new Contact number", ConsoleColor.Cyan);
                string contactNumber = Console.ReadLine();
                if (!contactNumber.IsCorrectNumber())
                {
                    ConsoleHelper.WriteWithColor("Contact number is not in a correct format", ConsoleColor.Red);
                    goto ContactNumberDescription;
                }

            EmailDescription: ConsoleHelper.WriteWithColor("Enter new Email", ConsoleColor.Cyan);
                string email = Console.ReadLine();

                if (!email.IsEmail())
                {
                    ConsoleHelper.WriteWithColor("Email is not in a correct format", ConsoleColor.Red);
                    goto EmailDescription;
                }
                if (_drugStoreRepository.IsDublicateEmail(email))
                {
                    ConsoleHelper.WriteWithColor("This email has already been used", ConsoleColor.Red);
                    goto EmailDescription;
                }

                _ownerService.GetAll();

            OwnerIdDescription: ConsoleHelper.WriteWithColor("Enter Id of the new Owner", ConsoleColor.Cyan);
                int ownerId;
                issucceeded = int.TryParse(Console.ReadLine(), out ownerId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Owner id is not in a correct format", ConsoleColor.Red);
                    goto OwnerIdDescription;
                }

                var newOwner = _ownerRepository.Get(ownerId);
                if (newOwner is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any owner in this Id", ConsoleColor.Red);
                    goto OwnerIdDescription;
                }

                drugstore.Name = name;
                drugstore.Address = address;
                drugstore.ContactNumber = contactNumber;
                drugstore.Email = email;
                drugstore.Owner = _ownerRepository.Get(ownerId);

                _drugStoreRepository.Update(drugstore);

                ConsoleHelper.WriteWithColor($"Drug Store has been updated successfully: New Name: {drugstore.Name}, new Adress: {drugstore.Address}, new Contact number: {drugstore.ContactNumber}, new Email: {drugstore.Email},Id of new owner: {drugstore.Owner.Id}, Name of new owner: {drugstore.Owner.Name}", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteWithColor("There is not any drug store to update", ConsoleColor.Red);
            }
        }

		public void Delete()
		{
            if (_drugStoreRepository.GetAll().Count==0)
            {
                ConsoleHelper.WriteWithColor("There is not any drugStore to delete", ConsoleColor.Red);
            }
            else
            {
                GetAll();
            DeleteDrugStoreDescription: ConsoleHelper.WriteWithColor("Enter id of the drugStore that you want to delete", ConsoleColor.Blue);

                int drugStoreId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out drugStoreId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("drugStoreId is not in a correct format", ConsoleColor.Red);
                    goto DeleteDrugStoreDescription;
                }
                var drugStore = _drugStoreRepository.Get(drugStoreId);

                if (drugStore is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drugstore in this Id", ConsoleColor.Red);
                    goto DeleteDrugStoreDescription;
                }

                _drugStoreRepository.Delete(drugStore);
                ConsoleHelper.WriteWithColor($"Drugstore(Id: {drugStore.Id}, Name: {drugStore.Name}) has succssfully been deleted", ConsoleColor.Green);

            }
        }

		public void GetAll()
		{
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count==0)
            {
                ConsoleHelper.WriteWithColor("There is not any drugstore to get", ConsoleColor.Red);
            }
            else
            {
                ConsoleHelper.WriteWithColor("--All drug stores--", ConsoleColor.Blue);

                foreach (var drugStore in drugStores)
                {
                    ConsoleHelper.WriteWithColor($"Id: {drugStore.Id}, Name: {drugStore.Name},Address: {drugStore.Address}, ContactNumber: {drugStore.ContactNumber}, Email: {drugStore.Email}, OwnerId: {drugStore.Owner.Id}, OwnerName: {drugStore.Owner.Name}", ConsoleColor.Cyan);
                }

            }
        }

		public void GetAllByOwner()
		{
			if (_drugStoreRepository.GetAll().Count==0)
			{
				ConsoleHelper.WriteWithColor("There is not any drugStore to get", ConsoleColor.Red);
			}
			else
			{
                _ownerService.GetAll();

                OwnerIdDescription: ConsoleHelper.WriteWithColor("Choose owner Id", ConsoleColor.Cyan);
				int ownerId;
				bool issucceeded = int.TryParse(Console.ReadLine(), out ownerId);
				if (!issucceeded)
				{
                    ConsoleHelper.WriteWithColor("Owner Id is not in a correct format", ConsoleColor.Red);
					goto OwnerIdDescription;
                }

				var owner = _ownerRepository.Get(ownerId);
				if (owner is null)
				{
                    ConsoleHelper.WriteWithColor("There is not any owner in this id", ConsoleColor.Red);
					goto OwnerIdDescription;
                }

                var drugStores = _drugStoreRepository.GetAll().Where(s => s.Owner == owner);
                if (drugStores.Count()==0)
                {
                    ConsoleHelper.WriteWithColor("This owner does not have any drugstores", ConsoleColor.Red);
                    goto OwnerIdDescription;
                }

                foreach (var drugStore in drugStores)
                {
                    ConsoleHelper.WriteWithColor($"Id: {drugStore.Id}, Name: {drugStore.Name},Address: {drugStore.Address}, ContactNumber: {drugStore.ContactNumber}, Email: {drugStore.Email}, OwnerId: {drugStore.Owner.Id}", ConsoleColor.Cyan);
                }        
            }
        }

        public void Sale()
        {
            SaleDescription: if (_drugRepository.GetAll().Count != 0)
            {
                ConsoleHelper.WriteWithColor("--All Drugs--", ConsoleColor.Blue);
                var drugs = _drugRepository.GetAll();
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteWithColor($"Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, Count: {drug.Count}, DrugStore Id: {drug.DrugStore.Id}, DrugStore Name: {drug.DrugStore.Name}", ConsoleColor.Cyan);
                }

            DrugidDescription: ConsoleHelper.WriteWithColor("Enter Id of the drug that you want to sell", ConsoleColor.Blue);
                int drugId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out drugId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Drug Id is not in a correct format", ConsoleColor.Red);
                    goto DrugidDescription;
                }

                var saleDrug = _drugRepository.Get(drugId);
                if (saleDrug is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drug in this id", ConsoleColor.Red);
                    goto DrugidDescription;
                }

                if (saleDrug.Count!=0)
                {


                    ConsoleHelper.WriteWithColor("Enter quantity that you want to sell", ConsoleColor.Blue);
                    int quantity;
                    issucceeded = int.TryParse(Console.ReadLine(), out quantity);
                    if (!issucceeded)
                    {
                        ConsoleHelper.WriteWithColor("Quantity is not in a correct format", ConsoleColor.Red);
                        goto DrugidDescription;
                    }

                    if (quantity <= 0)
                    {
                        ConsoleHelper.WriteWithColor("Quantity should be more than 0", ConsoleColor.Red);
                        goto DrugidDescription;
                    }

                    if (quantity < saleDrug.Count && quantity==1)
                    {
                        var commonPrice = saleDrug.Price * quantity;
                        saleDrug.Count -= quantity;
                        ConsoleHelper.WriteWithColor($"{quantity} drug has been sold. Common price is {commonPrice}", ConsoleColor.Green);
                    }

                    if (quantity < saleDrug.Count && quantity!=1)
                    {
                        var commonPrice = saleDrug.Price * quantity;
                        saleDrug.Count -= quantity;
                        ConsoleHelper.WriteWithColor($"{quantity} drugs have been sold. Common price is {commonPrice}", ConsoleColor.Green);
                    }

                    if (quantity > saleDrug.Count)
                    {
                    SelectionDescription: ConsoleHelper.WriteWithColor($"We have only {saleDrug.Count} drugs. Do you want to get them? 1-yes, 2-no", ConsoleColor.Red);
                        int selection;
                        issucceeded = int.TryParse(Console.ReadLine(), out selection);
                        if (!issucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Selection is not in a correct format", ConsoleColor.Red);
                            goto SelectionDescription;
                        }

                        if (!(selection == 1 || selection == 2))
                        {
                            ConsoleHelper.WriteWithColor("There is not any selection like that", ConsoleColor.Red);
                            goto SelectionDescription;
                        }

                        if (selection == 1)
                        {
                            var commonPrice = saleDrug.Price * saleDrug.Count;
                            ConsoleHelper.WriteWithColor($"all of that drugs have been sold. Common price is {commonPrice}", ConsoleColor.Green);

                            saleDrug.Count=0;
                        }
                    }

                    if (quantity == saleDrug.Count)
                    {
                        saleDrug.Count=0;
                        var commonPrice = saleDrug.Price * quantity;
                        ConsoleHelper.WriteWithColor($"all of that drugs have been sold. Common price is {commonPrice}", ConsoleColor.Green);
                    }
                }
                else
                {
                    ConsoleHelper.WriteWithColor("All of this drug had been sold", ConsoleColor.Red);
                }
            }

            else
            {
                ConsoleHelper.WriteWithColor("There is not any drug to sell", ConsoleColor.Red);
            }

        }
    }
}

