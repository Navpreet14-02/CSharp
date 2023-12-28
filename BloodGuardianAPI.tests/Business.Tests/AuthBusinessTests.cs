using BloodGuardianAPI.Business;
using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardianAPI.tests.Business.Tests
{
    [TestClass]
    public class AuthBusinessTests
    {


        public Mock<UserManager<IdentityUser>> _mockUserManager;
        public Mock<SignInManager<IdentityUser>> _mockSignInManager;
        public Mock<IUsersData> _mockUsersData;

        private IAuthBusiness _authBusiness;

        [TestInitialize]
        public void InitializeDependencies()
        {

            _mockUserManager = new Mock<UserManager<IdentityUser>>(
                    new Mock<IUserStore<IdentityUser>>().Object,
                    new Mock<IOptions<IdentityOptions>>().Object,
                    new Mock<IPasswordHasher<IdentityUser>>().Object,
                    new IUserValidator<IdentityUser>[0],
                    new IPasswordValidator<IdentityUser>[0],
                    new Mock<ILookupNormalizer>().Object,
                    new Mock<IdentityErrorDescriber>().Object,
                    new Mock<IServiceProvider>().Object,
                    new Mock<ILogger<UserManager<IdentityUser>>>().Object
                );

            _mockSignInManager = new Mock<SignInManager<IdentityUser>>(
                _mockUserManager.Object,
                 new Mock<IHttpContextAccessor>().Object,
                 new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                 new Mock<IOptions<IdentityOptions>>().Object,
                 new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
                 new Mock<IAuthenticationSchemeProvider>().Object,
                 new Mock<IUserConfirmation<IdentityUser>>().Object);

            _mockUsersData = new Mock<IUsersData>();

            _authBusiness = new AuthBusiness
                (
                    _mockUserManager.Object
                    , _mockSignInManager.Object
                    , _mockUsersData.Object
                );

        }


        [TestMethod]
        public async Task RegisterUser_InputUserRegisterDetails_ReturnsFalse()
        {

            _mockUserManager
                .Setup(userMan => userMan.FindByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(MockData.IdentityUsers.ElementAt(0)));
            var user = new RegisterUserModel()
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
                BloodId = 2,
                Role = 2
            };


            var res = await _authBusiness.RegisterUser(user);

            Assert.IsFalse(res);


        }

        [TestMethod]
        public async Task RegisterUser_InputUserRegisterDetails_CreateUserFails_ThrowsException()
        {

            _mockUserManager
                .Setup(userMan => userMan.FindByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<IdentityUser>(null));

            _mockUserManager
                .Setup(userMan => userMan.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Failed(new IdentityError())));
            var user = new RegisterUserModel()
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
                BloodId = 2,
                Role = 2
            };
            var expected = true;


            var actual = false;
            try
            {
                var res = await _authBusiness.RegisterUser(user);

            }
            catch(Exception ex)
            {
                actual = true;
            }

            Assert.AreEqual(expected,actual);


        }

        [TestMethod]
        public async Task RegisterUser_InputUserRegisterDetails_AddToRoleFails_ThrowsException()
        {

            _mockUserManager
                .Setup(userMan => userMan.FindByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<IdentityUser>(null));

            _mockUserManager
                .Setup(userMan => userMan.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            _mockUserManager
                .Setup(userMan => userMan.AddToRoleAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Failed(new IdentityError())));
            var user = new RegisterUserModel()
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
                BloodId = 2,
                Role = 2
            };
            var expected = true;


            var actual = false;
            try
            {
                var res = await _authBusiness.RegisterUser(user);

            }
            catch (Exception ex)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public async Task RegisterUser_InputUserRegisterDetails_ReturnsTrue()
        {

            _mockUserManager
                .Setup(userMan => userMan.FindByNameAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<IdentityUser>(null));

            _mockUserManager
                .Setup(userMan => userMan.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            _mockUserManager
                .Setup(userMan => userMan.AddToRoleAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));
            var user = new RegisterUserModel()
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
                BloodId = 2,
                Role = 2
            };
  


            var res = await _authBusiness.RegisterUser(user);

          

            Assert.IsTrue(res);


        }


        [TestMethod]
        public async Task LoginUser_InputLoginDetails_ReturnsFalse()
        {
            _mockSignInManager
                .Setup(signInMan => signInMan.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(SignInResult.Failed));
            var user = new LoginUserModel()
            {
                UserName = "Param14",
                Password = "P@ram1402"
            };

            var res = await _authBusiness.LoginUser(user);

            Assert.IsFalse(res);


        }

        [TestMethod]
        public async Task LoginUser_InputLoginDetails_ReturnsTrue()
        {
            _mockSignInManager
                .Setup(signInMan => signInMan.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(SignInResult.Success));
            var user = new LoginUserModel()
            {
                UserName = "Param14",
                Password = "P@ram1402"
            };

            var res = await _authBusiness.LoginUser(user);

            Assert.IsTrue(res);


        }

        [TestMethod]
        public async Task LogoutUser_LogsOutUser()
        {
            _mockSignInManager
                .Setup(signInMan => signInMan.SignOutAsync());
            var expected = true;

            var actual = true;
            try
            {
                await _authBusiness.LogoutUser();

            }
            catch(Exception ex) 
            {
                actual = false;
            }

            Assert.AreEqual(expected,actual);


        }



    }
}
