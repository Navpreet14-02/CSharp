using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.View.Interfaces;

namespace BloodGuardian.Controller
{

    internal class RequestController : IRequest, IRemoveRequest
    {


        private IDB<Request> _requestDBHandler;
        private IHomeView _homeView;
       

        public RequestController(IDB<Request> requestDBHandler,IHomeView homeView)
        {
            _requestDBHandler = requestDBHandler;
            _homeView = homeView;
        }
        public void AddBloodRequest()
        {
            
            var newRequest = _homeView.InputBloodRequestDetails();
            _requestDBHandler.Add(newRequest);
        }


        public void ViewBloodRequests()
        {

            var requests = _requestDBHandler.Get();
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

            var request = _requestDBHandler.Get().ElementAtOrDefault(requestId);

            if (request == null)
            {
                Console.WriteLine(Message.WrongRequestId);
            }
            else
            {
                _requestDBHandler.Delete(request);
            }
        }
    }
}
