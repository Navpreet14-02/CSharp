using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IBloodBank
    {
        void AddBloodBank(Donor d);
        List<BloodBank> GetBloodBanks();
        BloodBank FindBloodBankbyId(int bankid);
        BloodBank FindBloodBankbyDonor(Donor d);
        void UpdateBloodBankDetails(Donor oldDonor, Donor newDonor);
        void RemoveBloodBank(BloodBank bank);
        void UpdateDepositBloodRecord(BloodBank bank);
        void UpdateWithdrawBloodRecord(BloodBank bank);
        public Dictionary<BloodBank, List<BloodTransferReceipt>> GetDonorBloodDonationHistory(Donor d);

    }

}
