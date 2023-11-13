using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Models;

namespace BloodGuardian.View
{
    public class BloodBankManagerUI
    {



        public static void BloodBankManagerMenu(Donor d)
        {


            IBloodBank bankController = new BloodBankController();
            IBloodDonationCamp campController = new BloodDonationCampController();

            Donor currDonor = d;

            BloodBank bank = bankController.FindBloodBankbyDonor(currDonor);


            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);

            Console.WriteLine(Message.PrintBloodBankManagerOptions);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();



            BloodBankManagerOptions option;

            Console.WriteLine(Message.SingleDashDesign);
            Console.Write(Message.EnterInput);
            string input = Console.ReadLine();

            BloodBankManagerOptions result;
            if (input == string.Empty || !Enum.TryParse<BloodBankManagerOptions>(input, out result))
            {
                Console.WriteLine(Message.EnterValidOption);
                BloodBankManagerMenu(d);
            }

            option = Enum.Parse<BloodBankManagerOptions>(input);

            switch (option)
            {
                case BloodBankManagerOptions.UpdateProfile:
                    IDonor donorController = new DonorController();

                    var oldDonor = d;
                    currDonor = donorController.UpdateProfile(currDonor);
                    bankController.UpdateBloodBankDetails(oldDonor, currDonor);
                    BloodBankManagerMenu(d);
                    break;

                case BloodBankManagerOptions.AddBloodDepositRecord:
                    bankController.UpdateDepositBloodRecord(bank);
                    BloodBankManagerMenu(d);
                    break;

                case BloodBankManagerOptions.AddBloodWithdrawRecord:
                    bankController.UpdateWithdrawBloodRecord(bank);
                    BloodBankManagerMenu(d);
                    break;
                case BloodBankManagerOptions.OrganizeBloodDonationCamp:
                    campController.OrganizeBloodDonationCamps(bank, currDonor);
                    BloodBankManagerMenu(d);
                    break;

                case BloodBankManagerOptions.SeeBloodDonationCamp:
                    campController.GetBloodDonationCamps(bank, currDonor);
                    BloodBankManagerMenu(d);
                    break;

                case BloodBankManagerOptions.RemoveBloodDonationCamp:
                    campController.RemoveBloodDonationCamps(bank, currDonor);
                    BloodBankManagerMenu(d);
                    break;

                case BloodBankManagerOptions.SignOut:
                    Console.WriteLine(Message.SigningOut);
                    App.Start();
                    break;

                default:
                    Console.WriteLine(Message.EnterValidOption);
                    BloodBankManagerMenu(d);
                    break;
            }

        }


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
