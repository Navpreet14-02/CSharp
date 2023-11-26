using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View.Interfaces
{
    public interface IDonorDashboard
    {
        Donor InputUpdatedUserInfo(Donor oldDonor);
        void ViewBloodDonationHistory(Donor d);
        Donor UpdateProfile(Donor d);
    }
}
