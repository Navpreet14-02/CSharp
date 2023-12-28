using BloodGuardianAPI.Business;
using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardianAPI.tests.Business.Tests
{
    [TestClass]
    public class UsersBusinessTests
    {
        public Mock<IUsersData> _mockUsersData;
        public Mock<IBloodBanksData> _mockBanksData;
        public Mock<IBloodTransferReceiptsData> _mockReceiptsData;
        public Mock<UserManager<IdentityUser>> _mockUserManager;


        private IUsersBusiness _usersBusiness;

        [TestInitialize]
        public void Initialize()
        {
            _mockUsersData = new Mock<IUsersData>();
            _mockBanksData = new Mock<IBloodBanksData>();
            _mockReceiptsData = new Mock<IBloodTransferReceiptsData>();

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


            _usersBusiness = new UsersBusiness(_mockUsersData.Object, _mockUserManager.Object,_mockBanksData.Object,_mockReceiptsData.Object);
        }



        [TestMethod]
        public void GetAllUsers_ReturnsUsersList()
        {

            _mockUsersData.Setup(userData => userData.GetUsers()).Returns(MockData.Users);


            var users = _usersBusiness.GetAllUsers();

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count() == 2);

        }


        [TestMethod]
        public async Task RemoveAUser_InputWrongUserId_ReturnsFalse()
        {

            _mockUsersData.Setup(userData => userData.GetUsers()).Returns(MockData.Users);
            int userId = 3;

            var res = await _usersBusiness.RemoveAUser(userId);

            Assert.IsFalse(res);
            //Assert.IsTrue();

        }

        [TestMethod]
        public async Task RemoveAUser_InputUserId_ThrowsException()
        {

            _mockUsersData
                .Setup(userData => userData.GetUsers())
                .Returns(MockData.Users);
            _mockUserManager
                .Setup(userManager => userManager.FindByIdAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(MockData.IdentityUsers.ElementAt(0)));
            _mockUserManager
                .Setup(userManager => userManager.DeleteAsync(It.IsAny<IdentityUser>()))
                .Returns(Task.FromResult(IdentityResult.Failed(new IdentityError())));
            int userId = 1;
            bool expected = true;


            bool actual=false;
            try
            {

                var res = await _usersBusiness.RemoveAUser(userId);
            }
            catch (Exception ex)
            {
                actual = true;
            }


            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public async Task RemoveAUser_InputUserId_ReturnsTrue()
        {

            _mockUsersData
                .Setup(userData => userData.GetUsers())
                .Returns(MockData.Users);
            _mockUserManager
                .Setup(userManager => userManager.FindByIdAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(MockData.IdentityUsers.ElementAt(0)));
            _mockUserManager
                .Setup(userManager => userManager.DeleteAsync(It.IsAny<IdentityUser>()))
                .Returns(Task.FromResult(IdentityResult.Success));
            int userId = 1;
            

            var res = await _usersBusiness.RemoveAUser(userId);
            

            Assert.IsTrue(res);

        }

        [TestMethod]
        public async Task GetUserBloodDonationHistory_InputWrongUserId_ReturnsNull()
        {

            _mockUsersData
                .Setup(userData => userData.GetUsers())
                .Returns(MockData.Users);
            //_mockUserManager
            //    .Setup(userManager => userManager.FindByIdAsync(It.IsAny<string>()))
            //    .Returns(Task.FromResult(MockData.IdentityUsers.ElementAt(0)));
            //_mockUserManager
            //    .Setup(userManager => userManager.DeleteAsync(It.IsAny<IdentityUser>()))
            //    .Returns(Task.FromResult(IdentityResult.Success));
            int userId = 3;


            var res = await _usersBusiness.GetUserBloodDonationHistory(userId);


            Assert.IsNull(res);

        }

        [TestMethod]
        public async Task GetUserBloodDonationHistory_InputUserId_ReturnsNull()
        {

            _mockUsersData
                .Setup(userData => userData.GetUsers())
                .Returns(MockData.Users);
            _mockUserManager
                .Setup(userManager => userManager.FindByIdAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(MockData.IdentityUsers.ElementAt(0)));
            _mockReceiptsData
                .Setup(recData => recData.GetAllBloodTransferReceipts())
                .Returns(MockData.Receipts.AsQueryable);
            _mockBanksData
                .Setup(banksData => banksData.GetAllBloodBanks()).Returns(MockData.BloodBanks.ToList);
            int userId = 1;


            var res = await _usersBusiness.GetUserBloodDonationHistory(userId);


            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count == 1);

        }


        [TestMethod]
        public void UpdateUserProfile_WrongUserIdAndUpdatedUserDetails_ReturnsFalse()
        {

            _mockUsersData
                .Setup(userData => userData.GetUsers())
                .Returns(MockData.Users);
            int userId = 3;
            var operation = new Operation<UserDetails>("replace", "/Name", "", "Parambeer");
            var updatedUser = new JsonPatchDocument<UserDetails>
                (
                    new List<Operation<UserDetails>>() { operation },
                    new DefaultContractResolver()
                );

            var res = _usersBusiness.UpdateUserProfile(userId, updatedUser);

            Assert.IsFalse(res);

        }

        [TestMethod]
        public void UpdateUserProfile_UserIdAndUpdatedUserDetails_ReturnsTrue()
        {

            _mockUsersData
                .Setup(userData => userData.GetUsers())
                .Returns(MockData.Users);
            _mockUsersData
                .Setup(userData => userData.UpdateUser(It.IsAny<int>(), It.IsAny<JsonPatchDocument<UserDetails>>()));
            int userId = 1;
            var operation = new Operation<UserDetails>("replace", "/Name", "", "Parambeer");
            var updatedUser = new JsonPatchDocument<UserDetails>
                (
                    new List<Operation<UserDetails>>() { operation },
                    new DefaultContractResolver()
                );


            var res = _usersBusiness.UpdateUserProfile(userId, updatedUser);


            Assert.IsTrue(res);

        }
    }
}
