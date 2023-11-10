using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAdmin
    {
        Donor UpdateProfile(Donor d);

        void AdminViewDonors(Donor d);
        void AddAdmin(Donor d);
        void AdminRemoveDonor(Donor d);
    }
}
