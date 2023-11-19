using BloodGuardian.Common.Enums;
using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Controller;
using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View
{
    internal static class UI
    {

        private static IRequest _requestController;
        private static IAuth _authController;
        private static IDonor _donorController;
        private static IBloodBank _bankController;
        private static IBloodDonationCamp _campController;
        private static ISearch _search;


        static UI()
        {
            _requestController = new RequestController(RequestDBHandler.Instance,new HomeView());
            _authController = new AuthController(DonorDBHandler.Instance,BloodBankDBHandler.Instance);
            _donorController = new DonorController(new DonorView(), BloodBankDBHandler.Instance, DonorDBHandler.Instance);
            _bankController = new BloodBankController(BloodBankDBHandler.Instance, DonorDBHandler.Instance);
            _campController = new BloodDonationCampController(BloodBankDBHandler.Instance);
            _search = new Search(_bankController);
        }

        public static void Start()
        {

            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);

            Console.WriteLine(Message.PrintHomePageOptions);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();



            HomePageOptions option;

            Console.WriteLine(Message.SingleDashDesign);
            Console.Write(Message.EnterInput);
            string input = Console.ReadLine();

            HomePageOptions result;
            if (input == string.Empty || !Enum.TryParse<HomePageOptions>(input, out result))
            {
                Console.WriteLine(Message.EnterValidOption);
                Start();
            }

            option = Enum.Parse<HomePageOptions>(input);


            switch (option)
            {

                case HomePageOptions.Login:
                    _authController.Login();
                    break;

                case HomePageOptions.Register:
                    _authController.Register();
                    break;

                case HomePageOptions.SeeBloodRequests:
                    _requestController.ViewBloodRequests();
                    Start();
                    break;

                case HomePageOptions.AddBloodRequest:
                    _requestController.AddBloodRequest();
                    Start();
                    break;

                case HomePageOptions.SearchBlood:
                    _search.SearchBlood();
                    Start();
                    break;

                case HomePageOptions.Exit:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine(Message.EnterValidOption);
                    Start();
                    break;
            }
        }


        public static void DonorUI(Donor d)
        {

            Donor currDonor = d;

            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);

            Console.WriteLine(Message.PrintDonorOptions);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();


            DonorOptions option;

            Console.WriteLine(Message.SingleDashDesign);
            Console.Write(Message.EnterInput);
            string input = Console.ReadLine();

            DonorOptions result;
            if (input == string.Empty || !Enum.TryParse<DonorOptions>(input, out result))
            {
                Console.WriteLine(Message.EnterValidOption);
                DonorUI(d);
            }

            option = Enum.Parse<DonorOptions>(input);


            switch (option)
            {
                case DonorOptions.UpdateProfile:
                    currDonor = _donorController.UpdateProfile(currDonor);
                    DonorUI(currDonor);
                    break;
                case DonorOptions.SearchBloodBanks:
                    _search.SearchBloodBanks(currDonor);
                    DonorUI(currDonor);
                    break;
                case DonorOptions.SearchBloodDonationCamps:
                    _search.SearchBloodDonationCamp(d);
                    DonorUI(currDonor);
                    break;
                case DonorOptions.SeeBloodDonationHistory:
                    _donorController.ViewBloodDonationHistory(d);
                    DonorUI(currDonor);
                    break;
                case DonorOptions.SignOut:
                    Console.WriteLine(Message.SigningOut);
                    Start();
                    break;
                default:
                    Console.WriteLine(Message.EnterValidOption);
                    DonorUI(d);
                    break;
            }



        }


        public static void BloodBankManagerUI(Donor d)
        {


            Donor currDonor = d;

            BloodBank bank = _bankController.FindBloodBank(currDonor);


            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);

            Console.WriteLine(Message.PrintBloodBankManagerOptions);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();



            BloodBankManagerOptions option;

            Console.WriteLine(Message.SingleDashDesign);
            Console.Write(Message.EnterInput);
            string input = Console.ReadLine();

            BloodBankManagerOptions result;
            if (input == string.Empty || !Enum.TryParse<BloodBankManagerOptions>(input, out result))
            {
                Console.WriteLine(Message.EnterValidOption);
                BloodBankManagerUI(d);
            }

            option = Enum.Parse<BloodBankManagerOptions>(input);

            switch (option)
            {
                case BloodBankManagerOptions.UpdateProfile:
                    IDonor donorController = new DonorController(new DonorView(), BloodBankDBHandler.Instance, DonorDBHandler.Instance);

                    var oldDonor = d;
                    currDonor = donorController.UpdateProfile(currDonor);
                    _bankController.UpdateBloodBankDetails(oldDonor, currDonor);
                    BloodBankManagerUI(d);
                    break;

                case BloodBankManagerOptions.AddBloodDepositRecord:
                    _bankController.UpdateDepositBloodRecord(bank);
                    BloodBankManagerUI(d);
                    break;

                case BloodBankManagerOptions.AddBloodWithdrawRecord:
                    _bankController.UpdateWithdrawBloodRecord(bank);
                    BloodBankManagerUI(d);
                    break;
                case BloodBankManagerOptions.OrganizeBloodDonationCamp:
                    _campController.OrganizeBloodDonationCamps(bank, currDonor);
                    BloodBankManagerUI(d);
                    break;

                case BloodBankManagerOptions.SeeBloodDonationCamp:
                    _campController.GetBloodDonationCamps(bank, currDonor);
                    BloodBankManagerUI(d);
                    break;

                case BloodBankManagerOptions.RemoveBloodDonationCamp:
                    _campController.RemoveBloodDonationCamps(bank, currDonor);
                    BloodBankManagerUI(d);
                    break;

                case BloodBankManagerOptions.SignOut:
                    Console.WriteLine(Message.SigningOut);
                    Start();
                    break;

                default:
                    Console.WriteLine(Message.EnterValidOption);
                    BloodBankManagerUI(d);
                    break;
            }

        }


        public static void AdminUI(Donor d)
        {

            IAdmin donorController = new DonorController(new DonorView(), BloodBankDBHandler.Instance, DonorDBHandler.Instance);
            IRemoveRequest requestController = new RequestController(RequestDBHandler.Instance, new HomeView());


            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);

            Console.WriteLine(Message.PrintAdminOptions);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();


            AdminOptions option;

            Console.WriteLine(Message.SingleDashDesign);
            Console.Write(Message.EnterInput);
            string input = Console.ReadLine();

            AdminOptions result;
            if (input == string.Empty || !Enum.TryParse<AdminOptions>(input, out result))
            {
                Console.WriteLine(Message.EnterValidOption);
                AdminUI(d);
            }

            option = Enum.Parse<AdminOptions>(input);


            switch (option)
            {
                case AdminOptions.UpdateProfile:
                    donorController.UpdateProfile(d);
                    AdminUI(d);
                    break;

                case AdminOptions.AddNewAdmin:
                    donorController.AddAdmin(d);
                    AdminUI(d);
                    break;

                case AdminOptions.ManageDonors:
                    AdminManageDonorUI(d,donorController);
                    break;

                case AdminOptions.ManageBloodBanks:
                    AdminManageBloodBankUI(d);
                    break;

                case AdminOptions.RemoveRequest:
                    requestController.AdminRemoveRequest(d);
                    AdminUI(d);
                    break;

                case AdminOptions.SignOut:
                    Console.WriteLine(Message.SigningOut);
                    Start();
                    break;

                default:
                    Console.WriteLine(Message.InvalidOption);
                    AdminUI(d);
                    break;



            }


        }

        public static void AdminManageDonorUI(Donor d, IAdmin donorController)
        {
            //IAdmin donorController = new DonorController(new DonorView(), new BloodBankDBHandler(), new DonorDBHandler());

            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);

            Console.WriteLine(Message.PrintAdminManageDonorOptions);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();


            AdminManageDonorOptions option;

            Console.WriteLine(Message.SingleDashDesign);
            Console.Write(Message.EnterInput);
            string input = Console.ReadLine();

            AdminManageDonorOptions result;
            if (input == string.Empty || !Enum.TryParse<AdminManageDonorOptions>(input, out result))
            {
                Console.WriteLine(Message.EnterValidOption);
                AdminManageDonorUI(d,donorController);
            }

            option = Enum.Parse<AdminManageDonorOptions>(input);

            switch (option)
            {


                case AdminManageDonorOptions.SeeAllDonors:
                    donorController.AdminViewDonors(d);
                    AdminManageDonorUI(d, donorController);

                    break;

                case AdminManageDonorOptions.RemoveDonor:
                    donorController.AdminRemoveDonor(d);
                    AdminManageDonorUI(d, donorController);

                    break;

                case AdminManageDonorOptions.GoBack:
                    AdminUI(d);
                    break;

                default:
                    Console.WriteLine(Message.InvalidOption);
                    AdminManageDonorUI(d, donorController);
                    break;




            }
        }

        public static void AdminManageBloodBankUI(Donor d)
        {
            IAdminBloodBank bankController = new BloodBankController(BloodBankDBHandler.Instance, DonorDBHandler.Instance);
            IAdminBloodDonationCamp campController = new BloodDonationCampController(BloodBankDBHandler.Instance);

            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);

            Console.WriteLine(Message.PrintAdminManageBloodBankOptions);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();


            AdminManageBloodBankOptions option;

            Console.WriteLine(Message.SingleDashDesign);
            Console.Write(Message.EnterInput);
            string input = Console.ReadLine();

            AdminManageBloodBankOptions result;
            if (input == string.Empty || !Enum.TryParse<AdminManageBloodBankOptions>(input, out result))
            {
                Console.WriteLine(Message.EnterValidOption);
                AdminManageBloodBankUI(d);
            }

            option = Enum.Parse<AdminManageBloodBankOptions>(input);

            switch (option)
            {


                case AdminManageBloodBankOptions.SeeAllBloodBanks:
                    bankController.AdminViewBloodBanks(d);
                    AdminManageBloodBankUI(d);
                    break;

                case AdminManageBloodBankOptions.RemoveBloodBank:
                    bankController.AdminRemoveBloodBank(d);
                    AdminManageBloodBankUI(d);
                    break;

                case AdminManageBloodBankOptions.SeeBloodDonationCamps:
                    campController.AdminViewBloodDonationCamps(d);
                    AdminManageBloodBankUI(d);
                    break;

                case AdminManageBloodBankOptions.RemoveBloodDonationCamps:
                    campController.AdminRemoveBloodDonationCamp(d);
                    AdminManageBloodBankUI(d);
                    break;

                case AdminManageBloodBankOptions.GoBack:
                    AdminUI(d);
                    break;

                default:
                    Console.WriteLine(Message.InvalidOption);
                    AdminManageBloodBankUI(d);
                    break;




            }
        }



    }
}
