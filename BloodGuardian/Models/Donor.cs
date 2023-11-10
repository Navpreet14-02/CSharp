﻿using BloodGuardian.Common;

namespace BloodGuardian.Models
{

    public class Donor
    {

        public int Donorid { get; set; }

        public string UserName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string BloodGrp{ get; set; }
        public roles Role { get; set; }



    }
}
