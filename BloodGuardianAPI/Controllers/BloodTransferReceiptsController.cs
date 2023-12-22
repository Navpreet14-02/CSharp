using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BloodGuardianAPI.Controllers
{
    [Route("api/bloodbanks/{bankid}/[controller]")]
    [ApiController]
    public class BloodTransferReceiptsController : ControllerBase
    {


        private readonly IBloodTransferReceiptsBusiness _recieptsBusiness;

        public BloodTransferReceiptsController(IBloodTransferReceiptsBusiness recieptsBusiness)
        {
            _recieptsBusiness = recieptsBusiness;
        }

        [HttpGet]
        public IActionResult Get(string type)
        {

            var receipts = _recieptsBusiness.GetBloodTransferReceipts(type);
            return Ok(receipts);

        }

        [HttpPost]
        public IActionResult Post(int bankid, [FromBody] BloodTransferReceipt reciept)
        {

            bool isReceiptAdded;
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter Valid Details");
            }

            try
            {
                isReceiptAdded = _recieptsBusiness.AddBloodTransferReceipt(reciept, bankid);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }


            if (!isReceiptAdded)
            {
                return Conflict("This reciept already exists");
            }

            return Ok("Receipt Added");

        }

    }
}
