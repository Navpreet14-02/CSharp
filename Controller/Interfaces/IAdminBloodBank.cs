using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAdminBloodBank
    {
        void AdminViewBloodBanks(Donor d);
        void AdminRemoveBloodBank(Donor d);
    }
}
