using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Controllers;
using BloodGuardianAPI.Models;
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
    public class BloodDonationCampsControllerTests
    {

        public Mock<IBloodDonationCampBusiness> _mockCampBusiness=new Mock<IBloodDonationCampBusiness>();

        private static List<BloodDonationCamp> campsList = new List<BloodDonationCamp>()
        {
            new BloodDonationCamp()
            {

                Camp_Date=DateTime.Parse("12/25/2023"),
                Camp_City="Patiala",
                Camp_State="Punjab",
                Camp_Address="Patiala,Punjab",
                Start_Time=DateTime.Parse("6:00"),
                End_Time=DateTime.Parse("20:00"),

            },
            new BloodDonationCamp()
            {

                Camp_Date=DateTime.Parse("12/20/2023"),
                Camp_City="Patiala",
                Camp_State="Punjab",
                Camp_Address="Patiala,Punjab",
                Start_Time=DateTime.Parse("6:00"),
                End_Time=DateTime.Parse("18:00"),

            }
        };


        [TestMethod]
        public void GetCampsByBank_InputCampId_Returns200Ok()
        {

            _mockCampBusiness.Setup(campBus => campBus.GetBloodDonationCampsByBankId(It.IsAny<int>())).Returns(campsList);
            var bankid = 2;
            
            
            
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            var response = campController.Get(bankid) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }



        [TestMethod]
        public void GetCampsByBank_InputCampId_Returns404NotFound()
        {

            _mockCampBusiness.Setup(campBus => campBus.GetBloodDonationCampsByBankId(It.IsAny<int>())).Returns<BloodDonationCamp>(null);
            var bankid = 2;
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);



            var response = campController.Get(bankid) as NotFoundObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);



        }

        [TestMethod]
        public void GetCamps_StateAndCityNull_Returns200OK()
        {

            _mockCampBusiness.Setup(campBus => campBus.GetAllBloodDonationCamps()).Returns(campsList);
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            string state = null;
            string city = null;


            var response = campController.Get(state,city) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK,response.StatusCode);


        }

        [TestMethod]
        public void GetCamps_StateAndCityNull_Returns500InternalServerError()
        {

            _mockCampBusiness.Setup(campBus => campBus.GetAllBloodDonationCamps()).Throws(new Exception());
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            string state = null;
            string city = null;


            var response = campController.Get(state, city) as ObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);


        }

        [TestMethod]
        public void GetCamps_StateNull_Returns200OK()
        {

            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            string state = null;
            string city = "Patiala";


            var response = campController.Get(state, city) as BadRequestObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status400BadRequest, response.StatusCode);


        }

        [TestMethod]
        public void GetCamps_InputStateAndCity_Returns200OK()
        {
            _mockCampBusiness.Setup(campBus => campBus.SearchBloodDonationCamps(It.IsAny<string>(), It.IsAny<string>())).Returns(campsList);
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            string state = "Punjab";
            string city = "Patiala";


            var response = campController.Get(state, city) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }

        [TestMethod]
        public void Post_InputBankIdAndDonationCamp_Returns400BadRequest()
        {
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            int bankid = 1;
            var camp = new BloodDonationCamp()
            {
                Camp_City = "Patiala",
                Camp_State = "Punjab",
                Camp_Address = "Patiala,Punjab",
                Start_Time = DateTime.Parse("6:00"),
                End_Time = DateTime.Parse("20:00"),

            };


            campController.ModelState.AddModelError("Camp_Date", "Missing Camp_Date");
            var response = campController.Post(bankid,camp) as BadRequestObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status400BadRequest, response.StatusCode);


        }





        [TestMethod]
        public void Post_InputBankIdAndDonationCamp_Returns409Conflict()
        {
            _mockCampBusiness.Setup(campBus => campBus.AddBloodDonationCamp(It.IsAny<int>(), It.IsAny<BloodDonationCamp>())).Returns(false);
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            int bankid = 1;
            var camp = new BloodDonationCamp()
            {
                Camp_City = "Patiala",
                Camp_State = "Punjab",
                Camp_Address = "Patiala,Punjab",
                Start_Time = DateTime.Parse("6:00"),
                End_Time = DateTime.Parse("20:00"),

            };

            var response = campController.Post(bankid, camp) as ConflictObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status409Conflict, response.StatusCode);


        }


        [TestMethod]
        public void Post_InputBankIdAndDonationCamp_Returns500InternalServerError()
        {
            _mockCampBusiness.Setup(campBus => campBus.AddBloodDonationCamp(It.IsAny<int>(), It.IsAny<BloodDonationCamp>())).Throws(new Exception());
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            int bankid = 1;
            var camp = new BloodDonationCamp()
            {
                Camp_City = "Patiala",
                Camp_State = "Punjab",
                Camp_Address = "Patiala,Punjab",
                Start_Time = DateTime.Parse("6:00"),
                End_Time = DateTime.Parse("20:00"),

            };

            var response = campController.Post(bankid, camp) as ObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);


        }

        [TestMethod]
        public void Post_InputBankIdAndDonationCamp_Returns200Ok()
        {
            _mockCampBusiness.Setup(campBus => campBus.AddBloodDonationCamp(It.IsAny<int>(), It.IsAny<BloodDonationCamp>())).Returns(true);
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            int bankid = 1;
            var camp = new BloodDonationCamp()
            {
                Camp_City = "Patiala",
                Camp_State = "Punjab",
                Camp_Address = "Patiala,Punjab",
                Start_Time = DateTime.Parse("6:00"),
                End_Time = DateTime.Parse("20:00"),

            };

            var response = campController.Post(bankid, camp) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }

        [TestMethod]
        public void Delete_InputCampId_Returns404NotFound()
        {
            _mockCampBusiness.Setup(campBus => campBus.RemoveBloodDonationCamp(It.IsAny<int>())).Returns(false);
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            int campid = 1;

            var response = campController.Delete(campid) as NotFoundObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);


        }

        [TestMethod]
        public void Delete_InputCampId_Returns500InternalServerError()
        {
            _mockCampBusiness.Setup(campBus => campBus.RemoveBloodDonationCamp(It.IsAny<int>())).Throws(new Exception());
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            int campid = 1;

            var response = campController.Delete(campid) as ObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, response.StatusCode);


        }

        [TestMethod]
        public void Delete_InputCampId_Returns200Ok()
        {
            _mockCampBusiness.Setup(campBus => campBus.RemoveBloodDonationCamp(It.IsAny<int>())).Returns(true);
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            int campid = 1;

            var response = campController.Delete(campid) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }

    }
}
