using BloodGuardianAPI.Models;
using System.Collections.Generic;

namespace BloodGuardianAPI.Business.Interfaces
{
    public interface IBloodTransferReceiptsBusiness
    {
        IEnumerable<BloodTransferReceipt> GetBloodTransferReceipts(string type);
        bool AddBloodTransferReceipt(BloodTransferReceipt receipt, int bankid);
    }
}
