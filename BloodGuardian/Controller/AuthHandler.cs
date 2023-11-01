using BloodGuardian.Database;
using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.Common;


namespace BloodGuardian.Controller

{
    public class AuthHandler
    {

        BloodBankController bankController=new BloodBankController();
        DonorController donorController = new DonorController();


        public void Register()
        {
            Donor newDonor = DonorUI.CreateUser();

            DBHandler.Instance.AddDonor(newDonor);


            if (newDonor.Role == roles.BloodBankManager)
            {
                BloodBank bank = bankController.createBloodBank(newDonor);
                Console.WriteLine();

                DBHandler.Instance.AddBloodBank(bank);
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



            var donor = donorController.FindDonor(username, password);
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




            //return donor;

        }

        public void SignOut(Donor d)
        {
            d.LoggedIn = false;
        }
    }
}
