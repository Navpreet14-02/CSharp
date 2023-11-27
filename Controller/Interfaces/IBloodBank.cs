using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IBloodBank
    {
        void AddBloodBank(BloodBank bank);
        List<BloodBank> GetBloodBanks();
        BloodBank FindBloodBankbyId(int bankid);
        BloodBank FindBloodBankByDonor(Donor d);
        void UpdateBloodBank(BloodBank oldBank, BloodBank newBank);
        void UpdateDepositBloodRecord(BloodBank bank, BloodTransferReceipt blood);
        void UpdateWithdrawBloodRecord(BloodBank bank, BloodTransferReceipt blood);

    }

}
