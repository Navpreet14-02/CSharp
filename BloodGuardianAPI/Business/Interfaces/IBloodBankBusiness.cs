using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using System.Collections.Generic;

namespace BloodGuardianAPI.Business.Interfaces
{
    public interface IBloodBankBusiness
    {
        IEnumerable<BloodBank> GetAllBloodBanks();
        BloodBank GetBloodBankDetails(int id);
        bool AddBloodBank(RegisterBloodBankModel inputBank, string userId);
        //bool AddBloodBank(RegisterBloodBankModel inputBank);
        bool RemoveBloodBank(int bankId);
        IEnumerable<BloodBank> SearchBloodBanks(string state, string city);
        IEnumerable<BloodBank> SearchBlood(string state, string city, string BloodType);
    }
}
