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


        //public override bool Equals(object obj)
        //{
        //    var receipt2 = obj as BloodTransferReceipt;
        //    if (receipt2==null) return false;

        //    return
        //        this.Id.Equals(receipt2.Id) &&
        //        this.BloodDonorName.Equals(receipt2.BloodDonorName) &&
        //        this.BloodReceiverName.Equals(receipt2.BloodReceiverName) &&
        //        this.BloodGroup.Equals(receipt2.BloodGroup) &&
        //        this.CustomerEmail.Equals(receipt2.CustomerEmail) &&
        //        this.CustomerPhone.Equals(receipt2.CustomerPhone) &&
        //        this.BloodTransferDate.Equals(receipt2.BloodTransferDate) &&
        //        this.BloodAmount.Equals(receipt2.BloodAmount);
        //}



    }
}
