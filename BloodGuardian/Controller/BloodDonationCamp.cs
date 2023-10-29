using BloodGuardian.Database;
using BloodGuardian.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Models
{
    internal class BloodDonationCamp
    {


        public int camp_id { get; set; }

        public DateTime Date {  get; set; }

        public string Camp_State { get; set; }

        public string Camp_City { get; set; }
        public string Camp_Address { get; set; }
        public TimeOnly Start_Time { get; set; }
        public TimeOnly End_Time { get; set;}


        public static BloodDonationCamp CreateBloodDonationCamp()
        {

            var camp = BloodBankManagerUI.InputBloodDonationCamp();


            return camp;

        }

        public static void OrganizeBloodDonationCamps(DBHandler Database, BloodBank bank, Donor d)
        {
            var newCamp = BloodDonationCamp.CreateBloodDonationCamp();
            newCamp.camp_id = bank.BloodDonationCamps.Count;

            bank.BloodDonationCamps.Add(newCamp);
            Database.UpdateBloodBank(bank, bank);

            BloodBankManagerUI.BloodBankManagerMenu(Database, d);
        }

        public static void GetBloodDonationCamps(DBHandler Database, BloodBank bank, Donor d)
        {

            Console.WriteLine("Here are the blood donation camps organized by you: ");

            bank.BloodDonationCamps.ForEach(camp =>
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------");
                Console.WriteLine("Id: " + camp.camp_id);
                Console.WriteLine("State: " + camp.Camp_State);
                Console.WriteLine("City: " + camp.Camp_City);
                Console.WriteLine("Address: " + camp.Camp_Address);
                Console.WriteLine("Date: " + camp.Date.ToString());
                Console.WriteLine("Start Time: " + camp.Start_Time.ToString());
                Console.WriteLine("End Time: " + camp.End_Time.ToString());
                Console.WriteLine("-----------------------");

            });

            //App.BloodBankManagerMenu(Database, d);


        }

        public static void RemoveBloodDonationCamps(DBHandler Database, BloodBank bank, Donor d)
        {
            GetBloodDonationCamps(Database, bank, d);

            Console.WriteLine();


            int campid;
            while (true)
            {
                Console.Write("Enter the id of camp you want to remove: ");
                string input = Console.ReadLine();

                int res;
                if (input == String.Empty || !int.TryParse(input, out res))
                {
                    Console.WriteLine("Enter Valid Input.");
                    continue;
                }

                campid = Convert.ToInt32(input);
                Console.WriteLine("-----------------------------");
                break;

            }


            // Removing Camp

            var choosenCamp = bank.BloodDonationCamps.ElementAtOrDefault(campid);

            if (choosenCamp == null)
            {
                Console.WriteLine("The camp with this id does not exist.");
            }
            else
            {

                bank.BloodDonationCamps.RemoveAt(campid);

                // Updating Camp Ids
                foreach (var (camp, ind) in bank.BloodDonationCamps.Select((val, i) => (val, i)))
                {
                    camp.camp_id = ind;
                }
            }

            Database.UpdateBloodBank(bank, bank);

            


        }


        public static void ViewBloodDonationCamps(DBHandler db, Donor d)
        {



            db.ReadBloodBanks().ForEach((bank) =>
            {
                Console.WriteLine("=======================================");
                Console.WriteLine($"Camps organized by {bank.BankName}, ID - {bank.BankId}:");
                bank.BloodDonationCamps.ForEach((camp) =>
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Camp ID: " + camp.camp_id);
                    Console.WriteLine("Camp Date: "+camp.Date);
                    Console.WriteLine($"Camp Duration:{camp.Start_Time} to {camp.End_Time}");
                    Console.WriteLine("Camp Address: " +camp.Camp_Address);
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine();


                });
            });
        }


        public static void RemoveBloodDonationCampAdmin(DBHandler db, Donor d)
        {

            ViewBloodDonationCamps(db,d);


            Console.WriteLine("=========================================");
            Console.WriteLine("You can remove a camp by following below Steps: ");
            Console.WriteLine("1. Select the bank id organizing that Blood Bank.");
            Console.WriteLine("2. Select the camp id to remove.");
            Console.WriteLine("=========================================");



            int bankid;
            while (true)
            {
                Console.Write("Enter the bank id: ");
                string input = Console.ReadLine();

                int res;
                if (input == String.Empty || !int.TryParse(input, out res))
                {
                    Console.WriteLine("Enter Valid Input.");
                    continue;
                }

                bankid = Convert.ToInt32(input);
                Console.WriteLine("-----------------------------");
                break;

            }

            var bank = db.ReadBloodBanks().ElementAtOrDefault(bankid);

            if (bank == null)
            {
                Console.WriteLine("The bank with this id does not exist.");
            }
            else
            {
                RemoveBloodDonationCamps(db, bank, d);
            }


        }

    }

}
