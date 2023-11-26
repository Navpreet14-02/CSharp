using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAdminBloodDonationCamp
    {
        //void AdminViewBloodDonationCamps(Donor d);
        //void AdminRemoveBloodDonationCamp(Donor d);
        void RemoveBloodDonationCamps(BloodBank bank, int campid);
    }
}
