using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using System.Linq;

namespace BloodGuardianAPI.DataAccess
{
    public class BloodDonationCampsData : IBloodDonationCampsData
    {

        private readonly AppDbContext _dbContext;

        public BloodDonationCampsData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<BloodDonationCamp> GetAllBloodDonationCamps()
        {
            return _dbContext.BloodDonationCamps;
        }

        public void AddBloodDonationCamp(BloodDonationCamp camp)
        {
            _dbContext.BloodDonationCamps.Add(camp);
        }

        public void RemoveBloodDonationCamp(BloodDonationCamp camp)
        {
            _dbContext.BloodDonationCamps.Remove(camp);
        }

    }
}
