using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace BloodGuardianAPI.Business
{
    public class BloodBankBusiness : IBloodBankBusiness
    {

        private readonly IBloodBanksData _banksData;
        private readonly IUsersData _usersData;



        public BloodBankBusiness(IBloodBanksData banksData)
        {
            _banksData = banksData;
        }

        public IEnumerable<BloodBank> GetAllBloodBanks()
        {

            return _banksData.GetAllBloodBanks();

        }

        public BloodBank GetBloodBankDetails(int id)
        {
            return _banksData.GetAllBloodBanks().Find(bb=>bb.Id==id);

            
        }



        public bool AddBloodBank(RegisterBloodBankModel inputBank,string uname)
        {
            var bank = new BloodBank()
            {
                BankName = inputBank.BankName,
                State = inputBank.State,
                City = inputBank.City,
                Address = inputBank.Address,
                IdentityUserId = _usersData.GetUsers().FirstOrDefault(u => u.IdentityUser.UserName == uname).IdentityUserId,
            };

            var addedBank = _banksData.AddBloodBank(bank);
            int bankId = int.Parse(addedBank.Member("Id").CurrentValue.ToString());

            foreach(var (key,item) in inputBank.BloodUnits)
            {


                var bankBloodMapping = new BankBloodGroupMapping()
                {
                    BankId = bankId,
                    BloodId=int.Parse(key),
                    BloodAmount=item,
                    
                };

                _banksData.AddBankBloodGroupMapping(bankBloodMapping);
            }

            return true;
                  
        }




        public bool RemoveBloodBank(int bankId)
        {
            var bank = _banksData.GetAllBloodBanks().ToList().Find(bank=> bank.Id == bankId);

            if (bank == null)
            {
                return false;
            }

            _banksData.RemoveBloodBank(bank);
            return true;


            
        }


        public IEnumerable<BloodBank> SearchBlood(string state,string city, string BloodType)
        {
            return _banksData.GetAllBloodBanks().Where(bank=>bank.State==state && bank.City==city);

        }

        public IEnumerable<BloodBank> SearchBloodBanks(string state, string city)
        {
            return _banksData.GetAllBloodBanks().Where(bank => bank.State == state && bank.City == city);

        }


    }
}
