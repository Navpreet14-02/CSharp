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
      

        public RequestController(IDB<Request> requestDBHandler)
        {
            _requestDBHandler = requestDBHandler;
        }
        public void AddBloodRequest(Request newRequest)
        {
            _requestDBHandler.Add(newRequest);
        }

        public List<Request> GetBloodRequests()
        {
            return _requestDBHandler.Get();
        }

        //public void ViewBloodRequests()
        //{

        //    var requests = _requestDBHandler.Get();
        //    foreach (var request in requests)
        //    {
        //        Console.WriteLine(Message.SingleDashDesign);
        //        Console.WriteLine(request.RequestId);
        //        Console.WriteLine("Requester Name: " + request.RequesterName);
        //        Console.WriteLine("Requester Phone No: " + request.RequesterPhone);
        //        Console.WriteLine("Requested Blood Type: " + request.BloodRequirementType);
        //        Console.WriteLine("Requester Address: " + request.Address);
        //        Console.WriteLine(Message.SingleDashDesign);

        //    }

        //}

        public void AdminRemoveRequest(Request request)
        {
            
            _requestDBHandler.Delete(request);
            
        }
    }
}
