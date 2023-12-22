using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Enums;
using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BloodGuardianAPI.Business
{
    public class AuthBusiness : IAuthBusiness
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUsersData _usersData;

        public AuthBusiness(UserManager<IdentityUser> userManager
                            , SignInManager<IdentityUser> signInManager
                            , IUsersData usersData)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usersData = usersData;
        }


        private async Task<bool> checkUserNameExists(string uname)
        {
            var user =await _userManager.FindByNameAsync(uname);

            return user != null;
        }

        


        public async Task<int> RegisterUser(RegisterUserModel user)
        {

            var identityUser = new IdentityUser { UserName = user.UserName, Email = user.Email };



            if (await checkUserNameExists(identityUser.UserName))
            {
                return 0;
            }

            var res = await _userManager.CreateAsync(identityUser, user.Password);


            if (!res.Succeeded)
            {
                var errMsg = "";
                foreach (var error in res.Errors)
                {
                    errMsg += error.Description.ToString() + "\n";
                }
                throw new Exception(errMsg);
            }



            var newUser = new UserDetails()
            {
                IdentityUserId = identityUser.Id,
                Email = user.Email,
                Name = user.Name,
                Phone_Number = user.Phone_Number,
                Age = user.Age,
                State = user.State,
                City = user.City,
                Address = user.Address,
                BloodId = _usersData.FindBloodIdByName(user.BloodGroup),
            };


            _usersData.AddUser(newUser);

            Roles role = (Roles)user.Role;
            var result = await _userManager.AddToRoleAsync(identityUser, role.ToString());
            

            if (!result.Succeeded)
            {
                var errMsg = "";
                foreach (var error in res.Errors)
                {
                    errMsg += error.Description.ToString() + "\n";
                }
                throw new Exception(errMsg);
            }



            bool isAdded = _userManager.Users.Contains(identityUser) &&
                  _usersData.GetUsers().Contains(newUser) &&
                  await _userManager.IsInRoleAsync(identityUser, role.ToString());

            return isAdded ? 1 : -1;

        }


        public async Task<bool> LoginUser(LoginUserModel user)
        {

            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false,false);


            if (!result.Succeeded)
            {
                return false;
            }

            
            var loginUser = await _userManager.FindByNameAsync(user.UserName);

            return true;

        }


        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();


        }
    }
}
