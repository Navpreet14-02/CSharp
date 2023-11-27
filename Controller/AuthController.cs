using BloodGuardian.Common;
using BloodGuardian.Common.Enums;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.View;

namespace BloodGuardian.Controller

{


    public class AuthController : IAuth
    {

        private IDonorDBHandler _donorDBHandler;

        public AuthController(IDonorDBHandler donorDBHandler)
        {
            _donorDBHandler = donorDBHandler;
        }


        public void Register(Donor newDonor)
        {

            _donorDBHandler.Add(newDonor);

        }

        public Donor Login(string username, string password)
        {

            return _donorDBHandler.FindDonorByCredentials(username, password);


        }

        public bool CheckUserNameExists(string username)
        {
            return _donorDBHandler.FindDonorByUserName(username) != null;
        }
    }
}
