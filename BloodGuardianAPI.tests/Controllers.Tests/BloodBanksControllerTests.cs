using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Controllers;
using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodGuardianAPI.tests.Controllers.Tests
{

    [TestClass]
    public class BloodBanksControllerTests
    {

        private List<BloodBank> _banksList;

        public Mock<IBloodBankBusiness> _mockBankBusiness = new Mock<IBloodBankBusiness>();


        //[TestInitialize]
        //public void InitializeBloodBanks()
        //{

        //    _banksList = new List<BloodBank>(){

        //}

        public static List<BloodBank> bloodBankList = new List<BloodBank>()
        {
            
            
            new BloodBank() {
                BankName = "dhawan-bloodbank",
                State = "Punjab",
                Address = "Patiala,Punjab",
                City = "Patiala",
                IdentityUserId = "Kuch Bhi",
            },
            new BloodBank() {
                BankName = "Varun-bloodbank",
                State = "Haryana",
                Address = "Panipat,Haryana",
                City = "Panipat",
                IdentityUserId = "Kuch Bhi",
            },

        };
    

        [TestMethod]
        public void GetBloodBankDetails_InputBloodBankId_Returns404NotFound()
        {

            int bankId = 1;
            _mockBankBusiness.Setup(bankBus => bankBus.GetBloodBankDetails(It.IsAny<int>())).Returns<BloodBank>(null);
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Get(bankId) as NotFoundObjectResult;

            ////Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);


        }


        [TestMethod]
        public void GetBloodBankDetails_InputBloodBankId_Returns200Ok()
        {

            int bankId = 0;
            _mockBankBusiness.Setup(bankBus => bankBus.GetBloodBankDetails(bankId)).Returns(bloodBankList[0]);
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Get(bankId) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }

        [TestMethod]
        public void GetBloodBanks_StateAndCityNull_Returns200Ok()
        {

            _mockBankBusiness.Setup(bankBus => bankBus.GetAllBloodBanks()).Returns(_banksList);
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Get(null,null,null) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }

        [TestMethod]
        public void GetBloodBanks_StateNull_Returns400BadRequest()
        {

            //_mockBankBusiness.Setup(bankBus => bankBus.GetBloodBankDetails()).Returns(_banksList);

            var bankController = new BloodBanksController(_mockBankBusiness.Object);
            string state = null;
            string city = "Patiala";


            var response = bankController.Get(state, city, null) as BadRequestObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status400BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void GetBloodBanks_StateAndCity_Returns200Ok()
        {

            var state = "Punjab";
            var city = "Patiala";
            _mockBankBusiness.Setup(bankBus => bankBus.SearchBloodBanks(state,city)).Returns(_banksList);
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Get(state, city, null) as OkObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }

        [TestMethod]
        public void GetBloodBanks_StateAndCityAndBloodType_Returns200Ok()
        {

            var state = "Punjab";
            var city = "Patiala";
            var bloodgrp = "A+";
            _mockBankBusiness.Setup(bankBus => bankBus.SearchBlood(state, city,bloodgrp)).Returns(_banksList);
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Get(state, city, null) as OkObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }

        [TestMethod]
        public void GetBloodBanks_StateAndCity_Returns500InternalServerError()
        {

            var state = "Punjab";
            var city = "Patiala";
            var bloodgrp = "A+";
            _mockBankBusiness.Setup(bankBus => bankBus.SearchBloodBanks(state, city)).Throws(new Exception());
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Get(state, city, null) as ObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);


        }

        [TestMethod]
        public void Post_InputBloodBank_Returns400BadRequest()
        {

            var bank = new RegisterBloodBankModel()
            {
                BankName = "dhawan-bloodbank",
                State = "Punjab",
                Address = "Patiala,Punjab",
                City = "Patiala",
            };

            _mockBankBusiness.Setup(bankBus => bankBus.AddBloodBank(It.IsAny<RegisterBloodBankModel>(),It.IsAny<string>())).Returns(true);
            var bankController = new BloodBanksController(_mockBankBusiness.Object);
            bankController.ModelState.AddModelError("BankName", "Enter Bank Name");


            var response = bankController.Post(bank) as BadRequestObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status400BadRequest, response.StatusCode);


        }

        [TestMethod]
        public void Post_InputBloodBank_Returns500InternalServerError()
        {

            var bank = new RegisterBloodBankModel()
            {
                BankName = "dhawan-bloodbank",
                State = "Punjab",
                Address = "Patiala,Punjab",
                City = "Patiala",
            };

            _mockBankBusiness.Setup(bankBus => bankBus.AddBloodBank(It.IsAny<RegisterBloodBankModel>(), It.IsAny<string>())).Throws(new Exception());
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Post(bank) as ObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);


        }


        [TestMethod]
        public void Post_InputBloodBank_Returns200Ok()
        {

            var bank = new RegisterBloodBankModel()
            {
                BankName = "dhawan-bloodbank",
                State = "Punjab",
                Address = "Patiala,Punjab",
                City = "Patiala",
            };

            _mockBankBusiness.Setup(bankBus => bankBus.AddBloodBank(It.IsAny<RegisterBloodBankModel>(), It.IsAny<string>())).Returns(true);
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Post(bank) as OkObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }


        [TestMethod]
        public void Delete_InputBloodId_Returns404NotFound()
        {

            int bankid = 1;

            _mockBankBusiness.Setup(bankBus => bankBus.RemoveBloodBank(It.IsAny<int>())).Returns(false);
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Delete(bankid) as NotFoundObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);


        }

        [TestMethod]
        public void Delete_InputBloodId_Returns200Ok()
        {

            int bankid = 1;

            _mockBankBusiness.Setup(bankBus => bankBus.RemoveBloodBank(It.IsAny<int>())).Returns(true);
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Delete(bankid) as OkObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }

        [TestMethod]
        public void Delete_InputBloodId_Returns500InternalServerError()
        {

            int bankid = 1;

            _mockBankBusiness.Setup(bankBus => bankBus.RemoveBloodBank(It.IsAny<int>())).Throws(new Exception());
            var bankController = new BloodBanksController(_mockBankBusiness.Object);


            var response = bankController.Delete(bankid) as ObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);


        }


    }
}

