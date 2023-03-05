using System;
using System.Text;
using Core.Constants;
using Core.Helpers;
using Data;
using Presentation.Services;

namespace Presentation
{
    public static class Program
    {
        private readonly static OwnerService _ownerService;
        private readonly static DrugStoreService _drugStoreService;
        private readonly static DrugService _drugService;
        private readonly static DruggistService _druggistService;
        private readonly static AdminService _adminService;


        static Program()
        {
            DbInitializer.SeedAdmins();

            _ownerService = new OwnerService();
            _drugStoreService = new DrugStoreService();
            _drugService = new DrugService();
            _druggistService = new DruggistService();
            _adminService = new AdminService();

        }
        static void Main()
        {

            Console.OutputEncoding = Encoding.UTF8;
            ConsoleHelper.WriteWithColor("---W E L C O M E---", ConsoleColor.Blue);

        AuthorizeDesc: var admin = _adminService.Authenticate();
            while (true)
            {
            MainMenuDescription:
                ConsoleHelper.WriteWithColor("1- Owners", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor("2- DrugStores", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor("3- Druggists", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor("4- Drugs", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor("0- Logout", ConsoleColor.Yellow);

                ConsoleHelper.WriteWithColor("Select your option", ConsoleColor.Cyan);
                int option;
                bool issucceeded = int.TryParse(Console.ReadLine(), out option);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Option is not in a correct format", ConsoleColor.Red);
                    goto MainMenuDescription;
                }

                switch (option)
                {
                    case (int)MainMenuOptions.Owners:
                        while (true)
                        {
                        OwnersOptionDescription: ConsoleHelper.WriteWithColor("1- Create Owner", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("2- Update Owner", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("3- Delete Owner", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("4- Get All Owners-", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("0- Go to Main Menu", ConsoleColor.Yellow);


                            ConsoleHelper.WriteWithColor("Select your option", ConsoleColor.Cyan);

                            int ownerOption;
                            issucceeded = int.TryParse(Console.ReadLine(), out ownerOption);
                            if (!issucceeded)
                            {
                                ConsoleHelper.WriteWithColor("Your option is not in a correct format", ConsoleColor.Red);
                                goto OwnersOptionDescription;
                            }

                            switch (ownerOption)
                            {
                                case (int)OwnerOptions.CreateOwner:
                                    _ownerService.Create();
                                    break;
                                case (int)OwnerOptions.UpdateOwner:
                                    _ownerService.Update();
                                    break;
                                case (int)OwnerOptions.DeleteOwner:
                                    _ownerService.Delete();
                                    break;
                                case (int)OwnerOptions.GetAllOwners:
                                    _ownerService.GetAll();
                                    break;
                                case (int)OwnerOptions.GoToMainMenu:
                                    goto MainMenuDescription;
                                default:
                                    ConsoleHelper.WriteWithColor("There is not any option like that", ConsoleColor.Red);
                                    goto OwnersOptionDescription;
                            }
                        }
                    case (int)MainMenuOptions.DrugStores:
                        while (true)
                        {
                        DrugStoresOptionDescription: ConsoleHelper.WriteWithColor("1- Create DrugStore", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("2- Update DrugStore", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("3- Delete DrugStore", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("4- Get All DrugStores", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("5- Get All DrugStores By Owner", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("6- Sale", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("0- GoToMainMenu", ConsoleColor.Yellow);

                            ConsoleHelper.WriteWithColor("Select your option", ConsoleColor.Cyan);

                            int drugStoresOption;
                            issucceeded = int.TryParse(Console.ReadLine(), out drugStoresOption);
                            if (!issucceeded)
                            {
                                ConsoleHelper.WriteWithColor("Your option is not in a correct format", ConsoleColor.Red);
                                goto DrugStoresOptionDescription;
                            }

                            switch (drugStoresOption)
                            {
                                case (int)DrugStoreOptions.CreateDrugStore:
                                    _drugStoreService.Create();
                                    break;
                                case (int)DrugStoreOptions.UpdateDrugStore:
                                    _drugStoreService.Update();
                                    break;
                                case (int)DrugStoreOptions.DeleteDrugStore:
                                    _drugStoreService.Delete();
                                    break;
                                case (int)DrugStoreOptions.GetAllDrugStores:
                                    _drugStoreService.GetAll();
                                    break;
                                case (int)DrugStoreOptions.GetAllDrugStoresByOwner:
                                    _drugStoreService.GetAllByOwner();
                                    break;
                                case (int)DrugStoreOptions.Sale:
                                    _drugStoreService.Sale();
                                    break;
                                case (int)DrugStoreOptions.GoToMainMenu:
                                    goto MainMenuDescription;
                                default:
                                    ConsoleHelper.WriteWithColor("There is not any option like that", ConsoleColor.Red);
                                    goto DrugStoresOptionDescription;


                            }

                        }
                    case (int)MainMenuOptions.Druggists:
                        while (true)
                        {
                        DruggistsOptionDescription: ConsoleHelper.WriteWithColor("1- Create Druggist", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("2- Update Druggist", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("3- Delete Druggist", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("4- Get All Druggists", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("5- Get All Druggists by Drug store", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("0- GoToMainMenu", ConsoleColor.Yellow);

                            ConsoleHelper.WriteWithColor("Select your option", ConsoleColor.Cyan);
                            int druggistOption;
                            issucceeded = int.TryParse(Console.ReadLine(), out druggistOption);
                            if (!issucceeded)
                            {
                                ConsoleHelper.WriteWithColor("Your option is not in a correct format", ConsoleColor.Red);
                                goto DruggistsOptionDescription;
                            }

                            switch (druggistOption)
                            {
                                case (int)DruggistOptions.CreateDruggist:
                                    _druggistService.Create();
                                    break;
                                case (int)DruggistOptions.UpdateDruggist:
                                    _druggistService.Update();
                                    break;
                                case (int)DruggistOptions.DeleteDruggist:
                                    _druggistService.Delete();
                                    break;
                                case (int)DruggistOptions.GetAllDruggists:
                                    _druggistService.GetAll();
                                    break;
                                case (int)DruggistOptions.GetAllDruggistsByDrugStore:
                                    _druggistService.GetAllByDrugStore();
                                    break;
                                case (int)DruggistOptions.GoToMainMenu:
                                    goto MainMenuDescription;
                                default:
                                    ConsoleHelper.WriteWithColor("There is not any option like that", ConsoleColor.Red);
                                    goto DruggistsOptionDescription;
                            }

                        }
                    case (int)MainMenuOptions.Drugs:
                        while (true)
                        {
                        DrugOptionDescription: ConsoleHelper.WriteWithColor("1- Create Drug", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("2- Update Drug", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("3- Delete Drug", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("4- Get All Drugs", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("5- Get All Drugs by Drug store", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("6- Get All Filtered Drugs", ConsoleColor.Yellow);
                            ConsoleHelper.WriteWithColor("0- GoToMainMenu", ConsoleColor.Yellow);

                            ConsoleHelper.WriteWithColor("Select your option", ConsoleColor.Blue);
                            int drugOption;
                            issucceeded = int.TryParse(Console.ReadLine(), out drugOption);
                            if (!issucceeded)
                            {
                                ConsoleHelper.WriteWithColor("Your option is not in a correct format", ConsoleColor.Red);
                                goto DrugOptionDescription;
                            }

                            switch (drugOption)
                            {
                                case (int)DrugOptions.CreateDrug:
                                    _drugService.Create();
                                    break;
                                case (int)DrugOptions.UpdateDrug:
                                    _drugService.Update();
                                    break;
                                case (int)DrugOptions.DeleteDrug:
                                    _drugService.Delete();
                                    break;
                                case (int)DrugOptions.GetAllDrugs:
                                    _drugService.GetAll();
                                    break;
                                case (int)DrugOptions.GetAllDrugsByDrugStore:
                                    _drugService.GetAllByDrugStore();
                                    break;
                                case (int)DrugOptions.GetAllFilteredDrugs:
                                    _drugService.Filter();
                                    break;
                                case (int)DrugOptions.GoToMainMenu:
                                    goto MainMenuDescription;
                                default:
                                    ConsoleHelper.WriteWithColor("There is not any option like that", ConsoleColor.Red);
                                    goto DrugOptionDescription;
                            }

                        }
                    case (int)MainMenuOptions.Logout:
                        goto AuthorizeDesc;
                    default:
                        goto MainMenuDescription;
                }
            }       
        }
    }
}