using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IBloodDonationCamp
    {
        void OrganizeBloodDonationCamps(BloodBank bank, Donor d);
        void GetBloodDonationCamps(BloodBank bank, Donor d);
        void RemoveBloodDonationCamps(BloodBank bank, Donor d);
    }
}
