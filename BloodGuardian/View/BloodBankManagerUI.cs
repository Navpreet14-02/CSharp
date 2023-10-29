using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BloodGuardian.View.AdminUI;

namespace BloodGuardian.View
{
    internal class BloodBankManagerUI
    {


        public enum BloodBankManagerOptions
        {
            UpdateProfile=1,
            AddBloodDepositRecord=2,
            AddBloodWithdrawRecord=3,
            OrganizeBloodDonationCamp=4,
            SeeBloodDonationCamp=5,
            RemoveBloodDonationCamp=6,
            SignOut=7,
        }


        public static void BloodBankManagerMenu(DBHandler Database, Donor d)
        {

            Donor currDonor = d;

            BloodBank bank = Database.FindBloodBank(currDonor,-1);


            Console.WriteLine();
            Console.WriteLine("==========================");
            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile.");
            Console.WriteLine("2:Add Blood Deposit Record.");
            Console.WriteLine("3:Add Blood Withdraw Record.");
            Console.WriteLine("4:Organize Blood Donation Camps.");
            Console.WriteLine("5:See Blood Donation Camps.");
            Console.WriteLine("6:Remove Blood Donation Camps.");
            Console.WriteLine("7:SignOut");
            Console.WriteLine("==========================");
            Console.WriteLine();


            BloodBankManagerOptions option;
            while (true)
            {
                Console.WriteLine("----------------------");
                Console.Write("Enter your Input:");
                string input = Console.ReadLine();

                BloodBankManagerOptions result;
                if (input == string.Empty || !Enum.TryParse<BloodBankManagerOptions>(input, out result))
                {
                    Console.WriteLine("Enter Valid Option.");
                    continue;
                }

                option = Enum.Parse<BloodBankManagerOptions>(input);
                //Console.WriteLine("*********************");
                break;

            }

            switch (option)
            {
                case BloodBankManagerOptions.UpdateProfile:
                    var oldDonor = d;
                    currDonor = Donor.UpdateProfile(Database, currDonor);
                    BloodBank.UpdateBloodBankDetails(Database, oldDonor, currDonor);
                    BloodBankManagerUI.BloodBankManagerMenu(Database, d);
                    break;

                case BloodBankManagerOptions.AddBloodDepositRecord:
                    BloodBank.UpdateDepositBloodRecord(Database, bank);
                    BloodBankManagerUI.BloodBankManagerMenu(Database, d);
                    break;

                case BloodBankManagerOptions.AddBloodWithdrawRecord:
                    BloodBank.UpdateWithdrawBloodRecord(Database, bank);
                    BloodBankManagerUI.BloodBankManagerMenu(Database, d);
                    break;
                case BloodBankManagerOptions.OrganizeBloodDonationCamp:
                    BloodDonationCamp.OrganizeBloodDonationCamps(Database, bank, currDonor);
                    BloodBankManagerUI.BloodBankManagerMenu(Database, d);
                    break;

                case BloodBankManagerOptions.SeeBloodDonationCamp:
                    BloodDonationCamp.GetBloodDonationCamps(Database, bank, currDonor);
                    BloodBankManagerUI.BloodBankManagerMenu(Database, d);
                    break;

                case BloodBankManagerOptions.RemoveBloodDonationCamp:
                    BloodDonationCamp.RemoveBloodDonationCamps(Database, bank, currDonor);
                    BloodBankManagerUI.BloodBankManagerMenu(Database, d);
                    break;

                case BloodBankManagerOptions.SignOut:
                    Donor.SignOut(d);
                    App.Start(Database);
                    break;

                default:
                    Console.WriteLine("Enter Valid Option.");
                    BloodBankManagerUI.BloodBankManagerMenu(Database, d);
                    break;
            }

        }


        public static BloodTransferReceipt CreateBloodDepositRecord() 
        {

            BloodTransferReceipt blood = new BloodTransferReceipt();

            Console.WriteLine("=====================================");
            Console.WriteLine("Enter following details: ");

            while (true)
            {
                Console.Write("Enter the Name of the Donor: ");

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
                


                blood.BloodDonorName= name;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {
                Console.Write("Enter the Type of Blood Donated: ");

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

                blood.BloodGroup = bloodgrp;
                Console.WriteLine("--------------------------------");
                break;

            }

            while (true)
            {
                Console.Write("Enter the Email of the Donor: ");

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



                blood.CustomerEmail = email;
                Console.WriteLine("--------------------------------");

                break;

            }

            while (true)
            {
                
                Console.Write("Enter the phone no. of the Donor: ");
                string phoneno = Console.ReadLine();
                try
                {
                    Validation.ValidatePhone(phoneno);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                blood.CustomerPhone = Convert.ToInt64(phoneno);

                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {


                Console.Write("Enter the Date for the Blood Transfer - MM/DD/YYYY: ");
                string transferDate = Console.ReadLine();

                try
                {
                    Validation.ValidateDate(transferDate);
                }
                catch(InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                blood.BloodTransferDate = DateTime.Parse(transferDate);
                break;

           
            }

            while (true)
            {
                Console.Write("Enter the amount of Blood Donated(in ml): ");
                string amnt = Console.ReadLine();

                try
                {
                    Validation.ValidateBloodAmount(amnt);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                blood.BloodAmount = Convert.ToInt32(amnt);
                break;

            }

            return blood;


        }

        public static BloodTransferReceipt CreateBloodWithdrawRecord()
        {

            BloodTransferReceipt blood = new BloodTransferReceipt();


            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Enter following details: ");

            while (true)
            {
                Console.Write("Enter the Name of the Patient: ");

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



                blood.BloodReceiverName = name;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {
                Console.Write("Enter the Type of Blood Donated: ");

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

                blood.BloodGroup = bloodgrp;
                Console.WriteLine("--------------------------------");
                break;

            }


            while (true)
            {
                Console.Write("Enter the Email of the Patient: ");

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



                blood.CustomerEmail = email;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {

                Console.Write("Enter the phone no. of the Patient: ");
                string phoneno = Console.ReadLine();
                try
                {
                    Validation.ValidatePhone(phoneno);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                blood.CustomerPhone = Convert.ToInt64(phoneno);

                Console.WriteLine("--------------------------------");

                break;

            }

    
            while (true)
            {


                Console.Write("Enter the Date for the Blood Transfer - MM/DD/YYYY: ");
                string transferDate = Console.ReadLine();

                try
                {
                    Validation.ValidateDate(transferDate);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                blood.BloodTransferDate = DateTime.Parse(transferDate);
                break;


            }


            while (true)
            {
                Console.Write("Enter the amount of Blood Withdrawn(in ml): ");
                string amnt = Console.ReadLine();

                try
                {
                    Validation.ValidateBloodAmount(amnt);
                }
                catch(InvalidDataException e) 
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                blood.BloodAmount = Convert.ToInt32(amnt);
                break;

            }

            return blood;
        }


        public static BloodDonationCamp InputBloodDonationCamp()
        {
            var camp = new BloodDonationCamp();

            Console.WriteLine("----------------------------");
            Console.WriteLine("Enter following details for the Blood Donation Camp:");


            while (true)
            {
                Console.Write("Enter the Date for the Camp(DD/MM/YYYY): ");
                string campDate = Console.ReadLine();

                try
                {
                    Validation.ValidateDate(campDate);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                camp.Date = DateTime.Parse(campDate);
                Console.WriteLine("---------------------------------");
                break;


            }


            while (true)
            {

                Console.Write("Enter the state in which the camp will be organized: ");
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
                camp.Camp_State=state;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {

                Console.Write("Enter the city in which the camp will be organized: ");
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
                camp.Camp_City = city;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {

                Console.Write("Enter the complete address for the camp: ");
                string address = Console.ReadLine();

                if (address != String.Empty)
                {
                    try
                    {
                        Validation.ValidateCity(address);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                camp.Camp_Address = address;
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {

                Console.Write("Enter the start time for the camp(HH:MM) in 24-hour format:");
                string start_time = Console.ReadLine();
                
                try
                {
                    Validation.ValidateTime(start_time);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                
                camp.Start_Time = TimeOnly.Parse(start_time);
                Console.WriteLine("--------------------------------");

                break;

            }


            while (true)
            {

                Console.Write("Enter the end time for the camp(HH:MM) in 24-hour format: ");
                string end_time = Console.ReadLine();

                try
                {
                    Validation.ValidateTime(end_time);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                camp.End_Time = TimeOnly.Parse(end_time);
                Console.WriteLine("--------------------------------");

                break;

            }

            return camp;
        }



    }
}
