using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.View;



namespace BloodGuardian.Controller

{


    public class AuthController : IAuth
    {

        private IDonorDBHandler _donorDBHandler;
        private IBloodBankDBHandler _bankDBHandler;


        public AuthController(IDonorDBHandler donorDBHandler,IBloodBankDBHandler bankDBHandler)
        {
            _donorDBHandler =donorDBHandler;
            _bankDBHandler = bankDBHandler;
        }


        public void Register()
        {
            DonorView donorView = new DonorView();

            Donor newDonor = donorView.InputUserDetails();

            _donorDBHandler.Add(newDonor);


            if (newDonor.Role == Roles.BloodBankManager)
            {

                var bankUI = new BloodBankManagerView();
                var bloodbank = bankUI.InputBloodBankDetails(newDonor);
                _bankDBHandler.Add(bloodbank);
            }


            Console.WriteLine(Message.UserRegistered);
            Console.WriteLine();
            UI.Start();

        }

        public void Login()
        {



            Console.WriteLine(Message.EnterUserName);
            string username = InputHandler.InputUserName(false);

            Console.WriteLine(Message.EnterPassword);
            string password = InputHandler.InputPassword(false);



            var donor = _donorDBHandler.FindDonorByCredentials(username, password);

            if (donor != null)
            {
                Console.WriteLine(Message.UserLoggedIn);
                Console.WriteLine();
                if (donor.Role == Roles.Admin)
                {
                    UI.AdminUI(donor);
                }
                else if (donor.Role == Roles.BloodBankManager)
                {
                    UI.BloodBankManagerUI(donor);
                }
                else
                {
                    UI.DonorUI(donor);
                }
            }
            else
            {
                Console.WriteLine(Message.WrongLoginDetailsMessage);
                UI.Start();
            }



        }
    }
}
