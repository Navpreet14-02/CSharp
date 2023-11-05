using BloodGuardian.Common;
using BloodGuardian.Models;
using BloodGuardian.Controller;

namespace BloodGuardian.View
{
    public class BloodBankManagerUI
    {



        public static void BloodBankManagerMenu(Donor d)
        {


            BloodBankController bankController = new BloodBankController();
            BloodDonationCampController campController = new BloodDonationCampController();
            DonorController donorController = new DonorController();

            Donor currDonor = d;

            BloodBank bank = bankController.FindBloodBankbyDonor(currDonor);


            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.PrintBloodBankManagerOptions);
            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();


            BloodBankManagerOptions option;
            while (true)
            {
                Console.WriteLine(Message.SingleDashDesign);
                Console.Write(Message.EnterInput);
                string input = Console.ReadLine();

                BloodBankManagerOptions result;
                if (input == string.Empty || !Enum.TryParse<BloodBankManagerOptions>(input, out result))
                {
                    Console.WriteLine(Message.EnterValidOption);
                    continue;
                }

                option = Enum.Parse<BloodBankManagerOptions>(input);
                break;

            }

            switch (option)
            {
                case BloodBankManagerOptions.UpdateProfile:
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
                    Console.WriteLine("Signing Out...");
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
            blood.BloodDonorName= InputHandler.InputName(false);


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

        public BloodBank createBloodBank(Donor d)
        {

            //if (d.Role != roles.BloodBankManager)
            //{
            //    Console.WriteLine(Message.NotAuthorized);
            //    return null;
            //}

            BloodBank bank = new BloodBank();



            while (true)
            {

                Console.Write(Message.EnterBloodBankName);
                string name = Console.ReadLine();
                try
                {
                    Validation.ValidateName(name);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine(Message.SingleDashDesign);
                bank.BankName = name;
                break;

            }

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

            while (true)
            {
                Console.Write(Message.EnterPatientName);

                string name = Console.ReadLine();
                try
                {
                    Validation.ValidateName(name);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }



                blood.BloodReceiverName = name;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }


            while (true)
            {
                Console.Write(Message.BloodWithdrawnType);

                string bloodgrp = Console.ReadLine();
                try
                {
                    Validation.ValidateBloodGroup(bloodgrp);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                blood.BloodGroup = bloodgrp;
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }


            while (true)
            {
                Console.Write(Message.EnterPatientEmail);

                string email = Console.ReadLine();
                try
                {
                    Validation.ValidateEmail(email);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }



                blood.CustomerEmail = email;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }


            while (true)
            {

                Console.Write(Message.EnterPatientPhone);
                string phoneno = Console.ReadLine();
                try
                {
                    Validation.ValidatePhone(phoneno);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                blood.CustomerPhone = Convert.ToInt64(phoneno);

                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

    
            while (true)
            {


                Console.Write(Message.EnterTransferDate);
                string transferDate = Console.ReadLine();

                try
                {
                    Validation.ValidateDate(transferDate);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                blood.BloodTransferDate = DateTime.Parse(transferDate);
                break;


            }


            while (true)
            {
                Console.Write(Message.EnterBloodWithdrawnAmount);
                string amnt = Console.ReadLine();

                try
                {
                    Validation.ValidateBloodAmount(amnt);
                }
                catch(InvalidDataException e) 
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                blood.BloodAmount = Convert.ToInt32(amnt);
                break;

            }

            return blood;
        }


        public BloodDonationCamp InputBloodDonationCamp()
        {
            var camp = new BloodDonationCamp();

            Console.WriteLine(Message.SingleDashDesign);
            Console.WriteLine(Message.EnterDonationCampDetails);


            while (true)
            {
                Console.Write(Message.EnterCampDate);
                string campDate = Console.ReadLine();

                try
                {
                    Validation.ValidateDate(campDate);
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                camp.Date = DateTime.Parse(campDate);
                Console.WriteLine(Message.SingleDashDesign);
                break;


            }


            while (true)
            {

                Console.Write(Message.EnterCampState);
                string state = Console.ReadLine();

                if (state != String.Empty)
                {
                    try
                    {
                        Validation.ValidateState(state);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                camp.Camp_State=state;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }


            while (true)
            {

                Console.Write(Message.EnterCampCity);
                string city = Console.ReadLine();

                if (city != String.Empty)
                {
                    try
                    {
                        Validation.ValidateCity(city);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                camp.Camp_City = city;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }


            while (true)
            {

                Console.Write(Message.EnterCampAddress);
                string address = Console.ReadLine();

                if (address != String.Empty)
                {
                    try
                    {
                        Validation.ValidateCity(address);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }
                camp.Camp_Address = address;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }


            while (true)
            {

                Console.Write(Message.EnterCampStartTime);
                string start_time = Console.ReadLine();
                
                try
                {
                    Validation.ValidateTime(start_time);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                
                camp.Start_Time = TimeOnly.Parse(start_time);
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }


            while (true)
            {

                Console.Write(Message.EnterCampEndTime);
                string end_time = Console.ReadLine();

                try
                {
                    Validation.ValidateTime(end_time);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                camp.End_Time = TimeOnly.Parse(end_time);
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

            return camp;
        }



    }
}
