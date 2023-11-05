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
            RequestDBHandler.Instance.Add(newRequest);
        }


        public void ViewRequests()
        {

            var requests = RequestDBHandler.Instance.Read();
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

        public void AdminRemoveRequest(Donor d)
        {
            ViewRequests();

            Console.Write(Message.EnterRequestId);
            int requestId=InputHandler.InputId();

            var request = RequestDBHandler.Instance.Read().ElementAtOrDefault(requestId);

            if (request == null)
            {
                Console.WriteLine(Message.WrongRequestId);
            }
            else
            {
                RequestDBHandler.Instance.Delete(request);
            }
        }
    }
}
