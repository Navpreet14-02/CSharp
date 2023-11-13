using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IRemoveRequest
    {
        void AdminRemoveRequest(Donor d);
    }
}
