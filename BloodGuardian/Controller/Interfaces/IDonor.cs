using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IDonor
    {
        Donor AddDonor();

        Donor UpdateProfile(Donor d);
        Donor FindDonorByCredentials(string username, string password);
        Donor FindDonorByUserName(string username);

        Donor FindDonorByBank(BloodBank bank);
        void ViewBloodDonationHistory(Donor d);


    }
}
