using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Models
{
    internal class BloodDonationCamp
    {
        public DateTime Date {  get; set; }

        public string Camp_State { get; set; }

        public string Camp_City { get; set; }
        public string Camp_Address { get; set; }
        public TimeSpan Start_Time { get; set; }
        public TimeSpan End_Time { get; set;}


    }
}
