using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static BloodGuardian.View.App;
using BloodGuardian.Common;
using BloodGuardian.Controller;

namespace BloodGuardian.View
{
    public class AdminUI
    {


        public static void AdminMenu(Donor d)
        {


            AuthHandler authHandler = new AuthHandler();
            BloodDonationCampController campController = new BloodDonationCampController();
            BloodBankController bankController = new BloodBankController();
            DonorController donorController = new DonorController();
            RequestController requestController = new RequestController();

            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.PrintAdminOptions);
            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();



            AdminOptions option;
            while (true)
            {
                Console.WriteLine(Message.SingleDashDesign);
                Console.Write(Message.EnterInput);
                string input = Console.ReadLine();

                AdminOptions result;
                if (input == string.Empty || !Enum.TryParse<AdminOptions>(input,out  result))
                {

                    Console.WriteLine(Message.EnterValidOption);
                    continue;
                }

                option = Enum.Parse<AdminOptions>(input);
                break;

            }

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
                    donorController.ViewDonors(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.RemoveDonor:
                    donorController.RemoveDonor(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.SeeAllBloodBanks:
                    bankController.ViewBloodBanks(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.RemoveBloodBank:
                    bankController.RemoveBloodBank(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.SeeBloodDonationCamps:
                    campController.ViewBloodDonationCamps(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.RemoveBloodDonationCamps:
                    campController.RemoveBloodDonationCampAdmin(d);
                    AdminMenu(d);
                    break;

                case AdminOptions.RemoveRequest:
                    requestController.RemoveRequest(d);
                    AdminMenu(d);

                    break;

                case AdminOptions.SignOut:
                    authHandler.SignOut(d);
                    App.Start();
                    break;
                default:
                    Console.WriteLine(Message.InvalidOption);
                    AdminMenu(d);
                    break;



            }  


        }

        public static Donor InputAdmin(Donor d)
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
