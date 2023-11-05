namespace BloodGuardian.Models
{
    public class BloodTransferReceipt
    {
        public int Id { get; set; }

        public string BloodDonorName { get; set; }

        public string BloodReceiverName { get; set; }

        public string BloodGroup { get; set; }

        public string CustomerEmail { get; set; }
        public long CustomerPhone { get; set; }
        public DateTime BloodTransferDate { get; set; }

        public int BloodAmount { get; set; }



    }
}
