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

            Console.WriteLine("Enter your Name: ");
            req.RequesterName = Console.ReadLine();

            Console.WriteLine("Enter your Phone Number: ");
            req.RequesterPhone =Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter the Required Blood Type");
            req.BloodRequirementType = Console.ReadLine();

            Console.WriteLine("Enter your Address");
            req.Address = Console.ReadLine();

            

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
            }

        }


    }
}
