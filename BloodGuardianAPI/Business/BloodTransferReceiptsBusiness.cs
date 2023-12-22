using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BloodGuardianAPI.Business
{
    public class BloodTransferReceiptsBusiness : IBloodTransferReceiptsBusiness
    {
        private readonly IBloodTransferReceiptsData _receiptsData;
        private readonly IBloodBanksData _banksData;


        public BloodTransferReceiptsBusiness(IBloodTransferReceiptsData receiptsData)
        {
            _receiptsData = receiptsData;
        }

        public IEnumerable<BloodTransferReceipt> GetBloodTransferReceipts(string type)
        {

            IEnumerable<BloodTransferReceipt> receipts;

            if (type != null)
            {
                receipts = _receiptsData.GetAllBloodTransferReceipts().Where(receipt=>receipt.Receipt_Type==type);
            }
            else
            {
                receipts = _receiptsData.GetAllBloodTransferReceipts();
            }

            return receipts;
        }


        public bool checkReceiptExists(BloodTransferReceipt receipt)
        {

            var ans = _receiptsData.GetAllBloodTransferReceipts().Where(r =>

                r.BloodId == receipt.BloodId &&
                r.BankId == receipt.BankId &&
                r.CustomerEmail == receipt.CustomerEmail &&
                r.CustomerName == receipt.CustomerName &&
                r.CustomerPhone == receipt.CustomerPhone &&
                r.BloodAmount == receipt.BloodAmount &&
                r.BloodGroup == receipt.BloodGroup &&
                r.BloodTransferDate == receipt.BloodTransferDate &&
                r.Receipt_Type == receipt.Receipt_Type
            );

            return ans != null;

        }

        public bool AddBloodTransferReceipt(BloodTransferReceipt receipt,int bankid)
        {



            var newReceipt = new BloodTransferReceipt()
            {
                BloodId = receipt.BloodId,
                BankId = bankid,
                CustomerEmail = receipt.CustomerEmail,
                CustomerName = receipt.CustomerName,
                CustomerPhone = receipt.CustomerPhone,
                BloodAmount = receipt.BloodAmount,
                BloodGroup = receipt.BloodGroup,
                BloodTransferDate = receipt.BloodTransferDate,
                Receipt_Type = receipt.Receipt_Type,
               
            };

            var bankBloodGroupMapping = _banksData.GetAllBankBloodGroupMapping().Single( 
                mapping =>
                    mapping.BankId == bankid &&
                    mapping.BloodId == newReceipt.BloodId
                );



            //if(checkReceiptExists(newReceipt))
            //{
            //    return false;
            //}

            _receiptsData.AddBloodTransferReceipt(newReceipt);

            _banksData.UpdateBloodGroupAmount(bankBloodGroupMapping, "Deposit", bankBloodGroupMapping.BloodAmount);


            //_dbContext.SaveChanges();

            return true;


        }

    }
}
