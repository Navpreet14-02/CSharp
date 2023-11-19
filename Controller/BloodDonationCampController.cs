using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.View;

namespace BloodGuardian.Controller
{


    internal class BloodDonationCampController : IAdminBloodDonationCamp, IBloodDonationCamp
    {

        private IBloodBankDBHandler _bankDBHandler;

        public BloodDonationCampController(IBloodBankDBHandler bankDBHandler)
        {
            _bankDBHandler = bankDBHandler;
        }

        public void OrganizeBloodDonationCamps(BloodBank bank, Donor d)
        {

            BloodBankManagerView bbManagerUI = new BloodBankManagerView();
            var newCamp = bbManagerUI.InputBloodDonationCamp();

            newCamp.camp_id = bank.BloodDonationCamps.Count;

            bank.BloodDonationCamps.Add(newCamp);
            _bankDBHandler.UpdateBloodBank(bank, bank);

        }

        public void GetBloodDonationCamps(BloodBank bank, Donor d)
        {


            if (bank == null || bank.BloodDonationCamps.Count == 0)
            {
                Console.WriteLine(Message.NoDonationCamps);
            }
            else
            {

                var camps = bank.BloodDonationCamps;
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


                foreach (var (camp, ind) in bank.BloodDonationCamps.Select((val, i) => (val, i)))
                {
                    camp.camp_id = ind;
                }
            }

            _bankDBHandler.UpdateBloodBank(bank, bank);




        }


        public void AdminViewBloodDonationCamps(Donor d)
        {

            var banks = _bankDBHandler.Get();

            if (banks == null || banks.Count == 0)
            {
                Console.WriteLine(Message.NoDonationCampOrganized);
                return;
            }

            banks.ForEach((bank) =>
            {
                Console.WriteLine(Message.DoubleDashDesign);
                var camps = bank.BloodDonationCamps;

                Console.WriteLine($"Camps organized by {bank.BankName}, ID - {bank.BankId}:");

                if (camps.Count == 0)
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
            int bankid = InputHandler.InputId();

            var bank = _bankDBHandler.Get().ElementAtOrDefault(bankid);

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
