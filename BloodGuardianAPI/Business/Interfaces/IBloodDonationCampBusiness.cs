using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BloodGuardianAPI.Business.Interfaces
{
    public interface IBloodDonationCampBusiness
    {
        IEnumerable<BloodDonationCamp> GetBloodDonationCampsByBankId(int bankId);
        BloodDonationCamp GetBloodDonationCampDetails(int campId);
        IEnumerable<BloodDonationCamp> GetAllBloodDonationCamps();
        void AddBloodDonationCamp(int bankid, BloodDonationCamp camp);
        bool RemoveBloodDonationCamp(int campId);
        IEnumerable<BloodDonationCamp> SearchBloodDonationCamps(string state, string city);
    }
}
