using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;

namespace BloodGuardian.Controller
{

    public class RequestController : IRequest, IRemoveRequest
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

        public void AdminRemoveRequest(Request request)
        {

            _requestDBHandler.Delete(request);

        }
    }
}
