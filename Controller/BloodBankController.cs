using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;

namespace BloodGuardian.Controller

{


    public class BloodBankController : IAdminBloodBank, IBloodBank
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
            var banks = _bankDBHandler.Get();
            return banks.Find(bank=>bank.BankId==bankid);

        }

        public BloodBank FindBloodBankByDonor(Donor d)
        {

            return _bankDBHandler.FindBloodBankbyDonor(d);
        }

        public void UpdateBloodBank(BloodBank oldBank, BloodBank newBank)
        {


            _bankDBHandler.UpdateBloodBank(oldBank, newBank);

        }


        public void AdminRemoveBloodBank(BloodBank bank)
        {

            var donor = _donorDBHandler.FindDonorByBank(bank);
            _donorDBHandler.Delete(donor);
            _bankDBHandler.Delete(bank);



        }


        public void UpdateDepositBloodRecord(BloodBank bank, BloodTransferReceipt blood)
        {

            blood.Id = bank.Blood_Deposit_Record.Count;
            bank.Blood_Deposit_Record.Add(blood);
            _bankDBHandler.UpdateBloodBank(bank, bank);

            _bankDBHandler.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, true);



        }


        public void UpdateWithdrawBloodRecord(BloodBank bank, BloodTransferReceipt blood)
        {
            blood.Id = bank.Blood_WithDrawal_Record.Count;

            bank.Blood_WithDrawal_Record.Add(blood);
            _bankDBHandler.UpdateBloodBank(bank, bank);

            _bankDBHandler.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, false);


        }


    }
}
