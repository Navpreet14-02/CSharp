using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Models;
using BloodGuardian.View.Interfaces;

namespace BloodGuardian.View
{
    public class BloodBankManagerDashboard : IBloodBankManagerDashboard
    {

        private IBloodBank _bankController;
        private IBloodDonationCamp _campController;

        public BloodBankManagerDashboard(IBloodBank bankController, IBloodDonationCamp campController)
        {
            _bankController = bankController;
            _campController = campController;
        }

        public void CreateBloodDepositRecord(BloodBank bank)
        {

            BloodTransferReceipt blood = new BloodTransferReceipt();

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.EnterDetails);

            Console.WriteLine(Message.EnterDonorName);
            blood.BloodDonorName = InputHandler.InputName(false);


            Console.WriteLine(Message.BloodDonatedType);
            blood.BloodGroup = InputHandler.InputBloodGroup(false);

            Console.WriteLine(Message.EnterDonorEmail);
            blood.CustomerEmail = InputHandler.InputEmail(false);

            Console.WriteLine(Message.EnterDonorPhone);
            blood.CustomerPhone = InputHandler.InputPhone(false);


            Console.WriteLine(Message.EnterTransferDate);
            blood.BloodTransferDate = InputHandler.InputDate(false);



            Console.WriteLine(Message.EnterBloodDonatedAmount);
            blood.BloodAmount = InputHandler.InputBloodAmount(false);


            _bankController.UpdateDepositBloodRecord(bank, blood);


        }

        public void CreateBloodBank(Donor d)
        {

            BloodBank bank = new BloodBank();



            Console.Write(Message.EnterBloodBankName);
            bank.BankName = InputHandler.InputName(false);

            bank.ManagerEmail = d.Email;
            bank.ManagerName = d.Name;
            bank.Address = d.Address;
            bank.State = d.State;
            bank.City = d.City;
            bank.Contact = d.Phone;
            bank.ManagerUserName = d.UserName;

            Console.WriteLine(Message.BloodAvailabilityAmount);

            foreach (var grp in Validation.BloodGroups)
            {


                while (true)
                {
                    Console.Write(grp + ": ");
                    string amnt = Console.ReadLine();

                    if (amnt != String.Empty)
                    {

                        try
                        {
                            Validation.ValidateBloodAmount(amnt);
                        }
                        catch (InvalidDataException e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                    }

                    bank.BloodUnits[grp] = amnt == "" ? 0 : Convert.ToInt32(amnt);
                    break;

                }

            }

            _bankController.AddBloodBank(bank);



        }

        public void CreateBloodWithdrawRecord(BloodBank bank)
        {

            BloodTransferReceipt blood = new BloodTransferReceipt();


            Console.WriteLine(Message.SingleDashDesign);
            Console.WriteLine(Message.EnterDetails);

            Console.Write(Message.EnterPatientName);
            blood.BloodReceiverName = InputHandler.InputName(false);

            Console.Write(Message.BloodWithdrawnType);
            blood.BloodGroup = InputHandler.InputBloodGroup(false);


            Console.Write(Message.EnterPatientEmail);
            blood.CustomerEmail = InputHandler.InputEmail(false);



            Console.Write(Message.EnterPatientPhone);
            blood.CustomerPhone = InputHandler.InputPhone(false);


            Console.Write(Message.EnterTransferDate);
            blood.BloodTransferDate = InputHandler.InputDate(false);


            Console.Write(Message.EnterBloodWithdrawnAmount);
            blood.BloodAmount = InputHandler.InputBloodAmount(false);


            _bankController.UpdateWithdrawBloodRecord(bank, blood);
        }


        public void CreateBloodDonationCamp(BloodBank bank, Donor d)
        {
            var camp = new BloodDonationCamp();

            Console.WriteLine(Message.SingleDashDesign);
            Console.WriteLine(Message.EnterDonationCampDetails);


            Console.WriteLine(Message.EnterCampDate);
            camp.Date = InputHandler.InputDate(false);


            Console.WriteLine(Message.EnterCampState);
            camp.Camp_State = InputHandler.InputState(false);


            Console.WriteLine(Message.EnterCampCity);
            camp.Camp_City = InputHandler.InputCity(false);


            Console.WriteLine(Message.EnterCampAddress);
            camp.Camp_Address = InputHandler.InputAddress(false);



            Console.WriteLine(Message.EnterCampStartTime);
            camp.Start_Time = InputHandler.InputTime(false);


            Console.WriteLine(Message.EnterCampEndTime);
            camp.End_Time = InputHandler.InputTime(false);

            _campController.OrganizeBloodDonationCamps(bank, camp);
        }

        public void UpdateBloodBankDetails(Donor oldDonor, Donor newDonor)
        {
            var bank = _bankController.FindBloodBankByDonor(oldDonor);

            var newBank = new BloodBank();

            Console.WriteLine(Message.EnterBloodBankName);
            var newBankName = InputHandler.InputName(true);


            newBank.BankName = newBankName.Equals(String.Empty) ? bank.BankName : newBankName;

            newBank.ManagerEmail = newDonor.Email;
            newBank.ManagerName = newDonor.Name;
            newBank.Address = newDonor.Address;
            newBank.State = newDonor.State;
            newBank.City = newDonor.City;
            newBank.Contact = newDonor.Phone;
            newBank.BloodUnits = bank.BloodUnits;
            newBank.Blood_Deposit_Record = bank.Blood_Deposit_Record;
            newBank.Blood_WithDrawal_Record = bank.Blood_WithDrawal_Record;
            newBank.BloodDonationCamps = bank.BloodDonationCamps;
            newBank.ManagerUserName = newDonor.UserName;



            _bankController.UpdateBloodBank(bank, newBank);

        }

        public void ViewBloodDonationCamps(BloodBank bank, Donor d)
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
            ViewBloodDonationCamps(bank, d);

            Console.WriteLine();


            Console.Write(Message.EnterCampId);
            int campid = InputHandler.InputId();

            _campController.RemoveBloodDonationCamps(bank, campid);

        }



    }
}
