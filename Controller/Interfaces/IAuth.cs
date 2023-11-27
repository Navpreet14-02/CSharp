using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAuth
    {
        void Register(Donor newDonor);
        Donor Login(string username, string password);

        bool CheckUserNameExists(string username);
    }
}
