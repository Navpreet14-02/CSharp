using BloodGuardian.Database;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.View
{
    internal static class App
    {

        public static void Start()
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
                Donor d = AuthHandler.Login();
                if (d.Role == roles.Admin)
                {
                    //AdminMenu(d);
                }
                else if (d.Role == roles.BloodBankManager)
                {
                    BBManagerMenu(d);
                }
                else
                {
                    DonorMenu(d);
                }
            }
            else if (input == "2")
            {
                Donor d = AuthHandler.Register();
                if (d.Role == roles.Admin)
                {
                    //AdminMenu(d);
                }
                else if (d.Role == roles.BloodBankManager)
                {
                    BBManagerMenu(d);
                }
                else
                {
                    DonorMenu(d);
                }

            }
            else if (input == "3")
            {
                DBHandler.GetRequests();
            }
            else if(input == "4")
            {
                Request newRequest = Request.createRequest();
                DBHandler.AddRequest(newRequest);
            }
            else if(input == "6")
            {
                Environment.Exit(0);
            }

        }

        public static void DonorMenu(Donor d)
        {

            Donor currDonor = d;

            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile");
            Console.WriteLine("2:Search Blood Banks Near you.");
            Console.WriteLine("3:Search Blood Donation Camps Near You.");

            Console.Write("Enter your Input:");
            var input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    currDonor = Donor.UpdateProfile(currDonor);
                    break;
                case 2:
                    Search.SearchBloodBanks(currDonor);
                    break;
                case 3:
                    
                    break;
            }
            

        }


        public static void BBManagerMenu(Donor d)
        {

            Donor currDonor = d;
          

            Console.WriteLine("Enter input as shown below");
            Console.WriteLine("1:Update Profile.");
            Console.WriteLine("2:Update Quantity of Blood.");
            Console.WriteLine("3:Add Blood Deposit Record.");
            Console.WriteLine("4:Add Blood Withdraw Record.");
            Console.WriteLine("5:Organize Blood Donation Camps.");
            Console.WriteLine("6:See Blood Donation Camps.");
            Console.WriteLine("7:Remove Blood Donation Camps.");

            Console.Write("Enter your Input:");
            var input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    var oldDonor = d;
                    currDonor = Donor.UpdateProfile(currDonor);
                    BloodBank.UpdateBloodBankDetails(oldDonor,currDonor);
                    break;
                case 2:
                    BloodBank.UpdateBloodQuantity(currDonor);
                    break;
                case 3:
                    BloodBank.UpdateDepositBloodRecord(currDonor);
                    break;
            }

        }

    }
}
