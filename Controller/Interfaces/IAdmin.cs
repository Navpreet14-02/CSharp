using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAdmin
    {
        void UpdateProfile(Donor oldDonor, Donor newDonor);
        List<Donor> GetDonors();
        Donor FindDonorByBank(BloodBank bank);
        void AddAdmin(Donor d);
        void AdminRemoveDonor(Donor d);
    }
}
