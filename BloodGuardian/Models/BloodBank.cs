using BloodGuardian.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodGuardian.View;

namespace BloodGuardian.Models
{
    internal class BloodBank
    {
        public int BankId {  get; set; }
        public string ManagerName {  get; set; }
        public string ManagerEmail {  get; set; }
        public long Contact { get; set; }

        public string BankName { get; set; }
        public string State { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public List<BloodTransferReceipt> Blood_WithDrawal_Record { get; set; }
        public List<BloodTransferReceipt> Blood_Deposit_Record { get; set; }

        public Dictionary<string,int> BloodUnits { get; set; }
        public List<BloodDonationCamp> BloodDonationCamps { get; set; }


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
            bank.Contact = d.Phone;

            Console.WriteLine("Enter the quantities for the blood types available with you (ml): ");

            foreach(var grp in Donor.BloodGroups)
            {
                Console.Write(grp+": ");
                var input=Console.ReadLine();
                bank.BloodUnits[grp] = input==""?0:Convert.ToInt32(input);

            }


            return bank;

        }

        public static void UpdateBloodBankDetails(Donor oldDonor,Donor newDonor)
        {
            var bank = DBHandler.FindBloodBank(oldDonor);


            Console.WriteLine("Enter name of your bloodbank: ");
            var name = Console.ReadLine();

            var newBank = new BloodBank();
            newBank.BankName = name;
            newBank.ManagerEmail = newDonor.Email;
            newBank.ManagerName= newDonor.Name;
            newBank.Address = newDonor.Address;
            newBank.State=newDonor.State;
            newBank.City = newDonor.City;
            newBank.Contact=newDonor.Phone;



            DBHandler.UpdateBloodBank(bank, newBank);
            
        }

        public static void UpdateBloodQuantity(Donor d)
        {
            var bank = DBHandler.FindBloodBank(d);

            Console.WriteLine("---------------------------------------");
            Console.Write("Enter the blood group you want to update the quantity of - A+,A-,B+,B-,O+,O-,AB+,AB- : ");
            var input = Console.ReadLine();
            Console.Write("Enter the new quantity of the blood: ");
            var quantity = Convert.ToInt32(Console.ReadLine());

            //DBHandler.UpdateBloodBank(bank, input, quantity);


            App.BBManagerMenu(d);

        }



        public static void UpdateDepositBloodRecord(Donor d)
        {

            var bank = DBHandler.FindBloodBank(d);

            BloodTransferReceipt blood = new BloodTransferReceipt();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Enter following details: ");

            Console.Write("Enter the Name of the Donor: ");
            blood.BloodDonorName = Console.ReadLine();

            Console.Write("Enter the Type of Blood Donated: ");
            blood.BloodGroup = Console.ReadLine();

            Console.Write("Enter the Email of the Donor: ");
            blood.CustomerEmail = Console.ReadLine();

            Console.Write("Enter the phone no. of the Donor: ");
            blood.CustomerPhone = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter the Date for the Blood Transfer - MM/DD/YYYY: ");
            DateTime transferDate;
            if(DateTime.TryParse(Console.ReadLine(), out transferDate))
            {
                blood.BloodTransferDate = transferDate;

            }
            else
            {
                Console.WriteLine("Enter valid Date: ");
            }

            Console.WriteLine("Enter the amount of blood donated(in ml)");
            blood.BloodAmount = Convert.ToInt32(Console.ReadLine());


            bank.Blood_Deposit_Record.Add(blood);
            DBHandler.UpdateBloodBank(bank, bank);

            DBHandler.UpdateBloodBank(bank, blood.BloodGroup, blood.BloodAmount, true);



        }

    }
}
