using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace BloodGuardianAPI.DataAccess
{
    public class BloodBanksData : IBloodBanksData
    {

        private readonly AppDbContext _dbContext;

        public BloodBanksData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BloodBank> GetAllBloodBanks()
        {
            return _dbContext.BloodBanks.ToList();

        }

        public EntityEntry<BloodBank> AddBloodBank(BloodBank bank)
        {
            var addedBank = _dbContext.BloodBanks.Add(bank);
            _dbContext.SaveChanges();

            return addedBank;

        }

        public IQueryable<BankBloodGroupMapping> GetAllBankBloodGroupMapping()
        {
            return _dbContext.BankBloodMapping.AsQueryable();

        }

        public void AddBankBloodGroupMapping(BankBloodGroupMapping mapping)
        {
            _dbContext.BankBloodMapping.Add(mapping);
            _dbContext.SaveChanges();

        }

        public void UpdateBloodGroupAmount(BankBloodGroupMapping mapping,string type,int BloodAmnt)
        {
            var currMapping = _dbContext.BankBloodMapping.Find(mapping.Id);


            if (type == "Deposit")
            {
                currMapping.BloodAmount += BloodAmnt;
            }
            else
            {
                currMapping.BloodAmount -= BloodAmnt;

                if (currMapping.BloodAmount < 0) currMapping.BloodAmount = 0;
            }

            _dbContext.SaveChanges();
        }

        public void RemoveBloodBank(BloodBank bank)
        {
            _dbContext.BloodBanks.Remove(bank);
            _dbContext.SaveChanges();
        }
    }
}
