using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface ISearch
    {
        void SearchBloodBanks(Donor d);
        void SearchBlood();
        void SearchBloodDonationCamp(Donor d);

    }
}
