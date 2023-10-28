using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile.");
            Console.WriteLine("2:Add Blood Deposit Record.");
            Console.WriteLine("3:Add Blood Withdraw Record.");
            Console.WriteLine("4:Organize Blood Donation Camps.");
            Console.WriteLine("5:See Blood Donation Camps.");
            Console.WriteLine("6:Remove Blood Donation Camps.");
            Console.WriteLine("7:SignOut");

            Console.Write("Enter your Input:");
            var input = Enum.Parse<BloodBankManagerOptions>(Console.ReadLine());

            switch (input)
            {
                case BloodBankManagerOptions.UpdateProfile:
                    var oldDonor = d;
                    currDonor = Donor.UpdateProfile(Database, currDonor);
                    BloodBank.UpdateBloodBankDetails(Database, oldDonor, currDonor);
                    break;

                case BloodBankManagerOptions.AddBloodDepositRecord:
                    BloodBank.UpdateDepositBloodRecord(Database, bank);
                    break;

                case BloodBankManagerOptions.AddBloodWithdrawRecord:
                    BloodBank.UpdateWithdrawBloodRecord(Database, bank);
                    break;
                case BloodBankManagerOptions.OrganizeBloodDonationCamp:
                    BloodDonationCamp.OrganizeBloodDonationCamps(Database, bank, currDonor);
                    break;
                case BloodBankManagerOptions.SeeBloodDonationCamp:
                    BloodDonationCamp.GetBloodDonationCamps(Database, bank, currDonor);
                    break;
                case BloodBankManagerOptions.RemoveBloodDonationCamp:
                    BloodDonationCamp.RemoveBloodDonationCamps(Database, bank, currDonor);
                    break;
                case BloodBankManagerOptions.SignOut:
                    Donor.SignOut();
                    App.Start(Database);
                    break;
                default:
                    Console.WriteLine("Invalid Choice.");
                    BloodBankManagerMenu(Database,d);
                    break;
            }

        }


        public static BloodTransferReceipt CreateBloodDepositRecord() 
        {

            BloodTransferReceipt blood = new BloodTransferReceipt();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Enter following details: ");

            Console.Write("Enter the Name of the Donor: ");
            blood.BloodDonorName = Console.ReadLine();

            Console.Write("Enter the Type of Blood Donated: ");
            blood.BloodGroup = Console.ReadLine();

            Console.Write("Enter the Email of the Donor: ");
            blood.CustomerEmail = Console.ReadLine();

            Console.Write("Enter the phone no. of the Donor: ");
            blood.CustomerPhone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter the Date for the Blood Transfer - MM/DD/YYYY: ");
            DateTime transferDate;
            if (DateTime.TryParse(Console.ReadLine(), out transferDate))
            {
                blood.BloodTransferDate = transferDate;

            }
            else
            {
                Console.WriteLine("Enter valid Date: ");
            }

            Console.WriteLine("Enter the amount of blood donated(in ml)");
            blood.BloodAmount = Convert.ToInt32(Console.ReadLine());
            return blood;
        }

        public static BloodTransferReceipt CreateBloodWithdrawRecord()
        {

            BloodTransferReceipt blood = new BloodTransferReceipt();


            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Enter following details: ");

            Console.Write("Enter the Name of the Patient: ");
            blood.BloodReceiverName = Console.ReadLine();

            Console.Write("Enter the Type of Blood Donated: ");
            blood.BloodGroup = Console.ReadLine();

            Console.Write("Enter the Email of the Patient: ");
            blood.CustomerEmail = Console.ReadLine();

            Console.Write("Enter the phone no. of the Patient: ");
            blood.CustomerPhone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter the Date for the Blood Transfer - MM/DD/YYYY: ");
            DateTime transferDate;
            if (DateTime.TryParse(Console.ReadLine(), out transferDate))
            {
                blood.BloodTransferDate = transferDate;

            }
            else
            {
                Console.WriteLine("Enter valid Date: ");
            }

            Console.WriteLine("Enter the amount of blood Withdrawn(in ml)");
            blood.BloodAmount = Convert.ToInt32(Console.ReadLine());


            return blood;
        }


        public static BloodDonationCamp InputBloodDonationCamp()
        {
            var camp = new BloodDonationCamp();

            Console.WriteLine("----------------------------");
            Console.WriteLine("Enter following details for the Blood Donation Camp");
            Console.Write("Enter the Date for the Camp(DD/MM/YYYY): ");
            DateTime campDate;
            if (DateTime.TryParse(Console.ReadLine(), out campDate))
            {
                camp.Date = campDate;

            }
            else
            {
                Console.WriteLine("Enter valid Date: ");
            }

            Console.Write("Enter the state in which the camp will be organized: ");
            camp.Camp_State = Console.ReadLine();


            Console.Write("Enter the city in which the camp will be organized: ");
            camp.Camp_City = Console.ReadLine();

            Console.Write("Enter the complete address for the camp: ");
            camp.Camp_Address = Console.ReadLine();

            Console.WriteLine("Enter the start time for the camp in 24-hour format:");
            TimeOnly start_time;
            if (TimeOnly.TryParse(Console.ReadLine(), out start_time))
            {
                camp.Start_Time = start_time;
            }
            else
            {
                Console.WriteLine("Invalid Time Input.");
            }

            Console.WriteLine("Enter the end time for the camp(HH:MM) in 24-hour format: ");
            TimeOnly end_time;
            if (TimeOnly.TryParse(Console.ReadLine(), out end_time))
            {
                camp.End_Time = end_time;
            }
            else
            {
                Console.WriteLine("Invalid Time Input.");
            }


            return camp;
        }



    }
}
