using BloodGuardianAPI.Models;
using System.Linq;

namespace BloodGuardianAPI.DataAccess.Interfaces
{
    public interface IBloodDonationCampsData
    {
        IQueryable<BloodDonationCamp> GetAllBloodDonationCamps();
        void AddBloodDonationCamp(BloodDonationCamp camp);
        void RemoveBloodDonationCamp(BloodDonationCamp camp);
    }
}
