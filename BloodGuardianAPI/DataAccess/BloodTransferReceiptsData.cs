using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BloodGuardianAPI.DataAccess
{
    public class BloodTransferReceiptsData : IBloodTransferReceiptsData
    {

        private readonly AppDbContext _dbContext;

        public BloodTransferReceiptsData(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<BloodTransferReceipt> GetAllBloodTransferReceipts()
        {
            return _dbContext.BloodTransferReceipts.AsQueryable();
        }

        public void AddBloodTransferReceipt(BloodTransferReceipt receipt)
        {
            _dbContext.BloodTransferReceipts.Add(receipt);


            _dbContext.SaveChanges();
        }

        public void RemoveBloodTransferReceipt(BloodTransferReceipt receipt)
        {
            _dbContext.BloodTransferReceipts.Remove(receipt);
            _dbContext.SaveChanges();
        }

    }
}
