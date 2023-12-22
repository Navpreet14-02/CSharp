using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BloodGuardianAPI.Business
{
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IUsersData _usersData;
        private readonly IBloodBanksData _banksData;

        private readonly IBloodTransferReceiptsData _receiptsData;

        private readonly UserManager<IdentityUser> _userManager;


        public UsersBusiness(IUsersData usersData, UserManager<IdentityUser> userManager)
        {
            _usersData = usersData;
            _userManager = userManager;
        }

        public IEnumerable<UserDetails> GetAllUsers()
        {

            var users = _usersData.GetUsers();
            return users;

        }

        public async Task<bool> RemoveAUser(int userId)
        {


            var user = _usersData.GetUser(userId);
            if (user == null) return false;

            var identityUserId=user.IdentityUserId;
            var identityUser = await _userManager.FindByIdAsync(identityUserId);
            //var identityUserRole = await _userManager.GetRolesAsync(identityUser);

            var userDeleted = await _userManager.DeleteAsync(identityUser);

            if (!userDeleted.Succeeded)
            {

                var errMsg = "";
                foreach (var error in userDeleted.Errors)
                {
                    errMsg += error.Description.ToString() + "\n";
                }
                throw new Exception(errMsg);
                

            }


            _usersData.RemoveUser(user);

            return true;

           

        }


        public async Task<List<BloodDonationHistoryDTO>> GetUserBloodDonationHistory(int userId)
        {


            var currUser = _usersData.GetUser(userId);
            if (currUser == null) return null;
            var user = await _userManager.FindByIdAsync(currUser.IdentityUserId);

            var receipts = _receiptsData.GetAllBloodTransferReceipts().Where(r => r.CustomerEmail == user.Email);

            List<BloodDonationHistoryDTO> donationhistory = null;

            foreach(var receipt in receipts)
            {
                var bankId = receipt.BankId;
                var bank = _banksData.GetAllBloodBanks().Find(bank=> bank.Id== bankId);

                var donationreciept = new BloodDonationHistoryDTO()
                {
                    BankAddress = bank.Address,
                    BankName = bank.BankName,
                    BloodAmntDonated = receipt.BloodAmount,
                };

                donationhistory.Add(donationreciept);
            }

            return donationhistory;
            

        }

        public bool UpdateUserProfile(int userId,JsonPatchDocument<UserDetails> updatedUser)
        {
            var user = _usersData.GetUsers().FirstOrDefault(u=>u.Id==userId);

            if (user == null) return false;

            _usersData.UpdateUser(userId, updatedUser);

            return true;
            
        }

    }
}
