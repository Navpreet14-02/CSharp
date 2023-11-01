using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.Common;

namespace BloodGuardian.Controller
{
    internal class RequestController
    {
        public void AddRequest()
        {
            var newRequest = App.createRequest();
            DBHandler.Instance.AddRequest(newRequest);
        }


        public void ViewRequests()
        {

            var requests = DBHandler.Instance.GetRequests();
            foreach (var request in requests)
            {
                Console.WriteLine(Message.SingleDashDesign);
                Console.WriteLine(request.RequestId);
                Console.WriteLine("Requester Name: " + request.RequesterName);
                Console.WriteLine("Requester Phone No: " + request.RequesterPhone);
                Console.WriteLine("Requested Blood Type: " + request.BloodRequirementType);
                Console.WriteLine("Requester Address: " + request.Address);
                Console.WriteLine(Message.SingleDashDesign);

            }

        }

        public void RemoveRequest(Donor d)
        {
            ViewRequests();

            int requestId;
            while (true)
            {
                Console.Write(Message.EnterRequestId);
                string input = Console.ReadLine();

                int res;
                if (input == String.Empty || !int.TryParse(input, out res))
                {
                    Console.WriteLine(Message.EnterValidInput);
                    continue;
                }

                requestId = Convert.ToInt32(input);
                Console.WriteLine(Message.SingleDashDesign);
                break;


            }

            var request = DBHandler.Instance.GetRequests().ElementAtOrDefault(requestId);

            if (request == null)
            {
                Console.WriteLine(Message.WrongRequestId);
            }
            else
            {
                DBHandler.Instance.DeleteRequest(request);
            }
        }
    }
}
