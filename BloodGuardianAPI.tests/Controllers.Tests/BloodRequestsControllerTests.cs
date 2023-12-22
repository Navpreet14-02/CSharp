using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Controllers;
using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloodGuardianAPI.tests.Controllers.Tests
{
    [TestClass]
    public class BloodRequestsControllerTests
    {

        private static List<BloodRequest> _requests;
        public Mock<IBloodRequestsBusiness> _mockRequestBusiness = new Mock<IBloodRequestsBusiness>();


        [TestInitialize]
        public void InitializeRequests()
        {
            _requests = new List<BloodRequest>()
            {
                new BloodRequest()
                {
                    RequesterName= "Kishan",
                    BloodRequirementType= 6,
                    RequesterPhone= "2843752384",
                    Address= "Patiala,Punjab"
                },
                new BloodRequest()
                {
                    RequesterName= "Ravi",
                    BloodRequirementType= 4,
                    RequesterPhone= "2843752384",
                    Address= "Noida,Uttar Pradesh"
                }
            };
        }



        [TestMethod]
        public void Get_Returns200Ok()
        {
            _mockRequestBusiness.Setup(reqBus => reqBus.GetBloodRequests()).Returns(_requests);

            var bloodRequestController = new BloodRequestsController(_mockRequestBusiness.Object);

            var response = bloodRequestController.Get() as OkObjectResult;    

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);

        }

        [TestMethod]
        public void Post_InputBloodRequest_Returns400BadRequest()
        {
            var bloodRequest = new BloodRequest()
            { 
                BloodRequirementType = 2,
                RequesterPhone = "2843752384",
                Address = "Noida,Uttar Pradesh"
            };

            var bloodRequestController = new BloodRequestsController(_mockRequestBusiness.Object);
            bloodRequestController.ModelState.AddModelError("RequesterName", "Enter Requester Name");


            var response = bloodRequestController.Post(bloodRequest) as BadRequestObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status400BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Post_InputBloodRequest_Returns409Conflict()
        {

            _mockRequestBusiness.Setup(reqBus => reqBus.AddBloodRequest(It.IsAny<BloodRequest>())).Returns(false);
            var bloodRequest = new BloodRequest()
            {
                RequesterName = "Kishan",
                BloodRequirementType = 2,
                RequesterPhone = "2843752384",
                Address = "Noida,Uttar Pradesh"
            };
            var bloodRequestController = new BloodRequestsController(_mockRequestBusiness.Object);


            var response = bloodRequestController.Post(bloodRequest) as ConflictObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status409Conflict, response.StatusCode);

        }

        [TestMethod]
        public void Post_InputBloodRequest_Returns201Created()
        {

            _mockRequestBusiness.Setup(reqBus => reqBus.AddBloodRequest(It.IsAny<BloodRequest>())).Returns(true);
            var bloodRequest = new BloodRequest()
            {
                RequesterName = "Kishan",
                BloodRequirementType = 2,
                RequesterPhone = "2843752384",
                Address = "Noida,Uttar Pradesh"
            };
            var bloodRequestController = new BloodRequestsController(_mockRequestBusiness.Object);


            var response = bloodRequestController.Post(bloodRequest) as StatusCodeResult ;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status201Created, response.StatusCode);

        }

        [TestMethod]
        public void Delete_InputBloodRequestId_Returns404NotFound()
        {

            _mockRequestBusiness.Setup(reqBus => reqBus.RemoveBloodRequest(It.IsAny<int>())).Returns(false);
            int requestId = 1;
            var bloodRequestController = new BloodRequestsController(_mockRequestBusiness.Object);


            var response = bloodRequestController.Delete(requestId) as NotFoundObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);

        }

        [TestMethod]
        public void Delete_InputBloodRequestId_Returns200Ok()
        {

            _mockRequestBusiness.Setup(reqBus => reqBus.RemoveBloodRequest(It.IsAny<int>())).Returns(true);
            int requestId = 1;
            var bloodRequestController = new BloodRequestsController(_mockRequestBusiness.Object);


            var response = bloodRequestController.Delete(requestId) as OkObjectResult;


            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);

        }
    }
}
