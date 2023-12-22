using BloodGuardianAPI.Models;
using System.Linq;

namespace BloodGuardianAPI.DataAccess.Interfaces
{
    public interface IBloodRequestsData
    {
        IQueryable<BloodRequest> GetAllBloodRequests();
        void AddBloodRequest(BloodRequest request);
        void RemoveBloodRequest(BloodRequest request);
    }
}
