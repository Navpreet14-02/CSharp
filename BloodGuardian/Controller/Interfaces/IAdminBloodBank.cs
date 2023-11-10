using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IAdminBloodBank
    {
        void AdminViewBloodBanks(Donor d);
        void AdminRemoveBloodBank(Donor d);
    }
}
