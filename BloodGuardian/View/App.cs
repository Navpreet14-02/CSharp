using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Models;


namespace BloodGuardian.View
{
    public class App
    {

        public static void Start()
        {

            IRequest requestController = new RequestController();
            IAuth authHandler = new AuthHandler();

            Console.WriteLine();
            Console.WriteLine(Message.DoubleDashDesign);

            Console.WriteLine(Message.PrintHomePageOptions);

            Console.WriteLine(Message.DoubleDashDesign);
            Console.WriteLine();



            HomePageOptions option;

            Console.WriteLine(Message.SingleDashDesign);
            Console.Write(Message.EnterInput);
            string input = Console.ReadLine();

            HomePageOptions result;
            if (input == string.Empty || !Enum.TryParse<HomePageOptions>(input, out result))
            {
                Console.WriteLine(Message.EnterValidOption);
                Start();
            }

            option = Enum.Parse<HomePageOptions>(input);


            switch (option)
            {

                case HomePageOptions.Login:
                    authHandler.Login();
                    break;

                case HomePageOptions.Register:
                    authHandler.Register();
                    break;

                case HomePageOptions.SeeBloodRequests:
                    requestController.ViewBloodRequests();
                    Start();
                    break;

                case HomePageOptions.AddBloodRequest:
                    requestController.AddBloodRequest();
                    Start();
                    break;

                case HomePageOptions.SearchBlood:
                    ISearch search = new Search();
                    search.SearchBlood();
                    Start();
                    break;

                case HomePageOptions.Exit:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine(Message.EnterValidOption);
                    Start();
                    break;
            }
        }

        public static Request InputBloodRequestDetails()
        {
            Request req = new Request();

            Console.WriteLine(Message.EnterName);
            req.RequesterName = InputHandler.InputName(false);

            Console.WriteLine(Message.EnterPhone);
            req.RequesterPhone = InputHandler.InputPhone(false);

            Console.WriteLine(Message.EnterRequiredBloodType);
            req.BloodRequirementType = InputHandler.InputBloodGroup(false);


            Console.WriteLine(Message.EnterAddress);
            req.Address = InputHandler.InputAddress(false);

            return req;

        }



    }
}
