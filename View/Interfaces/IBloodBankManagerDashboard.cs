using BloodGuardian.Models;

namespace BloodGuardian.View.Interfaces
{
    public interface IBloodBankManagerDashboard
    {

        void UpdateBloodBankDetails(Donor oldDonor, Donor newDonor);
        void CreateBloodDepositRecord(BloodBank bank);

        void RemoveBloodDonationCamps(BloodBank bank, Donor d);
        void CreateBloodBank(Donor d);
        void ViewBloodDonationCamps(BloodBank bank, Donor d);
        void CreateBloodWithdrawRecord(BloodBank bank);

        void CreateBloodDonationCamp(BloodBank bank, Donor d);
    }
}
