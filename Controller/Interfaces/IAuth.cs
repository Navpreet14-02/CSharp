using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAuth
    {
        void Register(Donor newDonor);
        void Login(string username, string password);

        bool CheckUserExists(string username);
    }
}
