using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.View;
using BloodGuardian.View.Interfaces;

namespace BloodGuardian.Controller

{


    public class AuthController : IAuth
    {

        private IDonorDBHandler _donorDBHandler;
        //private IBloodBankDBHandler _bankDBHandler;
        //private IBloodBankManagerView _bankManagerView;


        public AuthController(IDonorDBHandler donorDBHandler)
        {
            _donorDBHandler =donorDBHandler;
            //_bankDBHandler = bankDBHandler;
            //_bankManagerView = bankManagerView;
        }


        public void Register(Donor newDonor)
        {

            _donorDBHandler.Add(newDonor);

            //BloodBank bank = _bankManagerView.InputBloodBankDetails(newDonor);
            //_bankDBHandler.Add(bank);




        }

        public void Login(string username,string password)
        {


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

        public bool CheckUserExists(string username)
        {
            return _donorDBHandler.FindDonorByUserName(username)!=null;
        }
    }
}
