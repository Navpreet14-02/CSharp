using BloodGuardian.Database;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Models
{
    internal class Request
    {

        public int RequestId { get; set; }
        public string RequesterName { get; set; }

        public long RequesterPhone { get; set; }
        public string BloodRequirementType { get; set; }   
        public string Address { get; set; }


        public static Request createRequest()
        {
            Request req = new Request();

            while (true)
            {

                Console.Write("Enter your Name: ");
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

                req.RequesterName= name;
                Console.WriteLine("--------------------------------");
                break;

            }

            while (true)
            {
                Console.Write("Enter your Phone Number: ");
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


                req.RequesterPhone= Convert.ToInt64(phone);
                Console.WriteLine("--------------------------------");
                break;

            }

            while (true)
            {

                Console.Write("Enter the Required Blood Type: ");
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
                req.BloodRequirementType= bloodgrp;
                Console.WriteLine("--------------------------------");

                break;

            }

            while (true)
            {

                Console.Write("Enter your Address: ");

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
                Console.WriteLine("--------------------------------");

                break;

            }

            return req;

        }


        public static void ViewRequests()
        {

            var requests = DBHandler.GetRequests();
            foreach (var request in requests)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(request.RequestId);
                Console.WriteLine("Requester Name: " + request.RequesterName);
                Console.WriteLine("Requester Phone No: " + request.RequesterPhone);
                Console.WriteLine("Requested Blood Type: " + request.BloodRequirementType);
                Console.WriteLine("Requester Address: " + request.Address);
                Console.WriteLine("--------------------------------------");

            }

        }

        public static void RemoveRequest(DBHandler db,Donor d)
        {
            ViewRequests();

            int requestId;
            while (true)
            {
                Console.Write("Enter the Id of the Request you want to remove: ");
                string input = Console.ReadLine();

                int res;
                if (input == String.Empty || !int.TryParse(input, out res))
                {
                    Console.WriteLine("Enter Valid Input.");
                    continue;
                }

                requestId = Convert.ToInt32(input);
                Console.WriteLine("-----------------------------");
                break;


            }

            var request = DBHandler.GetRequests().ElementAtOrDefault(requestId);

            if(request == null)
            {
                Console.WriteLine("The request with thid id does not exist");
            }
            else
            {
                db.DeleteRequest(request);
            }
        }


    }
}
