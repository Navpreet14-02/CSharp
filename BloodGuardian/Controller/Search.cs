using BloodGuardian.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BloodGuardian.Models
{
    internal static class Search
    {

        public static void SearchBloodBanks(DBHandler database,Donor d)
        {
            List<BloodBank> banks = database.ReadBloodBanks();

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
    }
}
