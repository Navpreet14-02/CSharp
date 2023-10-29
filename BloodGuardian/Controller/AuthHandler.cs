using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian
{
    internal class AuthHandler
    {


        public static void Register(DBHandler Database)
        {
            Donor newDonor = DonorUI.CreateUser();

            Database.AddDonor(newDonor);


            if(newDonor.Role == roles.BloodBankManager)
            {
                BloodBank bank = BloodBank.createBloodBank(newDonor);
                Console.WriteLine();

                Database.AddBloodBank(bank);
            }


            Console.WriteLine("You are Registered. ");
            Console.WriteLine();
            App.Start(Database);


            //return newDonor;

        } 

        public static void Login(DBHandler Database)
        {

            string email;

            while (true)
            {
                Console.Write("Enter your Email: ");

                string emailInput = Console.ReadLine();
                try
                {
                    Validation.ValidateEmail(emailInput);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                email = emailInput;
                Console.WriteLine("--------------------------------");

                break;

            }

            string password;

            while (true)
            {

                Console.Write("Enter your Password: ");
                string passwordInput = Console.ReadLine();

                try
                {
                    Validation.ValidatePassword(passwordInput);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                password = passwordInput;
                Console.WriteLine("--------------------------------");

                break;

            }


            var donor = Donor.FindDonor(email,password);
            if (donor!=null)
            {
                Console.WriteLine("You are logged in.");
                Console.WriteLine();
                donor.LoggedIn = true;
                if (donor.Role == roles.Admin)
                {
                    AdminUI.AdminMenu(Database, donor);
                }
                else if (donor.Role == roles.BloodBankManager)
                {
                    BloodBankManagerUI.BloodBankManagerMenu(Database, donor);
                }
                else
                {
                    DonorUI.DonorMenu(Database, donor);
                }
            }
            else
            {
                Console.WriteLine("Enter valid details. If you are a new user, then register first.");
                App.Start(Database);
            }




            //return donor;

        }
    }
}
