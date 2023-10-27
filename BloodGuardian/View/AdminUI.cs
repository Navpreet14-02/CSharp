using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View
{
    internal class AdminUI
    {
        public static void AdminMenu(DBHandler database, Donor d)
        {

            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile.");
            Console.WriteLine("2:Add New Donor");
            Console.WriteLine("3:See All Donors");
            Console.WriteLine("4:Remove a Donor");
            Console.WriteLine("5:See all Blood Banks.");
            Console.WriteLine("6:Remove a Blood Bank.");
            Console.WriteLine("7:See all Blood Donation Camps.");
            Console.WriteLine("8:Remove a Blood Donation Camp.");

            Console.WriteLine();
            Console.WriteLine("Enter your input: ");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Donor.UpdateProfile(database, d);
                    break;
                case 2:
                    Donor.ViewDonors(database, d);
                    break;
                case 3:
                    Donor.RemoveDonor(database, d);
                    break;
                case 4:
                    BloodBank.ViewBloodBanks(database, d);
                    break;
                case 5:
                    BloodBank.RemoveBloodBank(database, d);
                    break;
                case 6:
                    BloodDonationCamp.ViewBloodDonationCamps(database, d);
                    break;
                case 7:
                    BloodDonationCamp.RemoveBloodDonationCamp(database, d);
                    break;

            }




        }
    }
}
