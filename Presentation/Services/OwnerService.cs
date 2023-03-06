using System;
using Core.Entities;
using Core.Helpers;
using Data.Contents;
using Data.Repository.Concrete;

namespace Presentation.Services
{
	public class OwnerService
	{
        private readonly OwnerRepository _ownerRepository;
        public OwnerService()
		{
			_ownerRepository = new OwnerRepository();
		}
		int id;

		public void Create()
		{
			id++;

			ConsoleHelper.WriteWithColor("Enter owner name", ConsoleColor.Cyan);
			string name = Console.ReadLine();

            ConsoleHelper.WriteWithColor("Enter owner surname", ConsoleColor.Cyan);
            string surname = Console.ReadLine();

			var owner = new Owner
			{
				Id = id,
				Name = name,
				Surname = surname
			};

			_ownerRepository.Create(owner);

            ConsoleHelper.WriteWithColor($"Id: {owner.Id}, Name: {owner.Name}, Surname: {owner.Surname} has been created successfully", ConsoleColor.Green);


        }

        public void Update()
		{
            if (_ownerRepository.GetAll().Count!=0)
            {
                GetAll();

            UpdateOwnerDescription: ConsoleHelper.WriteWithColor("Enter id of the owner that you want to update", ConsoleColor.Cyan);
                int id;
                bool issucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id is not in a correct format", ConsoleColor.Red);
                    goto UpdateOwnerDescription;
                }
                var owner = _ownerRepository.Get(id);
                if (owner is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any owner in this id", ConsoleColor.Red);
                    goto UpdateOwnerDescription;
                }

                ConsoleHelper.WriteWithColor("Enter new Name", ConsoleColor.Cyan);
                string name = Console.ReadLine();

                ConsoleHelper.WriteWithColor("Enter new Surname", ConsoleColor.Cyan);
                string surname = Console.ReadLine();

                owner.Name = name;
                owner.Surname = surname;
                _ownerRepository.Update(owner);

                ConsoleHelper.WriteWithColor($"{owner.Name} {owner.Surname} has been updated successfully", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteWithColor("There is not any owner to update", ConsoleColor.Red);
            }

        }

		public void Delete()
		{
            if (_ownerRepository.GetAll().Count!=0)
            {
                GetAll();
            DeleteOwnerDescription: ConsoleHelper.WriteWithColor("Enter id of the owner that you want to delete", ConsoleColor.Cyan);
                int id;
                bool issucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Id is not in a correct format", ConsoleColor.Red);
                    goto DeleteOwnerDescription;
                }

                var owner = _ownerRepository.Get(id);
                if (owner is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any owner in this id", ConsoleColor.Red);
                    goto DeleteOwnerDescription;
                }

                _ownerRepository.Delete(owner);

                ConsoleHelper.WriteWithColor($"{owner.Name} {owner.Surname} has been deleted successfully", ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteWithColor("There is not any owner to Delete", ConsoleColor.Red);
            }
        }

        public void GetAll()
		{
			if (_ownerRepository.GetAll().Count!=0)
			{
                var owners = _ownerRepository.GetAll();

                ConsoleHelper.WriteWithColor("--All owners--", ConsoleColor.Blue);

                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteWithColor($"Id: {owner.Id}, Name: {owner.Name}, Surname: {owner.Surname}", ConsoleColor.Green);
                }
            }
			else
			{
                ConsoleHelper.WriteWithColor("There is not any owner to get", ConsoleColor.Red);
            }

        }
	}
}

