using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BloodGuardian.View
{
    internal static class DonorUI
    {


        public enum DonorOptions
        {
            UpdateProfile=1,
            SearchBloodBanks=2,
            SearchBloodDonationCamps=3,
            SignOut=4,
        }

        public static void DonorMenu(DBHandler Database, Donor d)
        {

            Donor currDonor = d;

            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile");
            Console.WriteLine("2:Search Blood Banks Near you.");
            Console.WriteLine("3:Search Blood Donation Camps Near You.");
            Console.WriteLine("4:SignOut");

            Console.Write("Enter your Input:");
            var input = Enum.Parse<DonorOptions>(Console.ReadLine());

            switch (input)
            {
                case DonorOptions.UpdateProfile:
                    currDonor = Donor.UpdateProfile(Database, currDonor);
                    DonorMenu(Database, currDonor);
                    break;
                case DonorOptions.SearchBloodBanks:
                    Search.SearchBloodBanks(Database, currDonor);
                    DonorMenu(Database, currDonor);
                    break;
                case DonorOptions.SearchBloodDonationCamps:
                    Search.SearchBloodDonationCamp(Database,d);
                    DonorMenu(Database, currDonor);
                    break;
                case DonorOptions.SignOut:
                    Donor.SignOut();
                    App.Start(Database);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    DonorMenu(Database, currDonor);
                    break;
            }



        }

        public static Donor CreateUser()
        {
            Donor newDonor = new Donor();


            while (true)
            {

                Console.Write("Enter your Name: ");
                string name = Console.ReadLine();
                try
                {
                    Validation.ValidateName(name);

                }
                catch(InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                newDonor.Name = name;
                break;

            }

            while (true)
            {

                Console.Write("Enter your Age: ");
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

                newDonor.Age = Convert.ToInt32(age);
                break;

            }


            while (true)
            {
                Console.Write("Enter your Phone: ");
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


                newDonor.Phone = Convert.ToInt64(phone);
                break;

            }


            while (true)
            {
                Console.Write("Enter your Email: ");

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


                newDonor.Email = email;
                break;

            }


            while (true)
            {


                Console.Write("Enter your Role - 1. Donor or 2. BloodBankManager: ");
                string role = Console.ReadLine();

                try
                {
                    Validation.ValidateRole(role);
                }
                catch(InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                newDonor.Role = Enum.Parse<roles>(role);
                break;
            }


            while (true)
            {

                Console.Write("Enter your State (In case you are a Blood Bank Manager, Enter its State ): ");
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
                newDonor.State = state;
                break;

            }


            while (true)
            {


                Console.Write("Enter your City (In case you are a Blood Bank Manager, Enter its City ): ");
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
                newDonor.City = city;
                break;

            }



            while (true)
            {

                Console.Write("Enter your Address (In case you are a Blood Bank Manager, Enter its Address ): ");
              
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
                newDonor.Address = address;
                break;

            }


            while (true)
            {

                Console.Write("Enter your Password: ");
                string password = Console.ReadLine();

                try
                {
                    Validation.ValidateAddress(password);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                newDonor.Password = password;
                break;

            }


            while (true)
            {

                Console.Write("Enter your Blood Group - A+,A-,B+,B-,O+,O-,AB+,AB-: ");
                string bloodgrp = Console.ReadLine();

                string address = Console.ReadLine();

                try
                {
                    Validation.ValidateBloodGroup(bloodgrp);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                newDonor.BloodGrp = bloodgrp;
                break;

            }




            return newDonor;
        }


        public static Donor UpdatedUserInfo(Donor oldDonor)
        {


            Donor updatedDonor = new Donor();

            Console.Write("Enter your Name: ");
            var nameInput = Console.ReadLine();
            updatedDonor.Name = nameInput == String.Empty ? oldDonor.Name : nameInput;

            Console.Write("Enter your Age: ");
            var ageInput = Console.ReadLine();
            updatedDonor.Age = ageInput == "" ? oldDonor.Age : Convert.ToInt32(ageInput);

            Console.Write("Enter your Phone: ");
            var phoneInput = Console.ReadLine();
            updatedDonor.Phone = phoneInput == "" ? oldDonor.Phone : Convert.ToInt64(phoneInput);

            Console.Write("Enter your Email: ");
            var emailInput = Console.ReadLine();
            updatedDonor.Email = emailInput == String.Empty ? oldDonor.Email : emailInput;

            Console.Write("Enter your State (In case you are a Blood Bank Manager, Enter its State ): ");
            var stateInput = Console.ReadLine();
            updatedDonor.State = stateInput == String.Empty ? oldDonor.State : stateInput;

            Console.Write("Enter your City (In case you are a Blood Bank Manager, Enter its City ): ");
            var cityInput = Console.ReadLine();
            updatedDonor.City = cityInput == String.Empty ? oldDonor.City : cityInput;

            Console.Write("Enter your Address (In case you are a Blood Bank Manager, Enter its Address ): ");
            var addressInput = Console.ReadLine();
            updatedDonor.Address = addressInput == String.Empty ? oldDonor.Address : addressInput;

            Console.Write("Enter your Password: ");
            var passInput = Console.ReadLine();
            updatedDonor.Password = passInput == String.Empty ? oldDonor.Password : passInput;

            updatedDonor.Donorid = oldDonor.Donorid;

            updatedDonor.Role = oldDonor.Role;
            updatedDonor.BloodGrp = oldDonor.BloodGrp;

            return updatedDonor;
        }
    }
}
