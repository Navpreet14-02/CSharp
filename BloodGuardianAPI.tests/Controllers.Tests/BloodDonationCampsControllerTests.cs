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
        public void GetCampDetails_InputCampId_Returns200Ok()
        {

            _mockCampBusiness.Setup(campBus => campBus.GetBloodDonationCampsByBankId(It.IsAny<int>())).Returns(campsList);
            var bankid = 2;
            
            
            
            var campController = new BloodDonationCampsController(_mockCampBusiness.Object);
            var response = campController.Get(bankid) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);



        }


    }
}
