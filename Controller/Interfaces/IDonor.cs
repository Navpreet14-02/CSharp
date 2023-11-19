using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IDonor
    {

        Donor UpdateProfile(Donor d);
        Donor FindDonorByUserName(string username);
        void ViewBloodDonationHistory(Donor d);


    }
}
