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

            App.BloodBankManagerMenu(Database, d);
        }

        public static void GetBloodDonationCamps(DBHandler Database, BloodBank bank, Donor d)
        {

            Console.WriteLine("Here are the blood donation camps organized by you: ");

            bank.BloodDonationCamps.ForEach(camp =>
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Id: " + camp.camp_id);
                Console.WriteLine("State: " + camp.Camp_State);
                Console.WriteLine("City: " + camp.Camp_City);
                Console.WriteLine("Address: " + camp.Camp_Address);
                Console.WriteLine("Date " + camp.Date.ToString());
                Console.WriteLine("Start Time: " + camp.Start_Time.ToString());
                Console.WriteLine("End Time: " + camp.End_Time.ToString());
            });

            //App.BloodBankManagerMenu(Database, d);


        }

        public static void RemoveBloodDonationCamps(DBHandler Database, BloodBank bank, Donor d)
        {
            GetBloodDonationCamps(Database, bank, d);

            Console.WriteLine();
            Console.Write("Enter the id of camp you want to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());


            // Removing Camp
            bank.BloodDonationCamps.RemoveAt(id);

            // Updating Camp Ids
            foreach (var (camp, ind) in bank.BloodDonationCamps.Select((val, i) => (val, i)))
            {
                camp.camp_id = ind;
            }

            Database.UpdateBloodBank(bank, bank);

            App.BloodBankManagerMenu(Database, d);


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


                });
            });
        }


        public static void RemoveBloodDonationCamp(DBHandler db, Donor d)
        {

            ViewBloodDonationCamps(db,d);


            Console.WriteLine("=========================================");
            Console.WriteLine("You can remove a camp by following below Steps: ");
            Console.WriteLine("1. Select the bank id organizing that Blood Bank.");
            Console.WriteLine("2. Select the camp id to remove.");
            Console.WriteLine("=========================================");


            Console.Write("Enter the bank id: ");
            var bankid = Convert.ToInt32(Console.ReadLine());

            var bank = db.ReadBloodBanks().ElementAt(bankid);

            RemoveBloodDonationCamps(db, bank, d);


        }

    }

}
