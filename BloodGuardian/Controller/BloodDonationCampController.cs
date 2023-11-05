using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.Common;

namespace BloodGuardian.Controller
{
    internal class BloodDonationCampController
    {
        //public BloodDonationCamp CreateBloodDonationCamp()
        //{

        //    var camp = BloodBankManagerUI.InputBloodDonationCamp();


        //    return camp;

        //}

        public void OrganizeBloodDonationCamps(BloodBank bank, Donor d)
        {

            BloodBankManagerUI bbManagerUI = new BloodBankManagerUI();
            var newCamp = bbManagerUI.InputBloodDonationCamp();

            //var newCamp = CreateBloodDonationCamp();
            newCamp.camp_id = bank.BloodDonationCamps.Count;

            bank.BloodDonationCamps.Add(newCamp);
            BloodBankDBHandler.Instance.UpdateBloodBank(bank, bank);

        }

        public void GetBloodDonationCamps(BloodBank bank, Donor d)
        {


            var camps = bank.BloodDonationCamps;

            if (camps.Count() == 0)
            {
                Console.WriteLine(Message.NoDonationCamps);
            }
            else
            {

                Console.WriteLine(Message.OrganizedCamps);

                camps.ForEach(camp =>
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

            }
            //App.BloodBankManagerMenu(Database, d);


        }

        public void RemoveBloodDonationCamps(BloodBank bank, Donor d)
        {
            GetBloodDonationCamps(bank, d);

            Console.WriteLine();


            Console.Write(Message.EnterCampId);
            int campid = InputHandler.InputId();

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

            BloodBankDBHandler.Instance.UpdateBloodBank(bank, bank);



            
        }


        public void AdminViewBloodDonationCamps(Donor d)
        {


            var banks = BloodBankDBHandler.Instance.Read();

            if(banks.Count == 0)
            {
                Console.WriteLine(Message.NoDonationCampOrganized);
                return;
            }

            BloodBankDBHandler.Instance.Read().ForEach((bank) =>
            {
                Console.WriteLine(Message.DoubleDashDesign);
                var camps = bank.BloodDonationCamps;

                Console.WriteLine($"Camps organized by {bank.BankName}, ID - {bank.BankId}:");

                if(camps.Count == 0)
                {
                    Console.WriteLine(Message.NoDonationCampsBank);
                }
                camps.ForEach((camp) =>
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


        public void AdminRemoveBloodDonationCamp(Donor d)
        {

            AdminViewBloodDonationCamps(d);


            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.RemoveCampSteps);
            Console.WriteLine(Message.DoubleDashDesign);



            Console.Write(Message.EnterBankId);
            int bankid=InputHandler.InputId();

            var bank = BloodBankDBHandler.Instance.Read().ElementAtOrDefault(bankid);

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
