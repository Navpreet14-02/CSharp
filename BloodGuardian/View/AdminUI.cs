using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Models;

namespace BloodGuardian.View
{
    public class AdminUI
    {


        public static void AdminMenu(Donor d)
        {

            IAdmin donorController = new DonorController();
            IRemoveRequest requestController = new RequestController();


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
                AdminMenu(d);
            }

            option = Enum.Parse<AdminOptions>(input);


            switch (option)
            {
                case AdminOptions.UpdateProfile:
                    donorController.UpdateProfile(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.AddNewAdmin:
                    donorController.AddAdmin(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.ManageDonors:
                    AdminManageDonorUI(d);
                    break;

                case AdminOptions.ManageBloodBanks:
                    AdminManageBloodBankUI(d);
                    break;

                case AdminOptions.RemoveRequest:
                    requestController.AdminRemoveRequest(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.SignOut:
                    Console.WriteLine(Message.SigningOut);
                    App.Start();
                    break;

                default:
                    Console.WriteLine(Message.InvalidOption);
                    AdminMenu(d);
                    break;



            }


        }

        public static void AdminManageDonorUI(Donor d)
        {
            IAdmin donorController = new DonorController();

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
                AdminMenu(d);
            }

            option = Enum.Parse<AdminManageDonorOptions>(input);

            switch (option)
            {


                case AdminManageDonorOptions.SeeAllDonors:
                    donorController.AdminViewDonors(d);
                    AdminManageDonorUI(d);
                    break;

                case AdminManageDonorOptions.RemoveDonor:
                    donorController.AdminRemoveDonor(d);
                    AdminManageDonorUI(d);
                    break;

                case AdminManageDonorOptions.GoBack:
                    AdminMenu(d);
                    break;

                default:
                    Console.WriteLine(Message.InvalidOption);
                    AdminManageDonorUI(d);
                    break;




            }
        }


        public static void AdminManageBloodBankUI(Donor d)
        {
            IAdminBloodBank bankController = new BloodBankController();
            IAdminBloodDonationCamp campController = new BloodDonationCampController();

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
                AdminMenu(d);
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
                    AdminMenu(d);
                    break;

                default:
                    Console.WriteLine(Message.InvalidOption);
                    AdminManageBloodBankUI(d);
                    break;




            }
        }
        public Donor InputAdminDetails()
        {

            Donor newAdmin = new Donor();

            Console.WriteLine(Message.EnterAdminName);
            newAdmin.Name = InputHandler.InputName(false);

            Console.WriteLine(Message.EnterAdminUserName);
            newAdmin.UserName = InputHandler.InputUserName(false);

            Console.WriteLine(Message.EnterAdminAge);
            newAdmin.Age = InputHandler.InputAge(false);


            Console.WriteLine(Message.EnterAdminPhone);
            newAdmin.Phone = InputHandler.InputPhone(false);

            Console.WriteLine(Message.EnterAdminEmail);
            newAdmin.Email = InputHandler.InputEmail(false);

            Console.WriteLine(Message.EnterAdminState);
            newAdmin.State = InputHandler.InputState(false);

            Console.WriteLine(Message.EnterAdminCity);
            newAdmin.City = InputHandler.InputCity(false);


            Console.WriteLine(Message.EnterAdminAddress);
            newAdmin.Address = InputHandler.InputAddress(false);


            Console.WriteLine(Message.EnterAdminPassword);
            newAdmin.Password = InputHandler.InputPassword(false);

            Console.WriteLine(Message.EnterBloodGroup);
            newAdmin.BloodGrp = InputHandler.InputBloodGroup(false);


            return newAdmin;

        }
    }
}
