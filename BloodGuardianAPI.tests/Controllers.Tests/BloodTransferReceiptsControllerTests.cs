using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Controllers;
using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace BloodGuardianAPI.tests.Controllers.Tests
{

    [TestClass]
    public class BloodTransferReceiptsControllerTests
    {

        public Mock<IBloodTransferReceiptsBusiness> _mockReceiptsBusiness = new Mock<IBloodTransferReceiptsBusiness>();

        private static List<BloodTransferReceipt> _receiptList = new List<BloodTransferReceipt>()
        {
            new BloodTransferReceipt()
            {
                
                CustomerName= "Ravi2",
                BloodId= 2,
                CustomerEmail= "ravi214@gmail.com",
                CustomerPhone= "4569804456",
                BloodTransferDate= DateTime.Parse("12/19/2023"),
                BloodAmount= 100,
                Receipt_Type="Deposit"
                
            }
        };


        private BloodTransferReceiptsController receiptscontroller;

        [TestInitialize]
        public void InitializeController()
        {
            receiptscontroller = new BloodTransferReceiptsController(_mockReceiptsBusiness.Object);
        }

        [TestMethod]
        public void Get_InputTypeAndBankId_Returns200OK()
        {
            _mockReceiptsBusiness.Setup(recBus => recBus.GetBloodTransferReceipts(It.IsAny<int>(),It.IsAny<string>())).Returns(_receiptList);
            string type = "Deposit";
            int bankId = 2;

            var response = receiptscontroller.Get(bankId, type) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);



        }

        [TestMethod]
        public void Get_InputTypeAndBankId_Returns404NotFound()
        {
            _mockReceiptsBusiness.Setup(recBus => recBus.GetBloodTransferReceipts(It.IsAny<int>(), It.IsAny<string>())).Returns<BloodTransferReceipt>(null);
            string type = "Deposit";
            int bankId = 2;

            var response = receiptscontroller.Get(bankId, type) as NotFoundObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);



        }

        [TestMethod]
        public void Get_InputTypeAndBankId_Returns500InternalServerError()
        {
            _mockReceiptsBusiness.Setup(recBus => recBus.GetBloodTransferReceipts(It.IsAny<int>(), It.IsAny<string>())).Throws(new Exception());
            string type = "Deposit";
            int bankId = 2;

            var response = receiptscontroller.Get(bankId, type) as ObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);



        }


        [TestMethod]
        public void Post_InputCampAndBankId_Returns400BadRequest()
        {
            var receipt = new BloodTransferReceipt()
            {
                BloodId = 2,
                CustomerEmail = "ravi214@gmail.com",
                CustomerPhone = "4569804456",
                BloodTransferDate = DateTime.Parse("5/19/2024"),
                BloodAmount = 50,
                Receipt_Type = "Deposit"

            };
            int bankId = 2;

            receiptscontroller.ModelState.AddModelError("CustomerName","Name missing");
            var response = receiptscontroller.Post(bankId, receipt) as BadRequestObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status400BadRequest, response.StatusCode);



        }

        [TestMethod]
        public void Post_InputCampAndBankId_Returns404NotFound()
        {
            _mockReceiptsBusiness.Setup(recBus => recBus.AddBloodTransferReceipt(It.IsAny<BloodTransferReceipt>(), It.IsAny<int>())).Returns(-1);
            var receipt = new BloodTransferReceipt()
            {
                BloodId = 2,
                CustomerEmail = "ravi214@gmail.com",
                CustomerPhone = "4569804456",
                BloodTransferDate = DateTime.Parse("5/19/2024"),
                BloodAmount = 50,
                Receipt_Type = "Deposit"

            };
            int bankId = 2;


            var response = receiptscontroller.Post(bankId, receipt) as NotFoundObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);



        }

        [TestMethod]
        public void Post_InputCampAndBankId_Returns409Conflict()
        {
            _mockReceiptsBusiness.Setup(recBus => recBus.AddBloodTransferReceipt(It.IsAny<BloodTransferReceipt>(), It.IsAny<int>())).Returns(0);
            var receipt = new BloodTransferReceipt()
            {
                BloodId = 2,
                CustomerEmail = "ravi214@gmail.com",
                CustomerPhone = "4569804456",
                BloodTransferDate = DateTime.Parse("5/19/2024"),
                BloodAmount = 50,
                Receipt_Type = "Deposit"

            };
            int bankId = 2;


            var response = receiptscontroller.Post(bankId, receipt) as ConflictObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status409Conflict, response.StatusCode);

        }

        [TestMethod]
        public void Post_InputCampAndBankId_Returns500InternalServerError()
        {
            _mockReceiptsBusiness.Setup(recBus => recBus.AddBloodTransferReceipt(It.IsAny<BloodTransferReceipt>(), It.IsAny<int>())).Throws(new Exception());
            var receipt = new BloodTransferReceipt()
            {
                BloodId = 2,
                CustomerEmail = "ravi214@gmail.com",
                CustomerPhone = "4569804456",
                BloodTransferDate = DateTime.Parse("5/19/2024"),
                BloodAmount = 50,
                Receipt_Type = "Deposit"

            };
            int bankId = 2;


            var response = receiptscontroller.Post(bankId, receipt) as ObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);

        }

        [TestMethod]
        public void Post_InputCampAndBankId_Returns200Ok()
        {
            _mockReceiptsBusiness.Setup(recBus => recBus.AddBloodTransferReceipt(It.IsAny<BloodTransferReceipt>(), It.IsAny<int>())).Returns(1);
            var receipt = new BloodTransferReceipt()
            {
                BloodId = 2,
                CustomerEmail = "ravi214@gmail.com",
                CustomerPhone = "4569804456",
                BloodTransferDate = DateTime.Parse("5/19/2024"),
                BloodAmount = 50,
                Receipt_Type = "Deposit"

            };
            int bankId = 2;


            var response = receiptscontroller.Post(bankId, receipt) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);

        }

    }
}
