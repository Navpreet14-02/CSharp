using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAdminBloodDonationCamp
    {
        void RemoveBloodDonationCamps(BloodBank bank, int campid);
    }
}
