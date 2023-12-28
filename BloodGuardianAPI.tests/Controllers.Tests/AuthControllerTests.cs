using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.Controllers;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardianAPI.tests.Controllers.Tests
{
    [TestClass]
    public class AuthControllerTests
    {

        public Mock<IAuthBusiness> _mockAuthBusiness = new Mock<IAuthBusiness>();

        private AuthController authController;

        [TestInitialize]
        public void InitializeController()
        {
            authController=new AuthController(_mockAuthBusiness.Object);    
        }

        [TestMethod]
        public async Task Login_InvalidLoginDetails_Returns400BadRequest()
        {

            //_mockAuthBusiness.Setup(authBus => authBus.LoginUser(It.IsAny<LoginUserModel>())).Returns(Task.FromResult(false));
            var loginDetails = new LoginUserModel()
            {
                UserName = "Param14",
                Password = "P@ram1402"
            };

            authController.ModelState.AddModelError("Username", "Missing Username");
            var response = await authController.Login(loginDetails);
            var res = response as BadRequestObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status400BadRequest, res.StatusCode);
        
        }

        [TestMethod]
        public async Task Login_InvalidLoginDetails_Returns500InternalServerError()
        {

            _mockAuthBusiness.Setup(authBus => authBus.LoginUser(It.IsAny<LoginUserModel>())).Throws(new Exception() );
            var loginDetails = new LoginUserModel()
            {
                UserName = "Param14",
                Password = "P@ram1402"
            };


            var response = await authController.Login(loginDetails);
            var res = response as ObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, res.StatusCode);

        }


        [TestMethod]
        public async Task Login_ValidLoginDetails_Returns400BadRequest()
        {

            _mockAuthBusiness.Setup(authBus => authBus.LoginUser(It.IsAny<LoginUserModel>())).Returns(Task.FromResult(false));
            var loginDetails = new LoginUserModel()
            {
                UserName = "Param14",
                Password = "P@ram1402"
            };


            var response = await authController.Login(loginDetails);
            var res = response as BadRequestObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status400BadRequest, res.StatusCode);

        }

        [TestMethod]
        public async Task Login_ValidLoginDetails_Returns200Ok()
        {

            _mockAuthBusiness.Setup(authBus => authBus.LoginUser(It.IsAny<LoginUserModel>())).Returns(Task.FromResult(true));
            var loginDetails = new LoginUserModel()
            {
                UserName = "Param14",
                Password = "P@ram1402"
            };


            var response = await authController.Login(loginDetails);
            var res = response as OkObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status200OK, res.StatusCode);

        }

        [TestMethod]
        public async Task Register_InvalidRegisterDetails_Returns400BadRequest()
        {

            //_mockAuthBusiness.Setup(authBus => authBus.LoginUser(It.IsAny<LoginUserModel>())).Returns(Task.FromResult(true));
            var registerDetails = new RegisterUserModel()
            {
                Name = "Param",
                Age = 22,
                Phone_Number = "4734435746",
                Email = "Param14@gmail.com",
                State = "Punjab",
                Address = "Mohali, Punjab",
                City = "Mohali",
                Password = "P@ram1402",
                BloodId = 1,
                Role = 2
            };

            authController.ModelState.AddModelError("UserName", "Missing User Name");
        var response = await authController.Register(registerDetails);
            var res = response as BadRequestObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status400BadRequest, res.StatusCode);

        }

        [TestMethod]
        public async Task Register_InvalidRole_Returns400BadRequest()
        {

            var registerDetails = new RegisterUserModel()
            {
                UserName="Param14",
                Name = "Param",
                Age = 22,
                Phone_Number = "4734435746",
                Email = "Param14@gmail.com",
                State = "Punjab",
                Address = "Mohali, Punjab",
                City = "Mohali",
                Password = "P@ram1402",
                BloodId = 1,
                Role = 3
            };


            var response = await authController.Register(registerDetails);
            var res = response as BadRequestObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status400BadRequest, res.StatusCode);

        }

        [TestMethod]
        public async Task Register_ValidRegisterDetails_Returns409Conflict()
        {

            _mockAuthBusiness.Setup(authBus => authBus.RegisterUser(It.IsAny<RegisterUserModel>())).Returns(Task.FromResult(false));
            var registerDetails = new RegisterUserModel()
            {
                UserName = "Param14",
                Name = "Param",
                Age = 22,
                Phone_Number = "4734435746",
                Email = "Param14@gmail.com",
                State = "Punjab",
                Address = "Mohali, Punjab",
                City = "Mohali",
                Password = "P@ram1402",
                BloodId = 1,
                Role = 2
            };


            var response = await authController.Register(registerDetails);
            var res = response as ConflictObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status409Conflict, res.StatusCode);

        }

        [TestMethod]
        public async Task Register_ValidRegisterDetails_Returns500InternalServerError()
        {

            _mockAuthBusiness.Setup(authBus => authBus.RegisterUser(It.IsAny<RegisterUserModel>())).Throws(new Exception());
            var registerDetails = new RegisterUserModel()
            {
                UserName = "Param14",
                Name = "Param",
                Age = 22,
                Phone_Number = "4734435746",
                Email = "Param14@gmail.com",
                State = "Punjab",
                Address = "Mohali, Punjab",
                City = "Mohali",
                Password = "P@ram1402",
                BloodId = 1,
                Role = 2
            };


            var response = await authController.Register(registerDetails);
            var res = response as ObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status500InternalServerError, res.StatusCode);

        }

        [TestMethod]
        public async Task Register_ValidRegisterDetails_Returns200Ok()
        {

            _mockAuthBusiness.Setup(authBus => authBus.RegisterUser(It.IsAny<RegisterUserModel>())).Returns(Task.FromResult(true));
            var registerDetails = new RegisterUserModel()
            {
                UserName = "Param14",
                Name = "Param",
                Age = 22,
                Phone_Number = "4734435746",
                Email = "Param14@gmail.com",
                State = "Punjab",
                Address = "Mohali, Punjab",
                City = "Mohali",
                Password = "P@ram1402",
                BloodId = 1,
                Role = 2
            };


            var response = await authController.Register(registerDetails);
            var res = response as OkObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status200OK, res.StatusCode);

        }

        [TestMethod]
        public async Task Logout_Returns200Ok()
        {

            _mockAuthBusiness.Setup(authBus => authBus.LogoutUser());

            var response = await authController.Logout();
            var res = response as OkObjectResult;

            Assert.IsNotNull(res);
            Assert.AreEqual(StatusCodes.Status200OK, res.StatusCode);

        }

    }
}
