using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BloodGuardian.View.BloodBankManagerUI;

namespace BloodGuardian.View
{
    internal static class DonorUI
    {


        public enum DonorOptions
        {
            UpdateProfile=1,
            SearchBloodBanks=2,
            SearchBloodDonationCamps=3,
            SeeBloodDonationHistory=4,
            SignOut=5,
        }

        public static void DonorMenu(DBHandler Database, Donor d)
        {

            Donor currDonor = d;

            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile");
            Console.WriteLine("2:Search Blood Banks Near you.");
            Console.WriteLine("3:Search Blood Donation Camps Near You.");
            Console.WriteLine("4:See Blood Donation History.");
            Console.WriteLine("5:SignOut");
            Console.WriteLine("==================================");
            Console.WriteLine();


            DonorOptions option;
            while (true)
            {
                Console.WriteLine("----------------------");
                Console.Write("Enter your Input:");
                string input = Console.ReadLine();

                DonorOptions result;
                if (input == string.Empty || !Enum.TryParse<DonorOptions>(input, out result))
                {
                    Console.WriteLine("Enter Valid Option.");
                    continue;
                }

                option = Enum.Parse<DonorOptions>(input);
                //Console.WriteLine("*********************");
                break;

            }

            switch (option)
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
                case DonorOptions.SeeBloodDonationHistory:
                    Donor.ViewBloodDonationHistory(Database, d);
                    DonorMenu(Database, currDonor);
                    break;
                case DonorOptions.SignOut:
                    Donor.SignOut(d);
                    App.Start(Database);
                    break;
                default:
                    Console.WriteLine("Enter Valid Option");
                    DonorUI.DonorMenu(Database, d);
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
                Console.WriteLine("--------------------------------");
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
                Console.WriteLine("--------------------------------");

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
                Console.WriteLine("--------------------------------");

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

                if (Donor.FindDonor(email, null)!=null)
                {
                    Console.WriteLine("This email already exists.");
                    continue;
                }


                newDonor.Email = email;
                Console.WriteLine("--------------------------------");

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
                Console.WriteLine("--------------------------------");

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
                Console.WriteLine("--------------------------------");

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
                Console.WriteLine("--------------------------------");

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
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {

                Console.Write("Enter your Password: ");
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
                newDonor.Password = password;
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
                newDonor.BloodGrp = bloodgrp;
                Console.WriteLine("--------------------------------");

                break;

            }




            return newDonor;
        }


        public static Donor UpdatedUserInfo(Donor oldDonor)
        {


            Donor updatedDonor = new Donor();


            while (true)
            {

                Console.Write("Enter your Name: ");
                string name = Console.ReadLine();
                if (name != String.Empty)
                {
                    try
                    {
                        Validation.ValidateName(name);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                updatedDonor.Name = name==String.Empty?oldDonor.Name:name;
                Console.WriteLine("--------------------------------");
                break;

            }



            while (true)
            {

                Console.Write("Enter your Age: ");
                string age = Console.ReadLine();
                if (age != String.Empty)
                {
                    try
                    {
                        Validation.ValidateAge(age);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                updatedDonor.Age = age==String.Empty?oldDonor.Age: Convert.ToInt32(age);
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {
                Console.Write("Enter your Phone: ");
                string phone = Console.ReadLine();
                if (phone != String.Empty)
                {

                    try
                    {
                        Validation.ValidatePhone(phone);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }


                updatedDonor.Phone = phone==String.Empty?oldDonor.Phone:Convert.ToInt64(phone);
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {
                Console.Write("Enter your Email: ");

                string email = Console.ReadLine();
                if (email != String.Empty)
                {
                    try
                    {
                        Validation.ValidateEmail(email);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }


                updatedDonor.Email = email==String.Empty?oldDonor.Email:email;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {

                Console.Write("Enter your State (In case you are a Blood Bank Manager, Enter its State ): ");
                string state = Console.ReadLine();

                if (state != String.Empty)
                {
                    try
                    {
                        Validation.ValidateState(state);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                updatedDonor.State = state==String.Empty?oldDonor.State:state;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {


                Console.Write("Enter your City (In case you are a Blood Bank Manager, Enter its City ): ");
                string city = Console.ReadLine();
                if (city != String.Empty)
                {
                    try
                    {
                        Validation.ValidateCity(city);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                updatedDonor.City = city==String.Empty?oldDonor.City:city;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {

                Console.Write("Enter your Address (In case you are a Blood Bank Manager, Enter its Address ): ");

                string address = Console.ReadLine();

                if (address != String.Empty)
                {
                    try
                    {
                        Validation.ValidateAddress(address);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                updatedDonor.Address = address==String.Empty?oldDonor.Address:address;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {

                Console.Write("Enter your Password: ");
                string password = Console.ReadLine();

                if (password != String.Empty)
                {
                    try
                    {
                        Validation.ValidatePassword(password);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                updatedDonor.Password = password==String.Empty?oldDonor.Password:password;
                Console.WriteLine("--------------------------------");

                break;

            }

            updatedDonor.Donorid = oldDonor.Donorid;

            updatedDonor.Role = oldDonor.Role;
            updatedDonor.BloodGrp = oldDonor.BloodGrp;

            return updatedDonor;
        }
    }
}
