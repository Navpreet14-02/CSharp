using BloodGuardian.Common;
using BloodGuardian.Models;

namespace BloodGuardian.Controller
{
    public class Search
    {
        private BloodBankController _bankController;

        public Search()
        {
            _bankController = new BloodBankController();
        }

        public void SearchBloodBanks(Donor d)
        {

            List<BloodBank> banks = _bankController.GetBloodBanks().FindAll((bloodbank) => bloodbank.State == d.State&& bloodbank.City == d.City);

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
            string city=InputHandler.InputCity(false);


            Console.WriteLine(Message.EnterBloodGroup);
            string bloodType=InputHandler.InputBloodGroup(false);

            Console.WriteLine();


            List<BloodBank> banks =
                _bankController.GetBloodBanks()
                .FindAll((bloodbank) => bloodbank.State == state && bloodbank.City == city && bloodbank.BloodUnits[bloodType] > 0);



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
            if(d.Role != roles.Donor)
            {
                Console.WriteLine(Message.NotAuthorized);
            }
            var banksList = _bankController.GetBloodBanks();

            var campsLists = banksList.Select((bank) => bank.BloodDonationCamps).ToList();

            var camps=new List<BloodDonationCamp>();
            campsLists.ForEach((campList) => campList.ForEach((camp) =>
            {
                if (camp.Camp_State == d.State && camp.Camp_City == d.City) camps.Add(camp);
            }));




            if (camps.Count == 0)
            {
                Console.WriteLine(Message.NoDonationCampFound);
            }
            else
            {
                foreach (var camp in camps)
                {
                    Console.WriteLine();
                    Console.WriteLine(Message.SingleDashDesign);
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
