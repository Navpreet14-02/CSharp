using BloodGuardianAPI.Business;
using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BloodGuardianAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersBusiness _usersBusiness;

        public UsersController(IUsersBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UserDetails> users;
            try
            {

                users = _usersBusiness.GetAllUsers();
            }
            catch (Exception ex)
            {

                return Ok(ex);

            }

            return Ok(users);

        }

        [HttpPatch("{id}/profile/update")]
        [Authorize]
        public IActionResult Patch(int id, JsonPatchDocument<UserDetails> updateUser)
        {
            bool isUserUpdated;
            try
            {

                isUserUpdated = _usersBusiness.UpdateUserProfile(id, updateUser);
            }
            catch (Exception ex)
            {

                return Ok(ex);

            }

            if (!isUserUpdated)
            {
                return NotFound("User with this id does not exist");
            }

            return Ok("Profile Updated");

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isUserDeleted;
            try
            {
                isUserDeleted = await _usersBusiness.RemoveAUser(id);
            }
            catch (Exception ex)
            {

                return Ok(ex);

            }

            if (!isUserDeleted)
            {
                return NotFound("User with this id does not exist");
            }

            return Ok("User deleted Successfully");

        }

        [HttpGet("{id}/donationhistory")]
        public async Task<IActionResult> GetDonationHistory(int id)
        {

            List<BloodDonationHistoryDTO> donationHistory;
            try
            {
                donationHistory = await _usersBusiness.GetUserBloodDonationHistory(id);


            }
            catch (Exception ex)
            {

                return Ok(ex);

            }

            if (donationHistory == null)
            {
                return NotFound("User with this id does not exist.");
            }

            return Ok(donationHistory);

        }

    }
}
