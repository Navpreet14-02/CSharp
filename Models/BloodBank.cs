
namespace BloodGuardian.Models
{
    public class BloodBank
    {
        public int BankId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerUserName { get; set; }
        public string ManagerEmail { get; set; }
        public long Contact { get; set; }

        public string BankName { get; set; }
        public string State { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public List<BloodTransferReceipt> Blood_WithDrawal_Record { get; set; }
        public List<BloodTransferReceipt> Blood_Deposit_Record { get; set; }

        public Dictionary<string, int> BloodUnits { get; set; }
        public List<BloodDonationCamp> BloodDonationCamps { get; set; }


        public BloodBank()
        {
            ManagerName = string.Empty;
            BankName = string.Empty;

            Blood_WithDrawal_Record = new List<BloodTransferReceipt>();
            Blood_Deposit_Record = new List<BloodTransferReceipt>();
            BloodUnits = new Dictionary<string, int>() { { "A+", 0 }, { "A-", 0 }, { "B+", 0 }, { "B-", 0 }, { "O+", 0 }, { "O-", 0 }, { "AB+", 0 }, { "AB-", 0 } };
            BloodDonationCamps = new List<BloodDonationCamp>();
        }



        public override bool Equals(object obj)
        {
            BloodBank bank2 = obj as BloodBank;

            if(bank2==null) return false;

            return
                this.BankId.Equals(bank2.BankId) &&
                this.BankName.Equals(bank2.BankName) &&
                this.ManagerName.Equals(bank2.ManagerName) &&
                this.ManagerUserName.Equals(bank2.ManagerUserName) &&
                this.ManagerEmail.Equals(bank2.ManagerEmail) &&
                this.Contact.Equals(bank2.Contact) &&
                this.State.Equals(bank2.State) &&
                this.City.Equals(bank2.City) &&
                this.Address.Equals(bank2.Address) &&
                this.Blood_WithDrawal_Record.Equals(bank2.Blood_WithDrawal_Record) &&
                this.Blood_Deposit_Record.Equals(bank2.Blood_Deposit_Record) &&
                this.BloodDonationCamps.Equals(bank2.BloodDonationCamps) &&
                this.BloodUnits.Equals(bank2.BloodUnits);

        }

    }
}
