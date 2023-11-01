using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.Common;

namespace BloodGuardian.Controller
{
    internal class BloodDonationCampController
    {
        public BloodDonationCamp CreateBloodDonationCamp()
        {

            var camp = BloodBankManagerUI.InputBloodDonationCamp();


            return camp;

        }

        public void OrganizeBloodDonationCamps(BloodBank bank, Donor d)
        {
            var newCamp = CreateBloodDonationCamp();
            newCamp.camp_id = bank.BloodDonationCamps.Count;

            bank.BloodDonationCamps.Add(newCamp);
            DBHandler.Instance.UpdateBloodBank(bank, bank);

            BloodBankManagerUI.BloodBankManagerMenu(d);
        }

        public void GetBloodDonationCamps(BloodBank bank, Donor d)
        {

            Console.WriteLine(Message.OrganizedCamps);

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

        public void RemoveBloodDonationCamps(BloodBank bank, Donor d)
        {
            GetBloodDonationCamps(bank, d);

            Console.WriteLine();


            int campid;
            while (true)
            {
                Console.Write(Message.EnterCampId);
                string input = Console.ReadLine();

                int res;
                if (input == String.Empty || !int.TryParse(input, out res))
                {
                    Console.WriteLine(Message.EnterValidInput);
                    continue;
                }

                campid = Convert.ToInt32(input);
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }


            // Removing Camp

            var choosenCamp = bank.BloodDonationCamps.ElementAtOrDefault(campid);

            if (choosenCamp == null)
            {
                Console.WriteLine(Message.WrongCampId);
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

            DBHandler.Instance.UpdateBloodBank(bank, bank);




        }


        public void ViewBloodDonationCamps(Donor d)
        {



            DBHandler.Instance.ReadBloodBanks().ForEach((bank) =>
            {
                Console.WriteLine(Message.DoubleDashDesign);
                Console.WriteLine($"Camps organized by {bank.BankName}, ID - {bank.BankId}:");
                bank.BloodDonationCamps.ForEach((camp) =>
                {
                    Console.WriteLine(Message.SingleDashDesign);
                    Console.WriteLine("Camp ID: " + camp.camp_id);
                    Console.WriteLine("Camp Date: " + camp.Date);
                    Console.WriteLine($"Camp Duration:{camp.Start_Time} to {camp.End_Time}");
                    Console.WriteLine("Camp Address: " + camp.Camp_Address);
                    Console.WriteLine(Message.SingleDashDesign);
                    Console.WriteLine();


                });
            });
        }


        public void RemoveBloodDonationCampAdmin(Donor d)
        {

            ViewBloodDonationCamps(d);


            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.RemoveCampSteps);
            Console.WriteLine(Message.DoubleDashDesign);



            int bankid;
            while (true)
            {
                Console.Write(Message.EnterBankId);
                string input = Console.ReadLine();

                int res;
                if (input == String.Empty || !int.TryParse(input, out res))
                {
                    Console.WriteLine(Message.EnterValidInput);
                    continue;
                }

                bankid = Convert.ToInt32(input);
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            var bank = DBHandler.Instance.ReadBloodBanks().ElementAtOrDefault(bankid);

            if (bank == null)
            {
                Console.WriteLine(Message.WrongBankId);
            }
            else
            {
                RemoveBloodDonationCamps(bank, d);
            }


        }
    }

}
