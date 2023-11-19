using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View.Interfaces
{
    internal interface IBloodBankManagerView
    {
        BloodTransferReceipt CreateBloodDepositRecord();

        BloodBank InputBloodBankDetails(Donor d);

        BloodTransferReceipt CreateBloodWithdrawRecord();

        BloodDonationCamp InputBloodDonationCamp();
    }
}
