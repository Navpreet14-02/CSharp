using BloodGuardian.Common;
using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BloodGuardian.Controller
{
    public class Search
    {

        public static void SearchBloodBanks(Donor d)
        {
            List<BloodBank> banks = DBHandler.Instance.SearchBloodBank(d.State, d.City, null);

            if (banks.Count == 0)
            {
                Console.WriteLine(Message.NoBloodBankFound);
            }
            else
            {

                foreach (BloodBank bank in banks)
                {
                    Console.WriteLine(Message.SingleDashDesign);
                    Console.WriteLine("Bank Id: " + bank.BankId);
                    Console.WriteLine("Bank Name: " + bank.BankName);
                    Console.WriteLine("Contact No: " + bank.Contact);
                    Console.WriteLine("State: " + bank.State);
                    Console.WriteLine("City: " + bank.City);
                    Console.WriteLine("Address: " + bank.Address);
                    Console.WriteLine(Message.SingleDashDesign);

                }
            }


        }

        public static void SearchBlood()
        {

            string state;
            while (true)
            {

                Console.Write(Message.EnterState);
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
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            string city;
            while (true)
            {


                Console.Write(Message.EnterCity);
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
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            string bloodType;
            while (true)
            {

                Console.Write(Message.EnterBloodGroup);
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
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            Console.WriteLine();


            List<BloodBank> banks = DBHandler.Instance.SearchBloodBank(state, city, bloodType);


            if (banks.Count == 0)
            {
                Console.WriteLine(Message.NoNearbyBloodBankFound);
            }
            else
            {

                foreach (BloodBank bank in banks)
                {
                    Console.WriteLine(Message.SingleDashDesign);
                    Console.WriteLine("Bank Id: " + bank.BankId);
                    Console.WriteLine("Bank Name: " + bank.BankName);
                    Console.WriteLine("Contact No: " + bank.Contact);
                    Console.WriteLine("State: " + bank.State);
                    Console.WriteLine("City: " + bank.City);
                    Console.WriteLine("Address: " + bank.Address);
                    Console.WriteLine(Message.SingleDashDesign);

                }
            }

        }

        public static void SearchBloodDonationCamp(Donor d)
        {
            var camps = DBHandler.Instance.NearestBloodDonationCamps(d);


            if (camps.Count == 0)
            {
                Console.WriteLine(Message.NoDonationCampFound);
            }
            else
            {
                foreach (var camp in camps)
                {
                    Console.WriteLine();
                    Console.WriteLine(Message.SingleDashDesign);
                    Console.WriteLine("Address: " + camp.Camp_Address);
                    Console.WriteLine("Camp Date: " + camp.Date);
                    Console.WriteLine($"Camp Duration: {camp.Start_Time.ToString()} - {camp.End_Time.ToString()}");
                    Console.WriteLine(Message.SingleDashDesign);

                    Console.WriteLine();

                }
            }
        }
    }
}
