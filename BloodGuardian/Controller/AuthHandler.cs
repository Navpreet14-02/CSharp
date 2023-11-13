using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Models;
using BloodGuardian.View;



namespace BloodGuardian.Controller

{


    public class AuthHandler : IAuth
    {

        private IBloodBank _bankController;
        private IDonor _donorController;

        public AuthHandler()
        {
            _bankController = new BloodBankController();
            _donorController = new DonorController();
        }


        public void Register()
        {
            Donor newDonor = _donorController.AddDonor();


            if (newDonor.Role == Roles.BloodBankManager)
            {
                _bankController.AddBloodBank(newDonor);
            }


            Console.WriteLine(Message.UserRegistered);
            Console.WriteLine();
            App.Start();

        }

        public void Login()
        {



            Console.WriteLine(Message.EnterUserName);
            string username = InputHandler.InputUserName(false);

            Console.WriteLine(Message.EnterPassword);
            string password = InputHandler.InputPassword(false);



            var donor = _donorController.FindDonorByCredentials(username, password);

            if (donor != null)
            {
                Console.WriteLine(Message.UserLoggedIn);
                Console.WriteLine();
                if (donor.Role == Roles.Admin)
                {
                    AdminUI.AdminMenu(donor);
                }
                else if (donor.Role == Roles.BloodBankManager)
                {
                    BloodBankManagerUI.BloodBankManagerMenu(donor);
                }
                else
                {
                    DonorUI.DonorMenu(donor);
                }
            }
            else
            {
                Console.WriteLine(Message.WrongLoginDetailsMessage);
                App.Start();
            }



        }
    }
}
