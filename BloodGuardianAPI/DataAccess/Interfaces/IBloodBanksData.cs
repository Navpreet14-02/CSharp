using BloodGuardianAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace BloodGuardianAPI.DataAccess.Interfaces
{
    public interface IBloodBanksData
    {
        List<BloodBank> GetAllBloodBanks();
        EntityEntry<BloodBank> AddBloodBank(BloodBank bank);
        void AddBankBloodGroupMapping(BankBloodGroupMapping mapping);
        IQueryable<BankBloodGroupMapping> GetAllBankBloodGroupMapping();
        void UpdateBloodGroupAmount(BankBloodGroupMapping mapping, string type, int BloodAmnt);
        void RemoveBloodBank(BloodBank bank);
    }
}
