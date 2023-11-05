
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
