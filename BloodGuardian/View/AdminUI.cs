using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View
{
    internal class AdminUI
    {

        public enum AdminOptions
        {
            UpdateProfile=1,
            AddNewAdmin=2,
            SeeAllDonors=3,
            RemoveDonor=4,
            SeeAllBloodBanks=5,
            RemoveBloodBank=6,
            SeeBloodDonationCamps=7,
            RemoveBloodDonationCamps=8,
            SignOut=9,
        }

        public static void AdminMenu(DBHandler database, Donor d)
        {



            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile.");
            Console.WriteLine("2:Add New Admin");
            Console.WriteLine("3:See All Donors");
            Console.WriteLine("4:Remove a Donor");
            Console.WriteLine("5:See all Blood Banks.");
            Console.WriteLine("6:Remove a Blood Bank.");
            Console.WriteLine("7:See all Blood Donation Camps.");
            Console.WriteLine("8:Remove a Blood Donation Camp.");
            Console.WriteLine("9:SignOut.");

            Console.WriteLine("*********************");
            Console.WriteLine("Enter your input: ");
            var input = Enum.Parse<AdminOptions>(Console.ReadLine());

            switch (input)
            {
                case AdminOptions.UpdateProfile:
                    Donor.UpdateProfile(database, d);
                    AdminMenu(database, d) ;
                    break;

                case AdminOptions.AddNewAdmin:
                    Donor.AddAdmin(database, d);
                    break;

                case AdminOptions.SeeAllDonors:
                    Donor.ViewDonors(database, d);
                    AdminMenu(database, d);
                    break;

                case AdminOptions.RemoveDonor:
                    Donor.RemoveDonor(database, d);
                    AdminMenu(database, d);
                    break;

                case AdminOptions.SeeAllBloodBanks:
                    BloodBank.ViewBloodBanks(database, d);
                    AdminMenu(database, d);
                    break;

                case AdminOptions.RemoveBloodBank:
                    BloodBank.RemoveBloodBank(database, d);
                    AdminMenu(database, d);
                    break;

                case AdminOptions.SeeBloodDonationCamps:
                    BloodDonationCamp.ViewBloodDonationCamps(database, d);
                    AdminMenu(database, d);
                    break;

                case AdminOptions.RemoveBloodDonationCamps:
                    BloodDonationCamp.RemoveBloodDonationCamp(database, d);
                    AdminMenu(database, d);
                    break;

                case AdminOptions.SignOut:
                    Donor.SignOut();
                    App.Start(database);
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    AdminMenu(database, d);
                    break;



            }  


        }

        public static Donor InputAdmin(DBHandler database, Donor d)
        {

            Donor newAdmin = new Donor();

            Console.Write("Enter Admin Name: ");
            newAdmin.Name = Console.ReadLine();

            Console.Write("Enter Admin Age: ");
            newAdmin.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Admin Phone: ");
            newAdmin.Phone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Admin Email: ");
            newAdmin.Email = Console.ReadLine();

            Console.Write("Enter Admin State: ");
            newAdmin.State = Console.ReadLine();

            Console.Write("Enter Admin City: ");
            newAdmin.City = Console.ReadLine();

            Console.Write("Enter Admin Address: ");
            newAdmin.Address = Console.ReadLine();

            Console.Write("Enter Admin Password: ");
            newAdmin.Password = Console.ReadLine();

            Console.Write("Enter Admin Blood Group - A+,A-,B+,B-,O+,O-,AB+,AB-: ");
            newAdmin.BloodGrp = Console.ReadLine();

            return newAdmin;

        }
    }
}
