using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Models;
using BloodGuardian.View.Interfaces;

namespace BloodGuardian.View
{


    public class Search : ISearch
    {
        private IBloodBank _bankController;

        public Search(IBloodBank bankController)
        {
            _bankController = bankController;
        }

        public void SearchBloodBanks(Donor d)
        {

            List<BloodBank> banks = _bankController
                                    .GetBloodBanks()
                                    .FindAll((bloodbank) => bloodbank.State.Equals(d.State, StringComparison.InvariantCultureIgnoreCase) && bloodbank.City.Equals(d.City, StringComparison.InvariantCultureIgnoreCase));

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

        public void SearchBlood()
        {

            Console.WriteLine(Message.EnterState);
            string state = InputHandler.InputState(false);

            Console.WriteLine(Message.EnterCity);
            string city = InputHandler.InputCity(false);


            Console.WriteLine(Message.EnterBloodGroup);
            string bloodType = InputHandler.InputBloodGroup(false);

            Console.WriteLine();


            List<BloodBank> banks =
                _bankController.GetBloodBanks()
                .FindAll((bloodbank) => bloodbank.State.Equals(state, StringComparison.InvariantCultureIgnoreCase) && bloodbank.City.Equals(city, StringComparison.InvariantCultureIgnoreCase) && bloodbank.BloodUnits[bloodType] > 0);



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

        public void SearchBloodDonationCamp(Donor d)
        {
            if (d.Role != Roles.Donor)
            {
                Console.WriteLine(Message.NotAuthorized);
            }
            var banksList = _bankController.GetBloodBanks();

            if(banksList==null || banksList.Count == 0)
            {
                Console.WriteLine(Message.NoDonationCampFound);
                return;
            }

            var bankCampDict = 
                banksList
                .Select((bank) => new {Bank =bank.BankName ,camps =bank.BloodDonationCamps})
                .ToDictionary(t=>t.Bank,t=>t.camps);


            if (bankCampDict.Count == 0)
            {
                Console.WriteLine(Message.NoDonationCampFound);
                return;
            }

            foreach(var item in bankCampDict)
            {

                var bank = item.Key;
                var camps = item.Value.Where(camp => 
                    camp.Camp_State.Equals(d.State, StringComparison.InvariantCultureIgnoreCase) && 
                    camp.Camp_City.Equals(d.City, StringComparison.InvariantCultureIgnoreCase)
                );


                foreach (var camp in camps)
                {
                    Console.WriteLine();
                    Console.WriteLine(Message.SingleDashDesign);
                    Console.WriteLine("BankName: "+bank);
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
