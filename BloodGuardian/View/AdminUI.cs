using BloodGuardian.Models;
using BloodGuardian.Common;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;

namespace BloodGuardian.View
{
    public class AdminUI
    {


        public static void AdminMenu(Donor d)
        {


            IAdminBloodDonationCamp donationCampController = new BloodDonationCampController();
            IAdminBloodBank bankController = new BloodBankController();
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

                case AdminOptions.SeeAllDonors:
                    donorController.AdminViewDonors(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.RemoveDonor:
                    donorController.AdminRemoveDonor(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.SeeAllBloodBanks:
                    bankController.AdminViewBloodBanks(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.RemoveBloodBank:
                    bankController.AdminRemoveBloodBank(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.SeeBloodDonationCamps:
                    donationCampController.AdminViewBloodDonationCamps(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.RemoveBloodDonationCamps:
                    donationCampController.AdminRemoveBloodDonationCamp(d);
                    AdminMenu(d);
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

        public Donor InputAdmin(Donor d)
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
