using BloodGuardianAPI.Business;
using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.CompilerServices;

namespace BloodGuardianAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestsController : ControllerBase
    {

        private IBloodRequestsBusiness _requestBusiness;
        public BloodRequestsController(IBloodRequestsBusiness requestBusiness)
        {

            _requestBusiness = requestBusiness;

        }

        [HttpGet]
        public IActionResult Get()
        {

            var requests = _requestBusiness.GetBloodRequests();

            return Ok(requests);

        }

        [HttpPost]
        public IActionResult Post([FromBody] BloodRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("The data entered is not Valid");
            }

            bool isReqAdded;

            try
            {

                isReqAdded = _requestBusiness.AddBloodRequest(request);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            if (!isReqAdded)
            {
                return Conflict("This request already exists.");

            }

            return StatusCode(StatusCodes.Status201Created);
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {


            bool isReqDeleted;

            try
            {
                isReqDeleted = _requestBusiness.RemoveBloodRequest(id);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);

            }


            if (!isReqDeleted)
            {
                return NotFound("Request with this id does not exist.");
            }



            return Ok("The request has been deleted");

        }

    }
}
