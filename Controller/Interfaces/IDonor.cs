using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IDonor
    {

        void UpdateProfile(Donor oldDonor, Donor newDonor);
        Donor FindDonorByUserName(string username);
        Dictionary<BloodBank, List<BloodTransferReceipt>> GetBloodDonationHistory(Donor d);


    }
}
