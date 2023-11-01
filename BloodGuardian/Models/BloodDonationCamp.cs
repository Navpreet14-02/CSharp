using BloodGuardian.Database;
using BloodGuardian.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Models
{
    public class BloodDonationCamp
    {


        public int camp_id { get; set; }

        public DateTime Date {  get; set; }

        public string Camp_State { get; set; }

        public string Camp_City { get; set; }
        public string Camp_Address { get; set; }
        public TimeOnly Start_Time { get; set; }
        public TimeOnly End_Time { get; set;}




    }

}
