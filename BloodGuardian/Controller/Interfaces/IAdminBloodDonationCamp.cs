using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAdminBloodDonationCamp
    {
        void AdminViewBloodDonationCamps(Donor d);
        void AdminRemoveBloodDonationCamp(Donor d);
    }
}
