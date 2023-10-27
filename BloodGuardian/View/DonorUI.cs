using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View
{
    internal static class DonorUI
    {
        public static void DonorMenu(DBHandler Database, Donor d)
        {

            Donor currDonor = d;

            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile");
            Console.WriteLine("2:Search Blood Banks Near you.");
            Console.WriteLine("3:Search Blood Donation Camps Near You.");

            Console.Write("Enter your Input:");
            var input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    currDonor = Donor.UpdateProfile(Database, currDonor);
                    break;
                case 2:
                    Search.SearchBloodBanks(Database, currDonor);
                    break;
                case 3:

                    break;
            }



        }

        public static Donor CreateUser()
        {
            Donor newDonor = new Donor();
            Console.Write("Enter your Name: ");
            newDonor.Name = Console.ReadLine();

            Console.Write("Enter your Age: ");
            newDonor.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your Phone: ");
            newDonor.Phone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter your Email: ");
            newDonor.Email = Console.ReadLine();

            Console.Write("Enter your Role - Donor or BloodBankManager: ");
            newDonor.Role = Enum.Parse<roles>(Console.ReadLine());

            Console.Write("Enter your State (In case you are a Blood Bank Manager, Enter its State ): ");
            newDonor.State = Console.ReadLine();

            Console.Write("Enter your City (In case you are a Blood Bank Manager, Enter its City ): ");
            newDonor.City = Console.ReadLine();

            Console.Write("Enter your Address (In case you are a Blood Bank Manager, Enter its Address ): ");
            newDonor.Address = Console.ReadLine();

            Console.Write("Enter your Password: ");
            newDonor.Password = Console.ReadLine();

            Console.Write("Enter your Blood Group - A+,A-,B+,B-,O+,O-,AB+,AB-: ");
            newDonor.BloodGrp = Console.ReadLine();


            return newDonor;
        }
    }
}
