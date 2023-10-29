using BloodGuardian.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BloodGuardian.Models
{
    internal class Search
    {

        public static void SearchBloodBanks(DBHandler database,Donor d)
        {
            List<BloodBank> banks = database.SearchBloodBank(d.State,d.City,null);

            foreach (BloodBank bank in banks)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Bank Id: " + bank.BankId);
                Console.WriteLine("Bank Name: " + bank.BankName);
                Console.WriteLine("Contact No: " + bank.Contact);
                Console.WriteLine("State: " + bank.State);
                Console.WriteLine("City: " + bank.City);
                Console.WriteLine("Address: " + bank.Address);

            }


        }

        public static void SearchBlood(DBHandler database)
        {

            string state;
            while (true)
            {

                Console.Write("Enter your State: ");
                string input = Console.ReadLine();

                try
                {
                    Validation.ValidateState(input);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                state = input;
                Console.WriteLine("--------------------------------");
                break;

            }

            string city;
            while (true)
            {


                Console.Write("Enter your City: ");
                string input = Console.ReadLine();
                try
                {
                    Validation.ValidateCity(input);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                city = input;
                Console.WriteLine("--------------------------------");
                break;

            }

            string bloodType;
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
                bloodType = bloodgrp;
                Console.WriteLine("--------------------------------");
                break;

            }

            Console.WriteLine();


            List<BloodBank> banks = database.SearchBloodBank(state, city, bloodType);


            foreach (BloodBank bank in banks)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Bank Id: " + bank.BankId);
                Console.WriteLine("Bank Name: " + bank.BankName);
                Console.WriteLine("Contact No: " + bank.Contact);
                Console.WriteLine("State: " + bank.State);
                Console.WriteLine("City: " + bank.City);
                Console.WriteLine("Address: " + bank.Address);

            }


        }

        public static void SearchBloodDonationCamp(DBHandler database,Donor d)
        {
            var camps = database.NearestBloodDonationCamps(d);

            foreach(var camp in camps)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------");
                Console.WriteLine("Address: "+camp.Camp_Address);
                Console.WriteLine("Camp Date: "+camp.Date);
                Console.WriteLine($"Camp Duration: {camp.Start_Time.ToString()} - {camp.End_Time.ToString()}");
                Console.WriteLine();

            }
        }
    }
}
