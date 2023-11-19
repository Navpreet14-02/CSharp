using BloodGuardian.Models;

namespace BloodGuardian.Database.Interface
{
    public interface IDonorDBHandler : IDB<Donor>
    {

        public void UpdateDonor(Donor oldDonor, Donor newDonor);

        Donor FindDonorByBank(BloodBank bank);
        Donor FindDonorByCredentials(string username, string password);
    }
}
