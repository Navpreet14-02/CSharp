using BloodGuardian.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodGuardian.View;
using System.Threading.Channels;

namespace BloodGuardian.Models
{
    internal enum roles
    {
        Admin,
        Donor,
        BloodBankManager,
    }

    internal class Donor
    {
        public static List<string> BloodGroups =new List<string>{ "A+", "A-","B+","B-","O+","O-","AB+","AB-" };

        public int Donorid { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string BloodGrp{ get; set; }
        public roles Role { get; set; }

        public bool LoggedIn { get; set; } 




        public static Donor UpdateProfile(DBHandler Database, Donor d)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Below are your old details:");
            Console.WriteLine("Name: "+d.Name);
            Console.WriteLine("Age: " + d.Age);
            Console.WriteLine("Phone: " + d.Phone);
            Console.WriteLine("Email: " + d.Email);
            Console.WriteLine("State: "+d.State);
            Console.WriteLine("City: " + d.City);
            Console.WriteLine("Address: "+d.Address);
            Console.WriteLine("Password: "+d.Password);
            if(d.Role==roles.BloodBankManager) Console.WriteLine("Blood Bank Name: "+Database.FindBloodBank(d,-1).BankName);


            Console.WriteLine("==============================");
            Console.WriteLine("Enter your new Details: ");

            Donor updatedDonor = DonorUI.UpdatedUserInfo(d);



            Database.UpdateDonor(d, updatedDonor);

            if (updatedDonor.Role == roles.Admin)
            {
                //App.AdminMenu(d);
            }
            else if (updatedDonor.Role == roles.BloodBankManager)
            {
                //App.BBManagerMenu(d);
            }
            else
            {
                //App.DonorMenu(d);
            }

            return updatedDonor;

        }

        public static void ViewDonors(DBHandler db,Donor d)
        {
            DBHandler.ReadDonors().ForEach(donor => {

                Console.WriteLine("---------------------------");
                Console.WriteLine("id: "+donor.Donorid);
                Console.WriteLine("Name: "+donor.Name);
                Console.WriteLine("Age: " + donor.Age);
                Console.WriteLine("Phone: "+ donor.Phone);
                Console.WriteLine("Email: "+donor.Email);
                Console.WriteLine("Address: "+donor.Address);
                Console.WriteLine("Blood Group: "+donor.BloodGrp);
                Console.WriteLine("Role: "+donor.Role.ToString());
                Console.WriteLine("---------------------------");

            }
            );

           
        }

        public static Donor FindDonor(string email, string password)
        {

            var donorList = DBHandler.ReadDonors();
            Donor d = null;
            if (password == null)
            {
                d = donorList.Find((donor) => donor.Email == email);

            }
            else
            {
                d = donorList.Find((donor) => donor.Email == email && donor.Password == password);

            }

            return d;
        }

        public static void RemoveDonor(DBHandler db, Donor d)
        {

            ViewDonors(db,d);

            Console.WriteLine();

            int donorId;
            while (true)
            {
                Console.Write("Enter the Id of the Donor you want to remove: ");
                string input = Console.ReadLine();

                int res;
                if (input == String.Empty || !int.TryParse(input, out res))
                {
                    Console.WriteLine("Enter Valid Input.");
                    continue;
                }

                donorId = Convert.ToInt32(input);
                Console.WriteLine("-----------------------------");
                break;

            }

            var donor=DBHandler.ReadDonors().ElementAtOrDefault(donorId);

            if(donor== null)
            {
                Console.WriteLine("The donor with this id does not exist.");
            }
            else
            {

                db.DeleteDonor(donorId);
                if (d.Role == roles.BloodBankManager)
                {
                    BloodBank bank = db.FindBloodBank(d,-1);
                    db.DeleteBloodBank(null, bank.BankId);
                }
            }



        }

        public static void ViewBloodDonationHistory(DBHandler database,Donor d)
        {
            var BankdepositLists= new Dictionary<BloodBank, List<BloodTransferReceipt>>();
            database.ReadBloodBanks().ForEach(bank =>
            {
                BankdepositLists.Add(bank, bank.Blood_Deposit_Record);
            });


            var isFound = false;

            foreach (KeyValuePair<BloodBank, List<BloodTransferReceipt>> entry in BankdepositLists)
            {
                // do something with entry.Value or entry.Key

                entry.Value.ForEach((receipt) =>
                {
                    if(receipt.CustomerEmail==d.Email && receipt.CustomerPhone == d.Phone)
                    {
                        isFound = true;

                        Console.WriteLine();
                        Console.WriteLine("---------------------");
                        Console.WriteLine($"Bank Name: {entry.Key.BankName}");
                        Console.WriteLine($"Address: {entry.Key.Address}");
                        Console.WriteLine($"Date: {receipt.BloodTransferDate}");
                        Console.WriteLine("---------------------");


                    }
                });


                //Console.WriteLine($"":);
                
            }

            if(!isFound)
            {
                Console.WriteLine("You have not donated blood anywhere yet.");
            }


        }

        public static void AddAdmin(DBHandler database,Donor d) 
        {

            Donor newAdmin = AdminUI.InputAdmin(database,d);

            newAdmin.Role = roles.Admin;

            database.AddDonor(newAdmin);
            

        }

        public static void SignOut(Donor d)
        {
            d.LoggedIn = false;
        }


    }
}
