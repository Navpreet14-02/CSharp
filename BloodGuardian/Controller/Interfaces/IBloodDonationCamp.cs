using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IBloodDonationCamp
    {
        void OrganizeBloodDonationCamps(BloodBank bank, Donor d);
        void GetBloodDonationCamps(BloodBank bank, Donor d);
        void RemoveBloodDonationCamps(BloodBank bank, Donor d);
    }
}
