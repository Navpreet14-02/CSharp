using BloodGuardianAPI.Models;
using System.Linq;

namespace BloodGuardianAPI.DataAccess.Interfaces
{
    public interface IBloodTransferReceiptsData
    {

        IQueryable<BloodTransferReceipt> GetAllBloodTransferReceipts();
        void AddBloodTransferReceipt(BloodTransferReceipt receipt);
        void RemoveBloodTransferReceipt(BloodTransferReceipt receipt);

    }
}
