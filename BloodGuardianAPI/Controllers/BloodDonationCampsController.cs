using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BloodGuardianAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BloodDonationCampsController : ControllerBase
    {

        private readonly IBloodDonationCampBusiness _campBusiness;

        public BloodDonationCampsController(IBloodDonationCampBusiness campBusiness)
        {
            _campBusiness = campBusiness;
        }


        [HttpGet("bloodbanks/{bankid}/[controller]")]
        public IActionResult Get(int bankId)
        {

            var camps = _campBusiness.GetBloodDonationCampsByBankId(bankId);

            if (camps == null)
            {
                return NotFound("No Blood Bank Exists with this id.");
            }

            return Ok(camps);
        }


        //[HttpGet("bloodbanks/{bankid}/[controller]/{id}")]
        //public IActionResult GetCampDetails(int id)
        //{
        //    var camp = _campBusiness.GetBloodDonationCampDetails(id);
        //    return Ok(camp);
        //}


        [HttpGet("[controller]")]
        public IActionResult Get(string state,string city)
        {

            IEnumerable<BloodDonationCamp> camps;

            try
            {


                if (state == null && city == null)
                {

                    camps = _campBusiness.GetAllBloodDonationCamps();
                }
                else if(state==null || city == null)
                {
                    return BadRequest("Enter State and City");
                }
                else
                {
                    camps = _campBusiness.SearchBloodDonationCamps(state, city);
                }
            }
            catch(Exception ex)
            {
                return Ok(ex);
                //return StatusCode(StatusCodes.Status404NotFound);
            }


            return Ok(camps);
        }



        [HttpPost("bloodbanks/{bankid}/[controller]")]
        public IActionResult Post(int bankid, [FromBody] BloodDonationCamp camp)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Enter Correct Details.");
            }

            try
            {
                _campBusiness.AddBloodDonationCamp(bankid, camp);
            }
            catch (Exception ex)
            {
                return Ok(ex);
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok("Blood Donation Camp Added.");
        }


        [HttpDelete("[controller]/{id}")]
        public IActionResult Delete(int campId)
        {

            bool isDeleted;
            try
            {
                isDeleted = _campBusiness.RemoveBloodDonationCamp(campId);
            }
            catch (Exception ex)
            {
                return Ok(ex);
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (!isDeleted)
            {
                return NotFound("The camp with this Id does not exist.");
            }

            return Ok("Blood Donation Camp Deleted.");
        }




    }
}
