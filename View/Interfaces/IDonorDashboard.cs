using BloodGuardian.Models;

namespace BloodGuardian.View.Interfaces
{
    public interface IDonorDashboard
    {
        Donor InputUpdatedUserInfo(Donor oldDonor);
        void ViewBloodDonationHistory(Donor d);
        Donor UpdateProfile(Donor d);
    }
}
