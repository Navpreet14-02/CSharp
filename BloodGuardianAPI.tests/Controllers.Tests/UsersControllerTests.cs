using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Controllers;
using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardianAPI.tests.Controllers.Tests
{

    [TestClass]
    public class UsersControllerTests
    {

        public Mock<IUsersBusiness> _mockUserBusiness=new Mock<IUsersBusiness> ();

        private UsersController usersController;


        public static List<UserDetails> usersList = new List<UserDetails>()
        {
            new UserDetails()
            {

                IdentityUserId= "abcd",
                Name= "Param",
                Age= 22,
                Phone_Number= "4734435746",
                Email= "Param14@gmail.com",
                State= "Punjab",
                Address= "Mohali, Punjab",
                City= "Mohali",
                BloodId= 1,

            }
        };


        [TestInitialize]
        public void InitializeUsers()
        {
            usersController=new UsersController(_mockUserBusiness.Object);
        }


        [TestMethod]
        public void Get_Returns200Ok()
        {
            _mockUserBusiness.Setup(usersBus=>usersBus.GetAllUsers()).Returns(usersList);

            var response = usersController.Get() as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);
        }

        [TestMethod]
        public void Patch_InputIdAndUpdatedUser_Returns404NotFound()
        {
            _mockUserBusiness
                .Setup(usersBus => usersBus.UpdateUserProfile(It.IsAny<int>(),It.IsAny<JsonPatchDocument<UserDetails>>()))
                .Returns(false);
            int userId = 1;
            var operation = new Operation<UserDetails>("replace","/Name","","Parambeer");
            var updatedUser = new JsonPatchDocument<UserDetails>
                (
                    new List<Operation<UserDetails>>() { operation },
                    new DefaultContractResolver()
                );

        
  
            var response = usersController.Patch(userId, updatedUser) as NotFoundObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status404NotFound, response.StatusCode);
                

        }

        [TestMethod]
        public void Patch_InputIdAndUpdatedUser_Returns200Ok()
        {
            _mockUserBusiness
                .Setup(usersBus => usersBus.UpdateUserProfile(It.IsAny<int>(), It.IsAny<JsonPatchDocument<UserDetails>>()))
                .Returns(true);
            int userId = 1;
            var operation = new Operation<UserDetails>("replace", "/Name", "", "Parambeer");
            var updatedUser = new JsonPatchDocument<UserDetails>
                (
                    new List<Operation<UserDetails>>() { operation },
                    new DefaultContractResolver()
                );



            var response = usersController.Patch(userId, updatedUser) as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, response.StatusCode);


        }

        [TestMethod]
        public async Task Delete_InputUserId_Returns404NotFound()
        {
            _mockUserBusiness.Setup(usersBus => usersBus.RemoveAUser(It.IsAny<int>())).Returns(Task.FromResult(false));
            int userId = 1;

            var response = await usersController.Delete(userId);
            var res = response as NotFoundObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status404NotFound, res.StatusCode);
        }



        [TestMethod]
        public async Task Delete_InputUserId_Returns200Ok()
        {
            _mockUserBusiness.Setup(usersBus => usersBus.RemoveAUser(It.IsAny<int>())).Returns(Task.FromResult(true));
            int userId = 1;

            var response = await usersController.Delete(userId);
            var res = response as OkObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status200OK, res.StatusCode);
        }


        [TestMethod]
        public async Task GetDonationHistory_InputUserId_Returns404NotFound()
        {
            _mockUserBusiness
                .Setup(usersBus => usersBus.GetUserBloodDonationHistory(It.IsAny<int>()))
                .Returns
                (
                    Task.FromResult<List<BloodDonationHistoryDTO>>(null)
                );
            int userId = 1;



            var response = await usersController.GetDonationHistory(userId);
            var res = response as NotFoundObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status404NotFound, res.StatusCode);


        }

        [TestMethod]
        public async Task GetDonationHistory_InputUserId_Returns200Ok()
        {
            _mockUserBusiness
                .Setup(usersBus => usersBus.GetUserBloodDonationHistory(It.IsAny<int>()))
                .Returns
                (
                    Task.FromResult(new List<BloodDonationHistoryDTO>())
                );
            int userId = 1;



            var response = await usersController.GetDonationHistory(userId);
            var res = response as OkObjectResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(StatusCodes.Status200OK, res.StatusCode);


        }


    }

}
