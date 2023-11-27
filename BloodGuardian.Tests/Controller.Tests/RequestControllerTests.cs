using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.Controller;
using Moq;

namespace BloodGuardian.Tests.Controller.Tests
{

    [TestClass]
    public class RequestControllerTests
    {
        Mock<IRequestDBHandler> mockRequestDB = new Mock<IRequestDBHandler>();


        [TestMethod]
        public void AddBloodRequest_InputRequest_UpdatesRequestList()
        {

            var newRequest = new Request()
            {
                RequestId = -1,
                RequesterName = "Prem",
                RequesterPhone = 2394085395,
                BloodRequirementType = "B-",
                Address = "Patiala,Punjab"
            }; 
            var expected = new Request()
            {
                RequestId = 3,
                RequesterName = "Prem",
                RequesterPhone = 2394085395,
                BloodRequirementType = "B-",
                Address = "Patiala,Punjab"
            };
            mockRequestDB.Setup((requestDB) => requestDB.Add(newRequest)).Callback(() =>
            {
                newRequest.RequestId = MockData._requestList.Count;
                MockData._requestList.Add(newRequest);
            });



            var requestController = new RequestController(mockRequestDB.Object);
            requestController.AddBloodRequest(newRequest);
            

            Assert.IsTrue(MockData._requestList.Count==4);
            Assert.AreEqual(expected, MockData._requestList[3]);



        }


        [TestMethod]
        public void GetBloodRequests_ReturnsRequestList()
        {
            mockRequestDB.Setup(requestDB=>requestDB.Get()).Returns(MockData._requestList);

            var requestController = new RequestController(mockRequestDB.Object);
            var list = requestController.GetBloodRequests();

            Assert.IsTrue(list.Count == 3 || list.Count == 4);
        }


        [TestMethod]
        public void RemoveRequest_InputRequest_UpdatesRequestList()
        {

            var request = new Request()
            {
                RequestId = 1,
                RequesterName = "Rohan",
                RequesterPhone = 3294853928,
                BloodRequirementType = "AB-",
                Address = "Patiala,Punjab"
            };
            mockRequestDB.Setup(requestDB => requestDB.Delete(request)).Callback(() =>
            {
                MockData._requestList.Remove(request);
                foreach (var (request, ind) in MockData._requestList.Select((val, i) => (val, i)))
                {
                    request.RequestId = ind;
                }
            });



            var requestController = new RequestController(mockRequestDB.Object);
            requestController.AdminRemoveRequest(request);


            Assert.IsTrue(MockData._requestList.Count == 2 || MockData._requestList.Count == 3);
            Assert.IsTrue(MockData._requestList[1].RequesterName == "Ravi");
        }

    }
}
