using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAdminBloodBank
    {
        List<BloodBank> GetBloodBanks();
        //void AdminViewBloodBanks(Donor d);
        void AdminRemoveBloodBank(BloodBank bank);
        BloodBank FindBloodBankbyId(int bankid);
    }
}
