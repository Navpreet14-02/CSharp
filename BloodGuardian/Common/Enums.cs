using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Common
{
    public enum AdminOptions
    {
        UpdateProfile = 1,
        AddNewAdmin = 2,
        SeeAllDonors = 3,
        RemoveDonor = 4,
        SeeAllBloodBanks = 5,
        RemoveBloodBank = 6,
        SeeBloodDonationCamps = 7,
        RemoveBloodDonationCamps = 8,
        RemoveRequest = 9,
        SignOut = 10,
    }

    public enum HomePageOptions
    {
        Login = 1,
        Register = 2,
        SeeBloodRequests = 3,
        AddBloodRequest = 4,
        SearchBlood = 5,
        Exit = 6,
    }

    public enum BloodBankManagerOptions
    {
        UpdateProfile = 1,
        AddBloodDepositRecord = 2,
        AddBloodWithdrawRecord = 3,
        OrganizeBloodDonationCamp = 4,
        SeeBloodDonationCamp = 5,
        RemoveBloodDonationCamp = 6,
        SignOut = 7,
    }

    public enum DonorOptions
    {
        UpdateProfile = 1,
        SearchBloodBanks = 2,
        SearchBloodDonationCamps = 3,
        SeeBloodDonationHistory = 4,
        SignOut = 5,
    }

    public enum roles
    {
        Admin,
        Donor,
        BloodBankManager,
    }


}
