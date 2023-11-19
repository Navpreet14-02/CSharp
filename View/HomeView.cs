using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.View.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Models;


namespace BloodGuardian.View
{
    public class HomeView : IHomeView
    {

        public Request InputBloodRequestDetails()
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

            return req;

        }



    }
}
