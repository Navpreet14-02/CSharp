using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using System.Linq;

namespace BloodGuardianAPI.DataAccess
{
    public class BloodRequestsData : IBloodRequestsData
    {

        private readonly AppDbContext _dbContext;

        public BloodRequestsData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<BloodRequest> GetAllBloodRequests()
        {
            return _dbContext.BloodRequests;
        }

        public void AddBloodRequest(BloodRequest request)
        {
            _dbContext.BloodRequests.Add(request);
            _dbContext.SaveChanges();
        }

        public void RemoveBloodRequest(BloodRequest request)
        {
            _dbContext.BloodRequests.Remove(request);
            _dbContext.SaveChanges();

        }
    }
}
