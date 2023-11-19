using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View.Interfaces;

namespace BloodGuardian.View
{
    public class BloodBankManagerView : IBloodBankManagerView
    {

        public BloodTransferReceipt CreateBloodDepositRecord()
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

            return blood;


        }

        public BloodBank InputBloodBankDetails(Donor d)
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


            return bank;

        }

        public BloodTransferReceipt CreateBloodWithdrawRecord()
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

            return blood;
        }


        public BloodDonationCamp InputBloodDonationCamp()
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

            return camp;
        }



    }
}
