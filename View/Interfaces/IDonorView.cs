using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View.Interfaces
{
    internal interface IDonorView
    {
        Donor InputUserDetails();
        Donor InputUpdatedUserInfo(Donor oldDonor);
    }
}
