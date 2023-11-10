using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Controller.Interfaces
{
    public interface ISearch
    {
        void SearchBloodBanks(Donor d);
        void SearchBlood();
        void SearchBloodDonationCamp(Donor d);

    }
}
