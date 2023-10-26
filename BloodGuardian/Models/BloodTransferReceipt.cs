using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Models
{
    internal class BloodTransferReceipt
    {
        public string Id { get; set; }
        public string BloodDonorName { get; set; }

        public string BloodReceiverName { get; set; }

        public string BloodGroup { get; set; }

        public string CustomerEmail { get; set; }
        public long CustomerPhone { get; set; }
        public DateTime BloodTransferDate { get; set; }

        public int BloodAmount { get; set; }



    }
}
