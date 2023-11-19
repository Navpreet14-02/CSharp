using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IBloodBank
    { 
        List<BloodBank> GetBloodBanks();
        BloodBank FindBloodBankbyId(int bankid);
        BloodBank FindBloodBank(Donor d);
        void UpdateBloodBankDetails(Donor oldDonor, Donor newDonor);
        void RemoveBloodBank(BloodBank bank);
        void UpdateDepositBloodRecord(BloodBank bank);
        void UpdateWithdrawBloodRecord(BloodBank bank);

    }

}
