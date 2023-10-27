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


        public static Donor Register(DBHandler Database)
        {
            Donor newDonor = DonorUI.CreateUser();

            Database.AddDonor(newDonor);


            if(newDonor.Role == roles.BloodBankManager)
            {
                BloodBank bank = BloodBank.createBloodBank(newDonor);
                Console.WriteLine();

                Database.AddBloodBank(bank);
            }


            //Console.WriteLine("You are Registered. ");

            return newDonor;

        } 

        public static Donor Login(DBHandler Database)
        {
            Console.Write("Enter your Email:");
            string email = Console.ReadLine();


            Console.Write("Enter your Password:");
            string password = Console.ReadLine();


            var donor = Database.FindDonor(email,password);
            if (donor!=null)
            {
                Console.WriteLine("You are logged in.");
            }
            else
            {
                Console.WriteLine("Enter valid details. If you are a new user, then register first.");
            }

            return donor;

        }
    }
}
