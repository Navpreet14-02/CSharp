using BloodGuardian.Models;

namespace BloodGuardian.Database.Interface
{
    public interface IDonorDBHandler : IDB<Donor>
    {

        IDonorDBHandler Instance { get; }
        public void UpdateDonor(Donor oldDonor, Donor newDonor);
    }
}
