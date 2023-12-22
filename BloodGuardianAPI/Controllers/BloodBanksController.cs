using BloodGuardianAPI.Business;
using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Data;
using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BloodGuardianAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "BloodBankManager")]
    public class BloodBanksController : ControllerBase
    {

        private readonly IBloodBankBusiness _bloodBankBusiness;

        public BloodBanksController(IBloodBankBusiness bloodBankBusiness)
        {
            _bloodBankBusiness = bloodBankBusiness;
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,BloodBankManager")]
        public IActionResult Get(int id)
        {
            var bank = _bloodBankBusiness.GetBloodBankDetails(id);

            if (bank == null)
            {
                return NotFound("Bank with this id does not exist");
            }

            return Ok(bank);
        }


        [HttpGet]
        [Authorize(Roles = "Admin,BloodBankManager")]
        public IActionResult Get(string state, string city, string bloodType)
        {


            IEnumerable<BloodBank> bloodbanks;

            try
            {

                if(state==null && city == null)
                {
                    bloodbanks = _bloodBankBusiness.GetAllBloodBanks();

                }
                else if (state == null || city == null)
                {
                    return BadRequest("Enter state and city.");
                }
                else if (bloodType == null)
                {
                    bloodbanks = _bloodBankBusiness.SearchBloodBanks(state, city);

                }
                else
                {
                    bloodbanks = _bloodBankBusiness.SearchBlood(state, city, bloodType);
                }

            }
            catch(Exception ex)
            {
                return Ok(ex);
            }

            return Ok(bloodbanks);
        }




        [HttpPost]
        [Authorize(Roles = "BloodBankManager")]
        public IActionResult Post([FromBody] RegisterBloodBankModel inputBank)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isBankAdded;
            try
            {
                var uname = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                isBankAdded = _bloodBankBusiness.AddBloodBank(inputBank, uname);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }



            return Ok();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,BloodBankManager")]
        public IActionResult Delete(int id)
        {

            bool isBankDeleted;

            try
            {
                isBankDeleted = _bloodBankBusiness.RemoveBloodBank(id);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            if (!isBankDeleted)
            {
                return NotFound("Bloodbank with this id does not exist");
            }

            return Ok("Bloodbank successfully deleted.");
        }


        //[HttpGet]
        //public IActionResult Search(string state,string city, string bloodGrp)
        //{

        //} 



    }
}
