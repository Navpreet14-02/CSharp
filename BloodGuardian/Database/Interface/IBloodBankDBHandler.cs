using BloodGuardian.Models;

namespace BloodGuardian.Database.Interface
{
    public interface IBloodBankDBHandler : IDB<BloodBank>
    {
        IBloodBankDBHandler Instance { get; }
        public void UpdateBloodBank(BloodBank oldBB, BloodBank newBB);
        public void UpdateBloodTransferRecord(BloodBank bank, string bloodType, int newquantity, bool deposit);


    }
}
