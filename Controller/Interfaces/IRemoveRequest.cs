using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IRemoveRequest
    {
        List<Request> GetBloodRequests();
        void AddBloodRequest(Request newRequest);
        void AdminRemoveRequest(Request request);
    }
}
