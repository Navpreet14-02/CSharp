
namespace BloodGuardian.Models
{
    public class BloodDonationCamp
    {


        public int camp_id { get; set; }

        public DateTime Date { get; set; }

        public string Camp_State { get; set; }

        public string Camp_City { get; set; }
        public string Camp_Address { get; set; }
        public TimeOnly Start_Time { get; set; }
        public TimeOnly End_Time { get; set; }


        public override bool Equals(object obj)
        {
            var camp = obj as BloodDonationCamp;
            if (camp == null) return false;

            return
                this.camp_id.Equals(camp.camp_id) &&
                this.Date.Equals(camp.Date) &&
                this.Camp_State.Equals(camp.Camp_State) &&
                this.Camp_City.Equals(camp.Camp_City) &&
                this.Camp_Address.Equals(camp.Camp_Address) &&
                this.Start_Time.Equals(camp.Start_Time) && 
                this.End_Time.Equals(camp.End_Time);
        }


    }

}
