using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.View;


namespace BloodGuardian.Controller
{

    internal class RequestController : IRequest, IRemoveRequest
    {


        private IRequestDBHandler requestDBHandler;

        public RequestController()
        {
            requestDBHandler = new RequestDBHandler();
        }
        public void AddBloodRequest()
        {
            var newRequest = App.InputBloodRequestDetails();
            requestDBHandler.Instance.Add(newRequest);
        }


        public void ViewBloodRequests()
        {

            var requests = requestDBHandler.Instance.Get();
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
            ViewBloodRequests();

            Console.Write(Message.EnterRequestId);
            int requestId = InputHandler.InputId();

            var request = requestDBHandler.Instance.Get().ElementAtOrDefault(requestId);

            if (request == null)
            {
                Console.WriteLine(Message.WrongRequestId);
            }
            else
            {
                requestDBHandler.Instance.Delete(request);
            }
        }
    }
}
