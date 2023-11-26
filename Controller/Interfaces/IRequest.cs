using BloodGuardian.Models;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IRequest
    {

        List<Request> GetBloodRequests();
        void AddBloodRequest(Request newRequest);
    }
}
