using BloodGuardianAPI.Business;
using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Enums;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace BloodGuardianAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter Valid Details");
            }

            bool isUserLoggedIn;
            try
            {
                isUserLoggedIn = await _authBusiness.LoginUser(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (!isUserLoggedIn)
            {
                return BadRequest("Invalid Login Attempt");
            }

            return Ok("User Logged In");
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterUserModel user)
        {

            if(!ModelState.IsValid || (user.Role!=1 && user.Role!=2))
            {
                return BadRequest("Enter Valid Details");
            }

            int isUserAdded=-1;
            try
            {
                isUserAdded = await _authBusiness.RegisterUser(user);
            }
            catch(Exception ex)
            {

                Ok(ex);
                //return StatusCode(StatusCodes.Status500InternalServerError);

            }

            if (isUserAdded==-1)
            {
                return StatusCode(StatusCodes.Status409Conflict);

            }

            if (isUserAdded == 0)
            {

                StatusCode(500, "Invalid Register Attempt");
            }

            return Ok("User Registered");
        }


        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authBusiness.LogoutUser();
            return Ok("User Logged Out Successfully");
        }
    }
}
