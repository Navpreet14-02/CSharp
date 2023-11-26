using BloodGuardian.Common.Enums;
using BloodGuardian.Common;
using BloodGuardian.Controller;
using BloodGuardian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.View.Interfaces;

namespace BloodGuardian.View
{
    public class AuthDashboard : IAuthDashboard
    {

        public IAuth _authController;
        public IBloodBankManagerDashboard _bankManagerView;

        public AuthDashboard(IAuth authController,IBloodBankManagerDashboard bankManagerView)
        {
            _authController = authController;
            _bankManagerView = bankManagerView;
        }

        public void Login()
        {
            Console.WriteLine(Message.EnterUserName);
            string username = InputHandler.InputUserName(false);

            Console.WriteLine(Message.EnterPassword);
            string password = InputHandler.InputPassword(false);

            _authController.Login(username, password);
        }


        public void Register()
        {


            Donor newDonor = new Donor();


            Console.WriteLine(Message.EnterName);
            newDonor.Name = InputHandler.InputName(false);

            string uname;
            Console.WriteLine(Message.EnterUserName);
            while (true)
            {
                uname = InputHandler.InputUserName(false);

                if (_authController.CheckUserExists(uname))
                {
                    Console.WriteLine(Message.EnterDifferentUserName);
                    continue;
                }

                break;

            }
            newDonor.UserName = uname;


            Console.WriteLine(Message.EnterAge);
            newDonor.Age = InputHandler.InputAge(false);


            Console.WriteLine(Message.EnterPhone);
            newDonor.Phone = InputHandler.InputPhone(false);


            Console.WriteLine(Message.EnterEmail);
            newDonor.Email = InputHandler.InputEmail(false);


            Console.WriteLine(Message.EnterRole);
            newDonor.Role = Enum.Parse<Roles>(InputHandler.InputRole(false));


            Console.WriteLine(Message.EnterState);
            newDonor.State = InputHandler.InputState(false);


            Console.WriteLine(Message.EnterCity);
            newDonor.City = InputHandler.InputCity(false);



            Console.WriteLine(Message.EnterAddress);
            newDonor.Address = InputHandler.InputAddress(false);


            Console.WriteLine(Message.EnterPassword);
            newDonor.Password = InputHandler.InputPassword(false);


            Console.WriteLine(Message.EnterBloodGroup);
            newDonor.BloodGrp = InputHandler.InputBloodGroup(false);

            _authController.Register(newDonor);

            if (newDonor.Role == Roles.BloodBankManager)
            {
                _bankManagerView.CreateBloodBank(newDonor);
            }

            Console.WriteLine(Message.UserRegistered);
            Console.WriteLine();
            UI.Start();

        }
    }
}
