using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static BloodGuardian.View.App;

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
            RemoveRequest=9,
            SignOut=10,
        }

        public static void AdminMenu(DBHandler database, Donor d)
        {


            Console.WriteLine();
            Console.WriteLine("============================="); 
            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile.");
            Console.WriteLine("2:Add New Admin");
            Console.WriteLine("3:See All Donors");
            Console.WriteLine("4:Remove a Donor");
            Console.WriteLine("5:See all Blood Banks.");
            Console.WriteLine("6:Remove a Blood Bank.");
            Console.WriteLine("7:See all Blood Donation Camps.");
            Console.WriteLine("8:Remove a Blood Donation Camp.");
            Console.WriteLine("9:Remove a Request.");
            Console.WriteLine("10:SignOut.");
            Console.WriteLine("=============================");
            Console.WriteLine();



            AdminOptions option;
            while (true)
            {
                Console.WriteLine("----------------------");
                Console.Write("Enter your Input:");
                string input = Console.ReadLine();

                AdminOptions result;
                if (input == string.Empty || !Enum.TryParse<AdminOptions>(input,out  result))
                {

                    Console.WriteLine("Enter Valid Option.");
                    continue;
                }

                option = Enum.Parse<AdminOptions>(input);
                //Console.WriteLine("*********************"); 
                break;

            }

            switch (option)
            {
                case AdminOptions.UpdateProfile:
                    Donor.UpdateProfile(database, d);
                    AdminMenu(database, d);
                    break;

                case AdminOptions.AddNewAdmin:
                    Donor.AddAdmin(database, d);
                    AdminMenu(database, d);
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
                    BloodDonationCamp.RemoveBloodDonationCampAdmin(database, d);
                    AdminMenu(database, d);
                    break;

                case AdminOptions.RemoveRequest:
                    Request.RemoveRequest(database, d);
                    AdminMenu(database, d);

                    break;

                case AdminOptions.SignOut:
                    Donor.SignOut(d);
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

            while (true)
            {

                Console.Write("Enter Admin Name: ");
                string name = Console.ReadLine();
                try
                {
                    Validation.ValidateName(name);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                newAdmin.Name = name;
                Console.WriteLine("--------------------------------");
                break;

            }


            while (true)
            {

                Console.Write("Enter Admin Age: ");
                string age = Console.ReadLine();
                try
                {
                    Validation.ValidateAge(age);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                newAdmin.Age = Convert.ToInt32(age);
                Console.WriteLine("--------------------------------");
                break;

            }


            while (true)
            {
                Console.Write("Enter Admin Phone: ");
                string phone = Console.ReadLine();
                try
                {
                    Validation.ValidatePhone(phone);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                newAdmin.Phone = Convert.ToInt64(phone);
                Console.WriteLine("--------------------------------");

                break;

            }

            while (true)
            {
                Console.Write("Enter Admin Email: ");

                string email = Console.ReadLine();
                try
                {
                    Validation.ValidateEmail(email);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                newAdmin.Email = email;
                Console.WriteLine("--------------------------------");

                break;

            }

            while (true)
            {

                Console.Write("Enter Admin State: ");
                string state = Console.ReadLine();

                try
                {
                    Validation.ValidateState(state);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                newAdmin.State = state;
                Console.WriteLine("--------------------------------");
                break;

            }

            while (true)
            {


                Console.Write("Enter Admin City: ");
                string city = Console.ReadLine();
                try
                {
                    Validation.ValidateCity(city);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                newAdmin.City = city;
                Console.WriteLine("--------------------------------");

                break;

            }

            while (true)
            {

                Console.Write("Enter Admin Address: ");

                string address = Console.ReadLine();

                try
                {
                    Validation.ValidateAddress(address);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                newAdmin.Address = address;
                Console.WriteLine("--------------------------------");
                break;

            }


            while (true)
            {

                Console.Write("Enter Admin Password: ");
                string password = Console.ReadLine();

                try
                {
                    Validation.ValidatePassword(password);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                newAdmin.Password = password;
                Console.WriteLine("--------------------------------");

                break;

            }

            while (true)
            {

                Console.Write("Enter your Blood Group - A+,A-,B+,B-,O+,O-,AB+,AB-: ");
                string bloodgrp = Console.ReadLine();

                try
                {
                    Validation.ValidateBloodGroup(bloodgrp);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                newAdmin.BloodGrp = bloodgrp;
                Console.WriteLine("--------------------------------");

                break;

            }


            return newAdmin;

        }
    }
}
