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

        public enum HomePageOptions
        {
            Login=1,
            Register=2,
            SeeBloodRequests=3,
            AddBloodRequest=4,
            SearchBlood=5,
            Exit=6,
        }

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
            var input = Enum.Parse<HomePageOptions>(Console.ReadLine());

            Donor d;

            switch (input)
            {

                case HomePageOptions.Login:
            
                    d = AuthHandler.Login(Database);
                    if (d.Role == roles.Admin)
                    {
                        AdminUI.AdminMenu(Database,d);
                    }
                    else if (d.Role == roles.BloodBankManager)
                    {
                        BloodBankManagerUI.BloodBankManagerMenu(Database,d);
                    }
                    else
                    {
                        DonorUI.DonorMenu(Database,d);
                    }
                    break;

                case HomePageOptions.Register:
            
                    d = AuthHandler.Register(Database);
                    if (d.Role == roles.Admin)
                    {
                        AdminUI.AdminMenu(Database, d);
                    }
                    else if (d.Role == roles.BloodBankManager)
                    {
                        BloodBankManagerUI.BloodBankManagerMenu(Database, d);
                    }
                    else
                    {
                        DonorUI.DonorMenu(Database, d);
                    }
                    break;

                case HomePageOptions.SeeBloodRequests:
                    Request.ViewRequests();
                    Start(Database);
                    break;

                case HomePageOptions.AddBloodRequest:
                    Request newRequest = Request.createRequest();
                    Database.AddRequest(newRequest);
                    Start(Database);
                    break;

                case HomePageOptions.SearchBlood:
                    Search.SearchBlood(Database);
                    Start(Database);
                    break;

                case HomePageOptions.Exit:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Choose Valid Option");
                    Start(Database);
                    break;
            }
        }

   


    }
}
