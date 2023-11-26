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

        public void AddBloodBank(BloodBank bank)
        {
            _bankDBHandler.Add(bank);
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

        public BloodBank FindBloodBankByDonor(Donor d)
        {

            return _bankDBHandler.FindBloodBankbyDonor(d); 
        }

        public void UpdateBloodBank(BloodBank oldBank, BloodBank newBank)
        {


            _bankDBHandler.UpdateBloodBank(oldBank, newBank);

        }

        //public void AdminViewBloodBanks(Donor d)
        //{

        //    var banks = GetBloodBanks();

        //    if (banks.Count == 0)
        //    {
        //        Console.WriteLine(Message.NoRegisteredBloodBanks);
        //        return;
        //    }

        //    banks.ForEach(bank =>
        //    {
        //        Console.WriteLine(Message.SingleDashDesign);
        //        Console.WriteLine("Id: " + bank.BankId);
        //        Console.WriteLine("Bank Name: " + bank.BankName);
        //        Console.WriteLine("Bank Manager User Name: " + bank.ManagerUserName);
        //        Console.WriteLine("Manager Name: " + bank.ManagerName);
        //        Console.WriteLine("Manager Email: " + bank.ManagerEmail);
        //        Console.WriteLine("Manager Contact: " + bank.Contact);
        //        Console.WriteLine("Address: " + bank.Address);
        //        Console.WriteLine(Message.SingleDashDesign);

        //    });

        //}


        public void AdminRemoveBloodBank(BloodBank bank)
        {
 
            var donor = _donorDBHandler.FindDonorByBank(bank);
            _donorDBHandler.Delete(donor);
            _bankDBHandler.Delete(bank);



        }

        public void RemoveBloodBank(BloodBank bank)
        {
            _bankDBHandler.Delete(bank);
        }


        public void UpdateDepositBloodRecord(BloodBank bank,BloodTransferReceipt blood)
        {

            blood.Id = bank.Blood_Deposit_Record.Count;
            bank.Blood_Deposit_Record.Add(blood);
            _bankDBHandler.UpdateBloodBank(bank, bank);

            _bankDBHandler.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, true);



        }


        public void UpdateWithdrawBloodRecord(BloodBank bank,BloodTransferReceipt blood)
        {
            blood.Id = bank.Blood_WithDrawal_Record.Count;

            bank.Blood_WithDrawal_Record.Add(blood);
            _bankDBHandler.UpdateBloodBank(bank, bank);

            _bankDBHandler.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, false);


        }


    }
}
