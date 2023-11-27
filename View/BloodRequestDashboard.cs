using BloodGuardian.Common;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Models;
using BloodGuardian.View.Interfaces;


namespace BloodGuardian.View
{
    public class BloodRequestDashboard : IHomeDashboard
    {

        private IRequest _requestController;

        public BloodRequestDashboard(IRequest requestController)
        {
            _requestController = requestController;
        }

        public void CreateBloodRequest()
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


            _requestController.AddBloodRequest(req);

        }



        public void ViewBloodRequests()
        {

            var requests = _requestController.GetBloodRequests();
            foreach (var request in requests)
            {
                Console.WriteLine(Message.SingleDashDesign);
                Console.WriteLine("Request Id: " + request.RequestId);
                Console.WriteLine("Requester Name: " + request.RequesterName);
                Console.WriteLine("Requester Phone No: " + request.RequesterPhone);
                Console.WriteLine("Requested Blood Type: " + request.BloodRequirementType);
                Console.WriteLine("Requester Address: " + request.Address);
                Console.WriteLine(Message.SingleDashDesign);

            }

        }




    }
}
