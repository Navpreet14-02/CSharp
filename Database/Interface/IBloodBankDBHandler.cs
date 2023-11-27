using BloodGuardian.Models;

namespace BloodGuardian.Database.Interface
{
    public interface IBloodBankDBHandler : IDB<BloodBank>
    {
        BloodBank FindBloodBankbyDonor(Donor d);
        public void UpdateBloodBank(BloodBank oldBB, BloodBank newBB);
        public void UpdateBloodTransferRecord(BloodBank bank, string bloodType, int newquantity, bool deposit);
        public Dictionary<BloodBank, List<BloodTransferReceipt>> GetDonorBloodDonationHistory(Donor d);



    }
}
