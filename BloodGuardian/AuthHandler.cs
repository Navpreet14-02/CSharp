using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian
{
    internal class AuthHandler
    {


        public static Donor Register()
        {
            Donor newDonor = Donor.CreateUser();

            DBHandler.AddDonor(newDonor);


            if(newDonor.Role == roles.BloodBankManager)
            {
                BloodBank bank = BloodBank.createBB(newDonor);
                Console.WriteLine();

                DBHandler.AddBloodBank(bank);
            }


            //Console.WriteLine("You are Registered. ");

            return newDonor;

        }

        public static Donor Login()
        {
            Console.Write("Enter your Email:");
            string email = Console.ReadLine();


            Console.Write("Enter your Password:");
            string password = Console.ReadLine();


            var donor = DBHandler.FindDonor(email,password);
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
