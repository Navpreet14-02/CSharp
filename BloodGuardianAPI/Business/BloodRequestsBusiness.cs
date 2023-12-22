using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodGuardianAPI.Business
{
    public class BloodRequestsBusiness : IBloodRequestsBusiness
    {
        private readonly IBloodRequestsData _requestsData;

        public BloodRequestsBusiness(IBloodRequestsData requestsData)
        {
            _requestsData = requestsData;
        }

        public IEnumerable<BloodRequest> GetBloodRequests()
        {
            return _requestsData.GetAllBloodRequests();
        }


        private bool CheckRequestExists(BloodRequest request)
        {
            var res = _requestsData.GetAllBloodRequests()
                    .Any(
                        req =>
                        req.RequesterName == request.RequesterName &&
                        req.RequesterPhone == request.RequesterPhone &&
                        req.BloodRequirementType == request.BloodRequirementType &&
                        req.Address == request.Address
                    );

            return res;
        }

        public bool AddBloodRequest(BloodRequest bloodRequest)
        {

            if (CheckRequestExists(bloodRequest))
            {
                return false;
            }

            _requestsData.AddBloodRequest(bloodRequest);

            return true;
        }

        public bool RemoveBloodRequest(int requestId)
        {
            

            var currequest = _requestsData.GetAllBloodRequests().FirstOrDefault(r=>r.Id==requestId);
            if (currequest == null)
            {
                return false;
            }

            _requestsData.RemoveBloodRequest(currequest);
            

            return true;

        }
    }
}
