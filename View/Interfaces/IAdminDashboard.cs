using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View.Interfaces
{
    internal interface IAdminDashboard
    {
        void CreateAdmin(Donor d);
        void RemoveRequest(Donor d);
        void AdminViewDonors(Donor d);
        void AdminViewBloodBanks(Donor d);
        void RemoveBloodBank(Donor d);
        void ViewBloodDonationCamps(Donor d);
        void RemoveBloodDonationCamp(Donor d);
        void RemoveDonor(Donor d);

    }
}
