using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IDonor
    {
        Donor AddDonor();

        Donor UpdateProfile(Donor d);
        Donor FindDonor(string username, string password);
        Donor FindDonorByBank(BloodBank bank);
        void ViewBloodDonationHistory(Donor d);


    }
}
