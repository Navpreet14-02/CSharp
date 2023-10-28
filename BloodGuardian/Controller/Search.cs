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


            Console.WriteLine("Enter your state:");
            string state = Console.ReadLine();
            Console.WriteLine("Enter your city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter your blood group: ");
            string bloodType = Console.ReadLine();

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
            var camps = DBHandler.NearestBloodDonationCamps(d);

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
