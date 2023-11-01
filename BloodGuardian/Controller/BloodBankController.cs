using BloodGuardian.Common;
using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View;

namespace BloodGuardian.Controller
{
    internal class BloodBankController
    {
        public BloodBank createBloodBank(Donor d)
        {

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

                bank.BankName = name;
                Console.WriteLine(Message.SingleDashDesign);
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

            foreach (var grp in Donor.BloodGroups)
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

        public void UpdateBloodBankDetails(Donor oldDonor, Donor newDonor)
        {
            var bank = DBHandler.Instance.FindBloodBank(oldDonor, -1);

            var newBank = new BloodBank();
            while (true)
            {

                Console.Write(Message.EnterBloodBankName);
                string name = Console.ReadLine();
                if (name != String.Empty)
                {
                    try
                    {
                        Validation.ValidateName(name);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                newBank.BankName = name == String.Empty ? bank.BankName : name;
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

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
            newBank.ManagerUserName = bank.ManagerUserName;



            DBHandler.Instance.UpdateBloodBank(bank, newBank);

        }

        public void ViewBloodBanks(Donor d)
        {
            DBHandler.Instance.ReadBloodBanks().ForEach(bank =>
            {
                Console.WriteLine(Message.SingleDashDesign);
                Console.WriteLine("Id: " + bank.BankId);
                Console.WriteLine("Bank Name: " + bank.BankName);
                Console.WriteLine("Bank UserName: " + bank.ManagerUserName);
                Console.WriteLine("Manager Name: " + bank.ManagerName);
                Console.WriteLine("Manager Email: " + bank.ManagerEmail);
                Console.WriteLine("Manager Contact: " + bank.Contact);
                Console.WriteLine("Address: " + bank.Address);
                Console.WriteLine(Message.SingleDashDesign);

            });

        }


        public void RemoveBloodBank(Donor d)
        {
            ViewBloodBanks(d);

            Console.WriteLine(Message.DoubleDashDesign);

            int bankid;
            while (true)
            {
                Console.Write(Message.EnterBloodBankId);
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



            var bank = DBHandler.Instance.FindBloodBank(null, bankid);

            if (bank == null)
            {
                Console.WriteLine(Message.WrongBankId);
            }
            else
            {

                var donor = DBHandler.Instance.ReadDonors().Find((dn) => dn.UserName == bank.ManagerUserName);
                DBHandler.Instance.DeleteBloodBank(donor, bankid);
            }


        }

        public void UpdateDepositBloodRecord(BloodBank bank)
        {

            BloodTransferReceipt blood = BloodBankManagerUI.CreateBloodDepositRecord();

            blood.Id = bank.Blood_Deposit_Record.Count;
            bank.Blood_Deposit_Record.Add(blood);
            DBHandler.Instance.UpdateBloodBank(bank, bank);

            DBHandler.Instance.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, true);



        }


        public void UpdateWithdrawBloodRecord(BloodBank bank)
        {


            BloodTransferReceipt blood = BloodBankManagerUI.CreateBloodWithdrawRecord();


            blood.Id = bank.Blood_WithDrawal_Record.Count;

            bank.Blood_WithDrawal_Record.Add(blood);
            DBHandler.Instance.UpdateBloodBank(bank, bank);

            DBHandler.Instance.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, false);




        }
    }
}
