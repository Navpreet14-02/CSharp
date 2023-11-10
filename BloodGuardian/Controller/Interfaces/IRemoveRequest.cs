using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Controller.Interfaces
{
    public interface IRemoveRequest
    {
        void AdminRemoveRequest(Donor d);
    }
}
