using BloodGuardianAPI.Business;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloodGuardianAPI.tests.Business.Tests
{
    [TestClass]
    public class BloodRequestsBusinessTests
    {

        public Mock<IBloodRequestsData> _mockRequestsData = new Mock<IBloodRequestsData> ();


        private BloodRequestsBusiness _requestBusiness;

        [TestInitialize]
        public void InitializeBusiness()
        {
            _requestBusiness = new BloodRequestsBusiness(_mockRequestsData.Object);
        }

        [TestMethod]
        public void GetBloodRequests_ReturnsRequestsList()
        {

            _mockRequestsData
                .Setup(reqData => reqData.GetAllBloodRequests())
                .Returns(MockData.Requests.AsQueryable);


            var list = _requestBusiness.GetBloodRequests();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 2);

        }

        [TestMethod]
        public void AddBloodRequests_InputRequest_ReturnsFalse()
        {

            _mockRequestsData
                .Setup(reqData => reqData.GetAllBloodRequests())
                .Returns(MockData.Requests.AsQueryable);
            var request = new BloodRequest()
            {
                RequesterName = "Kishan",
                BloodRequirementType = 6,
                RequesterPhone = "2843752384",
                Address = "Patiala,Punjab"
            };
            var expected = false;
            
            
            var actual = _requestBusiness.AddBloodRequest(request);

            //Assert.IsNotNull(list);
            Assert.AreEqual(expected,actual);

        }

        [TestMethod]
        public void AddBloodRequests_InputRequest_ReturnsTrue()
        {

            _mockRequestsData
                .Setup(reqData => reqData.AddBloodRequest(It.IsAny<BloodRequest>()));
            var request = new BloodRequest()
            {
                RequesterName = "Rohan",
                BloodRequirementType = 6,
                RequesterPhone = "2843752384",
                Address = "Patiala,Punjab"
            };
            var expected = true;


            var actual = _requestBusiness.AddBloodRequest(request);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RemoveBloodRequest_InputRequestId_ReturnsFalse()
        {

            _mockRequestsData
                .Setup(reqData => reqData.GetAllBloodRequests())
                .Returns(MockData.Requests.AsQueryable);
            var requestId = 3;
            var expected = false;


            var actual = _requestBusiness.RemoveBloodRequest(requestId);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RemoveBloodRequest_InputRequestId_ReturnsTrue()
        {

            _mockRequestsData
                .Setup(reqData => reqData.RemoveBloodRequest(It.IsAny<BloodRequest>()));
            _mockRequestsData
                .Setup(reqData => reqData.GetAllBloodRequests())
                .Returns(MockData.Requests.AsQueryable);
            var requestId = 1;
            var expected = true;


            var actual = _requestBusiness.RemoveBloodRequest(requestId);

            Assert.AreEqual(expected, actual);

        }


    }
}
