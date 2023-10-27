using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View
{
    internal class App
    {



        public static void Start(DBHandler Database)
        {

            Console.WriteLine("******************** BloodGuardian ***********************");
            Console.WriteLine("Enter the input as shown below:");
            Console.WriteLine("1:Login");
            Console.WriteLine("2:Register");
            Console.WriteLine("3:Blood Requests");
            Console.WriteLine("4:Add a Blood Request");
            Console.WriteLine("5:Search Blood");
            Console.WriteLine("6:Exit");


            Console.Write("Enter your Input:");
            var input = Console.ReadLine();

            if (input == "1")
            {
                Donor d = AuthHandler.Login(Database);
                if (d.Role == roles.Admin)
                {
                    AdminUI.AdminMenu(Database,d);
                }
                else if (d.Role == roles.BloodBankManager)
                {
                    BloodBankManagerMenu(Database,d);
                }
                else
                {
                    DonorUI.DonorMenu(Database,d);
                }
            }
            else if (input == "2")
            {
                Donor d = AuthHandler.Register(Database);
                if (d.Role == roles.Admin)
                {
                    AdminUI.AdminMenu(Database, d);
                }
                else if (d.Role == roles.BloodBankManager)
                {
                    BloodBankManagerMenu(Database, d);
                }
                else
                {
                    DonorUI.DonorMenu(Database, d);
                }

            }
            else if (input == "3")
            {
                Database.GetRequests();
            }
            else if(input == "4")
            {
                Request newRequest = Request.createRequest();
                Database.AddRequest(newRequest);
            }
            else if(input == "6")
            {
                Environment.Exit(0);
            }

        }


        public static void BloodBankManagerMenu(DBHandler Database, Donor d)
        {

            Donor currDonor = d;

            BloodBank bank = Database.FindBloodBank(currDonor);

            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile.");
            Console.WriteLine("2:Add Blood Deposit Record.");
            Console.WriteLine("3:Add Blood Withdraw Record.");
            Console.WriteLine("4:Organize Blood Donation Camps.");
            Console.WriteLine("5:See Blood Donation Camps.");
            Console.WriteLine("6:Remove Blood Donation Camps.");

            Console.Write("Enter your Input:");
            var input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    var oldDonor = d;
                    currDonor = Donor.UpdateProfile(Database,currDonor);
                    BloodBank.UpdateBloodBankDetails(Database,oldDonor,currDonor);
                    break;
                case 2:
                    BloodBank.UpdateDepositBloodRecord(Database,bank);
                    break;
                case 3:
                    BloodBank.UpdateWithdrawBloodRecord(Database, bank);
                    break;
                case 4:
                    BloodDonationCamp.OrganizeBloodDonationCamps(Database, bank,currDonor);
                    break;
                case 5:
                    BloodDonationCamp.GetBloodDonationCamps(Database, bank, currDonor);
                    break;
                case 6:
                    BloodDonationCamp.RemoveBloodDonationCamps(Database, bank, currDonor);
                    break;
            }

        }


        


    }
}
