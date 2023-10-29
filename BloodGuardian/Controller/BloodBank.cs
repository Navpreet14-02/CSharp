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
        public static BloodBank createBloodBank(Donor d)
        {

            BloodBank bank = new BloodBank();



            while (true)
            {

                Console.Write("Enter your Name of your BloodBank: ");
                string name = Console.ReadLine();
                try
                {
                    Validation.ValidateName(name);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                bank.BankName = name;
                Console.WriteLine("--------------------------------");
                break;

            }

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


                while (true)
                {
                    Console.Write(grp+": ");    
                    string amnt = Console.ReadLine();

                    if (amnt != String.Empty)
                    { 

                        try
                        {
                            Validation.ValidateBloodAmount(amnt);
                        }
                        catch (InvalidDataException e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                    }

                    bank.BloodUnits[grp] = amnt == "" ? 0 : Convert.ToInt32(amnt);
                    break;

                }

            }


            return bank;

        }

        public static void UpdateBloodBankDetails(DBHandler Database,Donor oldDonor,Donor newDonor)
        {
            var bank = Database.FindBloodBank(oldDonor, -1);

            var newBank = new BloodBank();
            while (true)
            {

                Console.Write("Enter your Name of your BloodBank: ");
                string name = Console.ReadLine();
                if (name != String.Empty)
                {
                    try
                    {
                        Validation.ValidateName(name);

                    }
                    catch (InvalidDataException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                newBank.BankName = name==String.Empty?bank.BankName:name;
                Console.WriteLine("--------------------------------");
                break;

            }

            newBank.ManagerEmail = newDonor.Email;
            newBank.ManagerName= newDonor.Name;
            newBank.Address = newDonor.Address;
            newBank.State=newDonor.State;
            newBank.City = newDonor.City;
            newBank.Contact=newDonor.Phone;



            Database.UpdateBloodBank(bank, newBank);
            
        }

        public static void ViewBloodBanks(DBHandler db,Donor d)
        {
            db.ReadBloodBanks().ForEach(bank =>
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Id: "+bank.BankId);
                Console.WriteLine("Bank Name: "+bank.BankName);
                Console.WriteLine("Manager Name: "+bank.ManagerName);
                Console.WriteLine("Manager Email: "+ bank.ManagerEmail);
                Console.WriteLine("Manager Contact" + bank.Contact);
                Console.WriteLine("Address: "+bank.Address);
            });

        }


        public static void RemoveBloodBank(DBHandler db,Donor d) 
        {
            ViewBloodBanks(db, d);

            Console.WriteLine("==================================");

            int bankid;
            while (true)
            {
                Console.Write("Enter the Id of the Blood Bank you want to remove: ");
                string input = Console.ReadLine();

                int res;
                if(input == String.Empty ||!int.TryParse(input, out res)) 
                {
                    Console.WriteLine("Enter Valid Input.");
                    continue;
                }

                bankid = Convert.ToInt32(input);
                Console.WriteLine("-----------------------------");
                break;

            }



            var bank = db.FindBloodBank(null, bankid);

            if (bank == null)
            {
                Console.WriteLine("The bank with this id does not exist");
            }
            else
            {

                var donor = DBHandler.ReadDonors().Find((dn) => dn.Email == bank.ManagerEmail);
                db.DeleteBloodBank(donor, bankid);
            }


        }

        public static void UpdateDepositBloodRecord(DBHandler Database,BloodBank bank)
        {

            BloodTransferReceipt blood = BloodBankManagerUI.CreateBloodDepositRecord();


            bank.Blood_Deposit_Record.Add(blood);
            Database.UpdateBloodBank(bank, bank);

            Database.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, true);



        }


        public static void UpdateWithdrawBloodRecord(DBHandler Database, BloodBank bank)
        {


            BloodTransferReceipt blood = BloodBankManagerUI.CreateBloodWithdrawRecord();

            

            bank.Blood_WithDrawal_Record.Add(blood);
            Database.UpdateBloodBank(bank, bank);

            Database.UpdateBloodTransferRecord(bank, blood.BloodGroup, blood.BloodAmount, false);




        }


    }
}
