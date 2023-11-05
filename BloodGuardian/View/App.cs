﻿using BloodGuardian.Common;
using BloodGuardian.Controller;
using BloodGuardian.Models;

namespace BloodGuardian.View
{
    public class App
    {

        public static void Start()
        {

            RequestController requestController = new RequestController();
            AuthHandler authHandler = new AuthHandler();
            Search search = new Search();

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
            if (input == string.Empty || !Enum.TryParse<HomePageOptions>(input, out result)){
                Console.WriteLine(Message.EnterValidOption);
                Start();
            }

            option = Enum.Parse<HomePageOptions>(input);
            


            Donor d;

            switch (option)
            {

                case HomePageOptions.Login:
                    authHandler.Login();
                    break;

                case HomePageOptions.Register:
                    authHandler.Register();
                    break;

                case HomePageOptions.SeeBloodRequests:
                    requestController.ViewRequests();
                    Start();
                    break;

                case HomePageOptions.AddBloodRequest:
                    requestController.AddRequest();
                    Start();
                    break;

                case HomePageOptions.SearchBlood:
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

        public static Request createRequest()
        {
            Request req = new Request();

            while (true)
            {

                Console.Write(Message.EnterName);
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

                req.RequesterName = name;
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            while (true)
            {
                Console.Write(Message.EnterPhone);
                string phone = Console.ReadLine();
                try
                {
                    Validation.ValidatePhone(phone);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


                req.RequesterPhone = Convert.ToInt64(phone);
                Console.WriteLine(Message.SingleDashDesign);
                break;

            }

            while (true)
            {

                Console.Write(Message.EnterRequiredBloodType);
                string bloodgrp = Console.ReadLine();

                try
                {
                    Validation.ValidateBloodGroup(bloodgrp);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                req.BloodRequirementType = bloodgrp;
                Console.WriteLine(Message.SingleDashDesign);

                break;

            }

            while (true)
            {

                Console.Write(Message.EnterAddress);

                string address = Console.ReadLine();

                try
                {
                    Validation.ValidateAddress(address);

                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                req.Address = address;
                Console.WriteLine(Message.SingleDashDesign);

                break;
            }

            return req;

        }



    }
}
