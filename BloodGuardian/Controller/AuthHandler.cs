using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.Common;


namespace BloodGuardian.Controller

{
    public class AuthHandler
    {

        private BloodBankController _bankController;
        private DonorController _donorController;

        public AuthHandler()
        {
            _bankController = new BloodBankController();
            _donorController = new DonorController();
        }


        public void Register()
        {
            Donor newDonor = _donorController.AddDonor();


            if (newDonor.Role == roles.BloodBankManager)
            {
                _bankController.AddBloodBank(newDonor);
            }


            Console.WriteLine(Message.UserRegistered);
            Console.WriteLine();
            App.Start();


            //return newDonor;

        }

        public void Login()
        {



            Console.WriteLine(Message.EnterUserName);
            string username = InputHandler.InputUserName(false);

            Console.WriteLine(Message.EnterPassword);
            string password = InputHandler.InputPassword(false);



            var donor = _donorController.FindDonor(username, password);

            if (donor != null)
            {
                Console.WriteLine(Message.UserLoggedIn);
                Console.WriteLine();
                donor.LoggedIn = true;
                if (donor.Role == roles.Admin)
                {
                    AdminUI.AdminMenu(donor);
                }
                else if (donor.Role == roles.BloodBankManager)
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
