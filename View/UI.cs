using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View.Interfaces;


namespace BloodGuardian.View
{
    public static class UI
    {

        private static IRequest _requestController;
        private static IAuth _authController;
        private static IDonor _donorController;
        private static IBloodBank _bankController;
        private static IBloodDonationCamp _campController;

        private static ISearch _search;
        private static IDonorDashboard _donorDashboard;
        private static IAdminDashboard _adminDashboard;
        private static IBloodBankManagerDashboard _bankManagerDashboard;
        private static IAuthDashboard _authDashboard;
        private static IHomeDashboard _homeDashboard;



        static UI()
        {
            _requestController = new RequestController(RequestDBHandler.Instance);
            _authController = new AuthController(DonorDBHandler.Instance);
            _donorController = new DonorController(BloodBankDBHandler.Instance, DonorDBHandler.Instance);
            _bankController = new BloodBankController(BloodBankDBHandler.Instance, DonorDBHandler.Instance);
            _campController = new BloodDonationCampController(BloodBankDBHandler.Instance);

            _bankManagerDashboard = new BloodBankManagerDashboard(_bankController, _campController);
            _search = new Search(_bankController);
            _donorDashboard = new DonorDashboard(_donorController);
            _adminDashboard = new AdminDashboard((IAdmin)_donorController, (IRemoveRequest)_requestController, (IAdminBloodBank)_bankController, (IAdminBloodDonationCamp)_campController);
            _homeDashboard = new BloodRequestDashboard(_requestController);
            _authDashboard = new AuthDashboard(_authController, _bankManagerDashboard);
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
                    _authDashboard.Login();
                    break;

                case HomePageOptions.Register:
                    _authDashboard.Register();
                    break;

                case HomePageOptions.SeeBloodRequests:
                    _homeDashboard.ViewBloodRequests();
                    Start();
                    break;

                case HomePageOptions.AddBloodRequest:
                    _homeDashboard.CreateBloodRequest();
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
                    currDonor = _donorDashboard.UpdateProfile(currDonor);
                    DonorUI(currDonor);
                    break;
                case DonorOptions.SearchBloodBanks:
                    _search.SearchBloodBanks(currDonor);
                    DonorUI(currDonor);
                    break;
                case DonorOptions.SearchBloodDonationCamps:
                    _search.SearchBloodDonationCamp(currDonor);
                    DonorUI(currDonor);
                    break;
                case DonorOptions.SeeBloodDonationHistory:
                    _donorDashboard.ViewBloodDonationHistory(currDonor);
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

            BloodBank bank = _bankController.FindBloodBankByDonor(currDonor);

            Console.WriteLine(bank.ManagerUserName);

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
                    var oldDonor = d;
                    currDonor = _donorDashboard.UpdateProfile(currDonor);
                    _bankManagerDashboard.UpdateBloodBankDetails(oldDonor, currDonor);
                    BloodBankManagerUI(currDonor);
                    break;

                case BloodBankManagerOptions.AddBloodDepositRecord:
                    _bankManagerDashboard.CreateBloodDepositRecord(bank);
                    BloodBankManagerUI(currDonor);
                    break;

                case BloodBankManagerOptions.AddBloodWithdrawRecord:
                    _bankManagerDashboard.CreateBloodWithdrawRecord(bank);
                    BloodBankManagerUI(currDonor);
                    break;
                case BloodBankManagerOptions.OrganizeBloodDonationCamp:
                    _bankManagerDashboard.CreateBloodDonationCamp(bank, currDonor);
                    BloodBankManagerUI(currDonor);
                    break;

                case BloodBankManagerOptions.SeeBloodDonationCamp:
                    _bankManagerDashboard.ViewBloodDonationCamps(bank, currDonor);
                    BloodBankManagerUI(currDonor);
                    break;

                case BloodBankManagerOptions.RemoveBloodDonationCamp:
                    _bankManagerDashboard.RemoveBloodDonationCamps(bank, currDonor);
                    BloodBankManagerUI(currDonor);
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

            Donor currDonor = d;


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
                    currDonor = _donorDashboard.UpdateProfile(currDonor);
                    AdminUI(currDonor);
                    break;

                case AdminOptions.AddNewAdmin:
                    _adminDashboard.CreateAdmin(currDonor);
                    AdminUI(currDonor);
                    break;

                case AdminOptions.ManageDonors:
                    AdminManageDonorUI(currDonor);
                    break;

                case AdminOptions.ManageBloodBanks:
                    AdminManageBloodBankUI(currDonor);
                    break;

                case AdminOptions.RemoveRequest:
                    _homeDashboard.ViewBloodRequests();
                    _adminDashboard.RemoveRequest(currDonor);
                    AdminUI(currDonor);
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

        public static void AdminManageDonorUI(Donor d)
        {

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
                AdminManageDonorUI(d);
            }

            option = Enum.Parse<AdminManageDonorOptions>(input);

            switch (option)
            {


                case AdminManageDonorOptions.SeeAllDonors:
                    _adminDashboard.AdminViewDonors(d);
                    AdminManageDonorUI(d);

                    break;

                case AdminManageDonorOptions.RemoveDonor:
                    _adminDashboard.RemoveDonor(d);
                    AdminManageDonorUI(d);

                    break;

                case AdminManageDonorOptions.GoBack:
                    AdminUI(d);
                    break;

                default:
                    Console.WriteLine(Message.InvalidOption);
                    AdminManageDonorUI(d);
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
                    _adminDashboard.AdminViewBloodBanks(d);
                    AdminManageBloodBankUI(d);
                    break;

                case AdminManageBloodBankOptions.RemoveBloodBank:
                    _adminDashboard.RemoveBloodBank(d);
                    AdminManageBloodBankUI(d);
                    break;

                case AdminManageBloodBankOptions.SeeBloodDonationCamps:
                    _adminDashboard.ViewBloodDonationCamps(d);
                    AdminManageBloodBankUI(d);
                    break;

                case AdminManageBloodBankOptions.RemoveBloodDonationCamps:
                    _adminDashboard.RemoveBloodDonationCamp(d);
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
