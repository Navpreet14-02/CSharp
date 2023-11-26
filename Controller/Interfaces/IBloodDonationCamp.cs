using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IBloodDonationCamp
    {
        void RemoveBloodDonationCamps(BloodBank bank, int campid);
        void OrganizeBloodDonationCamps(BloodBank bank, BloodDonationCamp newCamp);
    }
}
