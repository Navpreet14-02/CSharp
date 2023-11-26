using BloodGuardian.Common.Enums;

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
        public string BloodGrp { get; set; }
        public Roles Role { get; set; }



        public override bool Equals(object obj)
        {
            Donor d1 = obj as Donor;

            if(d1 == null) return false;

            return
                this.Donorid.Equals(d1.Donorid) &&
                this.Name.Equals(d1.Name) &&
                this.UserName.Equals(d1.UserName) &&
                this.Age.Equals(d1.Age) &&
                this.Email.Equals(d1.Email) &&
                this.State.Equals(d1.State) &&
                this.City.Equals(d1.City) &&
                this.Password.Equals(d1.Password) &&
                this.BloodGrp.Equals(d1.BloodGrp) &&
                this.Role.Equals(d1.Role) &&
                this.Phone.Equals(d1.Phone) &&
                this.Address.Equals(d1.Address);

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
