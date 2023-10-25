using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Models
{
    internal class BloodBank : Donor
    {
        public int BankId {  get; set; }
        public string ManagerName {  get; set; }
        public string ManagerEmail {  get; set; }
        public string BankName { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        private List<BloodTransferReceipt> Blood_WithDrawal_Record { get; set; }
        private List<BloodTransferReceipt> Blood_Deposit_Record { get; set; }

        private Dictionary<string,int> BloodUnits { get; set; }
        private List<BloodDonationCamp> BloodDonationCamps { get; set; }


        public BloodBank()
        {
            ManagerName = string.Empty;
            BankName = string.Empty; //"A+", "A-","B+","B-","O+","O-","AB+","AB-"

            Blood_WithDrawal_Record = new List<BloodTransferReceipt>();
            Blood_Deposit_Record = new List<BloodTransferReceipt>();
            BloodUnits = new Dictionary<string, int>() { { "A+", 0 }, { "A-", 0 }, { "B+", 0 }, { "B-", 0 }, { "O+", 0 }, { "O-", 0 }, { "AB+", 0 }, { "AB-", 0 } };
            BloodDonationCamps = new List<BloodDonationCamp>();
        }
        public static BloodBank createBB(Donor d)
        {

            BloodBank bank = new BloodBank();
            Console.WriteLine("Enter the Name of your BloodBank: ");
            bank.BankName = Console.ReadLine();
            bank.ManagerEmail = d.Email;
            bank.ManagerName = d.Name;
            bank.Address = d.Address;
            bank.State = d.State;
            bank.City = d.City;

            return bank;

        }



    }
}
