using BloodGuardianAPI.Models;
using System.Collections.Generic;

namespace BloodGuardianAPI.Business.Interfaces
{
    public interface IBloodRequestsBusiness
    {
        IEnumerable<BloodRequest> GetBloodRequests();
        bool AddBloodRequest(BloodRequest bloodRequest);
        bool RemoveBloodRequest(int requestId);
    }
}
