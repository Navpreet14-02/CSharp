using BloodGuardian.Database;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BloodGuardian.View;
using BloodGuardian.Database;

namespace BloodGuardian.Models
{
    public class Request
    {

        public int RequestId { get; set; }
        public string RequesterName { get; set; }

        public long RequesterPhone { get; set; }
        public string BloodRequirementType { get; set; }   
        public string Address { get; set; }





    }
}
