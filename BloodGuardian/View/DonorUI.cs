using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BloodGuardian.View.BloodBankManagerUI;
using BloodGuardian.Common;
using System.Data;
using BloodGuardian.Controller;

namespace BloodGuardian.View
{
    public class DonorUI
    {




        public static void DonorMenu(Donor d)
        {

            DonorController donorController = new DonorController();
            AuthHandler authHandler = new AuthHandler();

            Donor currDonor = d;

            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.PrintDonorOptions);
            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();


            DonorOptions option;
            while (true)
            {
                Console.WriteLine(Message.SingleDashDesign);
                Console.Write(Message.EnterInput);
                string input = Console.ReadLine();

                DonorOptions result;
                if (input == string.Empty || !Enum.TryParse<DonorOptions>(input, out result))
                {
                    Console.WriteLine(Message.EnterValidOption);
                    continue;
                }

                option = Enum.Parse<DonorOptions>(input);
                break;

            }

            switch (option)
            {
                case DonorOptions.UpdateProfile:
                    currDonor = donorController.UpdateProfile(currDonor);
                    DonorMenu(currDonor);
                    break;
                case DonorOptions.SearchBloodBanks:
                    Search.SearchBloodBanks(currDonor);
                    DonorMenu(currDonor);
                    break;
                case DonorOptions.SearchBloodDonationCamps:
                    Search.SearchBloodDonationCamp(d);
                    DonorMenu(currDonor);
                    break;
                case DonorOptions.SeeBloodDonationHistory:
                    donorController.ViewBloodDonationHistory(d);
                    DonorMenu(currDonor);
                    break;
                case DonorOptions.SignOut:
                    authHandler.SignOut(d);
                    App.Start();
                    break;
                default:
                    Console.WriteLine(Message.EnterValidOption);
                    DonorUI.DonorMenu(d);
                    break;
            }



        }

        public static Donor CreateUser()
        {

            DonorController donorController = new DonorController();
            AuthHandler authHandler = new AuthHandler();

            Donor newDonor = new Donor();


            Console.WriteLine(Message.EnterName);
            newDonor.Name = InputHandler.InputName(false);

            string uname;
            Console.WriteLine(Message.EnterUserName);
            while(true)
            {
                uname = InputHandler.InputUserName(false);
                if (donorController.FindDonor(uname, null) != null)
                {
                    Console.WriteLine(Message.EnterDifferentUserName);
                    continue;
                }

                break;

            }
            newDonor.UserName = uname;


            Console.WriteLine(Message.EnterAge);
            newDonor.Age = InputHandler.InputAge(false);


            Console.WriteLine(Message.EnterPhone);
            newDonor.Phone = InputHandler.InputPhone(false);


            Console.WriteLine(Message.EnterEmail);
            newDonor.Email = InputHandler.InputEmail(false);


            Console.WriteLine(Message.EnterRole);
            newDonor.Role =Enum.Parse<roles>(InputHandler.InputRole(false));


            Console.WriteLine(Message.EnterState);
            newDonor.State = InputHandler.InputState(false);


            Console.WriteLine(Message.EnterCity);
            newDonor.City = InputHandler.InputCity(false);



            Console.WriteLine(Message.EnterAddress);
            newDonor.Address =InputHandler.InputAddress(false);


            Console.WriteLine(Message.EnterPassword);
            newDonor.Password = InputHandler.InputPassword(false);


            Console.WriteLine(Message.EnterBloodGroup);
            newDonor.BloodGrp=InputHandler.InputBloodGroup(false);

            return newDonor;
        }


        public static Donor UpdatedUserInfo(Donor oldDonor)
        {


            Donor updatedDonor = new Donor();


            Console.WriteLine(Message.EnterName);
            String name = InputHandler.InputName(true);
            updatedDonor.Name = name==String.Empty?oldDonor.Name:name;


            Console.WriteLine(Message.EnterUserName);
            String uname = InputHandler.InputUserName(true);
            updatedDonor.UserName = uname == String.Empty ? oldDonor.UserName : uname;


            Console.WriteLine(Message.EnterAge);
            int age = InputHandler.InputAge(true);
            updatedDonor.Age = age==-1?oldDonor.Age: Convert.ToInt32(age);


            Console.WriteLine(Message.EnterPhone);
            long phone = InputHandler.InputPhone(true);
            updatedDonor.Phone = phone==-1?oldDonor.Phone:Convert.ToInt64(phone);


            Console.WriteLine(Message.EnterEmail);
            string email = InputHandler.InputEmail(true);
            updatedDonor.Email = email==String.Empty?oldDonor.Email:email;


            Console.WriteLine(Message.EnterState);
            string state = InputHandler.InputState(true);  
            updatedDonor.State = state==String.Empty?oldDonor.State:state;


            Console.WriteLine(Message.EnterCity);
            string city=InputHandler.InputCity(true);
            updatedDonor.City = city==String.Empty?oldDonor.City:city;


            Console.WriteLine(Message.EnterAddress);
            string address = InputHandler.InputAddress(true);
            updatedDonor.Address = address==String.Empty?oldDonor.Address:address;


            Console.WriteLine(Message.EnterPassword);
            Console.WriteLine();
            string password = InputHandler.InputPassword(true);
            updatedDonor.Password = password==String.Empty?oldDonor.Password:password;

            updatedDonor.Donorid = oldDonor.Donorid;

            updatedDonor.Role = oldDonor.Role;
            updatedDonor.BloodGrp = oldDonor.BloodGrp;

            return updatedDonor;
        }
    }
}
