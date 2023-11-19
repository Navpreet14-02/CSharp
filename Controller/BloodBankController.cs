using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.View.Interfaces;

namespace BloodGuardian.Controller

{


    internal class BloodBankController : IAdminBloodBank, IBloodBank
    {

        private IBloodBankDBHandler _bankDBHandler;
        private IDonorDBHandler _donorDBHandler;

        public BloodBankController(IBloodBankDBHandler bankDBHandler, IDonorDBHandler donorDBHandler)
        {
            _bankDBHandler = bankDBHandler;
            _donorDBHandler = donorDBHandler;
        }


        public List<BloodBank> GetBloodBanks()
        {
            return _bankDBHandler.Get();
        }

        public BloodBank FindBloodBankbyId(int bankid)
        {
            var banks = GetBloodBanks();
            if (bankid < 0 || bankid > banks.Count) return null;
            return banks[bankid];

        }

        public BloodBank FindBloodBank(Donor d)
        {
            return _bankDBHandler.FindBloodBankbyDonor(d);
        }

        public void UpdateBloodBankDetails(Donor oldDonor, Donor newDonor)
        {
            var bank = FindBloodBank(oldDonor);

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



            _bankDBHandler.UpdateBloodBank(bank, newBank);

        }

        public void AdminViewBloodBanks(Donor d)
        {

            var banks = GetBloodBanks();

            if (banks.Count == 0)
            {
                Console.WriteLine(Message.NoRegisteredBloodBanks);
                return;
            }

            banks.ForEach(bank =>
            {
                Console.WriteLine(Message.SingleDashDesign);
                Console.WriteLine("Id: " + bank.BankId);
                Console.WriteLine("Bank Name: " + bank.BankName);
                Console.WriteLine("Bank Manager User Name: " + bank.ManagerUserName);
                Console.WriteLine("Manager Name: " + bank.ManagerName);
                Console.WriteLine("Manager Email: " + bank.ManagerEmail);
                Console.WriteLine("Manager Contact: " + bank.Contact);
                Console.WriteLine("Address: " + bank.Address);
                Console.WriteLine(Message.SingleDashDesign);

            });

        }


        public void AdminRemoveBloodBank(Donor d)
        {
            AdminViewBloodBanks(d);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine(Message.EnterBloodBankId);


            int bankid = InputHandler.InputId();

            var bank = FindBloodBankbyId(bankid);

            if (bank == null)
            {
                Console.WriteLine(Message.WrongBankId);
            }
            else
            {
                var donor = _donorDBHandler.FindDonorByBank(bank);
                _donorDBHandler.Delete(donor);
                RemoveBloodBank(bank);
            }


        }

        public void RemoveBloodBank(BloodBank bank)
        {
            _bankDBHandler.Delete(bank);
        }


        public void UpdateDepositBloodRecord(BloodBank bank)
        {
            BloodBankManagerView bloodBankManagerUI = new BloodBankManagerView();
            BloodTransferReceipt blood = bloodBankManagerUI.CreateBloodDepositRecord();

            blood.Id = bank.Blood_Deposit_Record.Count;
            bank.Blood_Deposit_Record.Add(blood);
            _bankDBHandler.UpdateBloodBank(bank, bank);

            _bankDBHandler.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, true);



        }


        public void UpdateWithdrawBloodRecord(BloodBank bank)
        {

            BloodBankManagerView bloodBankManagerUI = new BloodBankManagerView();
            BloodTransferReceipt blood = bloodBankManagerUI.CreateBloodWithdrawRecord();


            blood.Id = bank.Blood_WithDrawal_Record.Count;

            bank.Blood_WithDrawal_Record.Add(blood);
            _bankDBHandler.UpdateBloodBank(bank, bank);

            _bankDBHandler.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, false);


        }


    }
}
