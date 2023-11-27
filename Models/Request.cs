
namespace BloodGuardian.Models
{
    public class Request
    {

        public int RequestId { get; set; }
        public string RequesterName { get; set; }

        public long RequesterPhone { get; set; }
        public string BloodRequirementType { get; set; }
        public string Address { get; set; }


        public override bool Equals(object obj)
        {
            Request r1 = obj as Request;


            if (this == null && r1 == null) return true;
            if (r1 == null) return false;



            return
                this.RequestId.Equals(r1.RequestId) &&
                this.RequesterName.Equals(r1.RequesterName) &&
                this.RequesterPhone.Equals(r1.RequesterPhone) &&
                this.BloodRequirementType.Equals(r1.BloodRequirementType) &&
                this.Address.Equals(r1.Address);


        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
