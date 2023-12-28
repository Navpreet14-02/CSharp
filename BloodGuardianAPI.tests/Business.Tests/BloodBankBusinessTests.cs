using BloodGuardianAPI.Business;
using BloodGuardianAPI.Business.Interfaces;
using BloodGuardianAPI.DataAccess.Interfaces;
using BloodGuardianAPI.Models;
using BloodGuardianAPI.Models.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BloodGuardianAPI.tests.Business.Tests
{
    [TestClass]
    public class BloodBankBusinessTests
    {
        public Mock<IBloodBanksData> _mockBanksData=new Mock<IBloodBanksData>();
        public Mock<IUsersData> _mockUsersData=new Mock<IUsersData>();
        public Mock<IBloodGroupsData> _mockBloodGroupsData=new Mock<IBloodGroupsData>();


        private IBloodBankBusiness _bankBusiness;

        [TestInitialize]
        public void InitializeBusiness()
        {
            _bankBusiness = new BloodBankBusiness(_mockBanksData.Object,_mockUsersData.Object,_mockBloodGroupsData.Object);
        }

        [TestMethod]
        public void GetAllBloodBanks_ReturnsBanksList()
        {
            _mockBanksData.Setup(banksData => banksData.GetAllBloodBanks()).Returns(MockData.BloodBanks.ToList());

            var list = _bankBusiness.GetAllBloodBanks();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 2);

        }


        [TestMethod]
        public void GetBloodBankDetails_InputBankId_ReturnsNull()
        {
            _mockBanksData.Setup(banksData => banksData.GetAllBloodBanks()).Returns(MockData.BloodBanks.ToList());
            int bankId = 3;
            
            var actual = _bankBusiness.GetBloodBankDetails(bankId);

            Assert.IsNull(actual);

        }

        [TestMethod]
        public void GetBloodBankDetails_InputBankId_ReturnsBloodBank()
        {
            _mockBanksData.Setup(banksData => banksData.GetAllBloodBanks()).Returns(MockData.BloodBanks.ToList());
            int bankId = 2;
            var expected = new BloodBank()
            {
                Id = 2,
                BankName = "Varun-BloodBank",
                State = "Punjab",
                City = "Patiala",
                Address = "Patiala,Punjab",
                IdentityUserId = "1",
            };


            var actual = _bankBusiness.GetBloodBankDetails(bankId);


            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id,actual.Id);

        }

        [TestMethod]
        public void AddBloodBank_InputBankDetailsAndUserName_BanksDataReturnsNeg1_ReturnsFalse()
        {
            _mockBanksData.Setup(banksData => banksData.AddBloodBank(It.IsAny<BloodBank>())).Returns(-1);
            _mockUsersData.Setup(usersData => usersData.GetUsers()).Returns(MockData.Users);
            //_mockBanksData.Setup(banksData => banksData.AddBankBloodGroupMapping(It.IsAny<BankBloodGroupMapping>())).Returns(true);

            string uname = "Param14";
            var inputBank = new RegisterBloodBankModel()
            {
                BankName = "Varun-BloodBank",
                State = "Punjab",
                City = "Patiala",
                Address = "Patiala,Punjab",
            };


            var res = _bankBusiness.AddBloodBank(inputBank,uname);


            Assert.IsFalse(res);

        }

        [TestMethod]
        public void AddBloodBank_InputBankDetailsAndUserName_AddMappingReturnsFalse_ReturnsFalse()
        {
            _mockBanksData.Setup(banksData => banksData.AddBloodBank(It.IsAny<BloodBank>())).Returns(1);
            _mockUsersData.Setup(usersData => usersData.GetUsers()).Returns(MockData.Users);
            _mockBanksData.Setup(banksData => banksData.AddBankBloodGroupMapping(It.IsAny<BankBloodGroupMapping>())).Returns(false);

            string uname = "Param14";
            var inputBank = new RegisterBloodBankModel()
            {
                BankName = "Varun-BloodBank",
                State = "Punjab",
                City = "Patiala",
                Address = "Patiala,Punjab",
                BloodUnits= new Dictionary<string,int>{
                    {"1", 0 },
                    {"2", 0 },
                    {"3", 200 },
                    {"4", 300 },
                    {"5", 100 },
                    {"6", 100 },
                    {"7", 100 },
                    {"8", 50 }
                },
            };


            var res = _bankBusiness.AddBloodBank(inputBank, uname);


            Assert.IsFalse(res);

        }

        [TestMethod]
        public void AddBloodBank_InputBankDetailsAndUserName_ReturnsTrue()
        {
            _mockBanksData.Setup(banksData => banksData.AddBloodBank(It.IsAny<BloodBank>())).Returns(1);
            _mockUsersData.Setup(usersData => usersData.GetUsers()).Returns(MockData.Users);
            _mockBanksData.Setup(banksData => banksData.AddBankBloodGroupMapping(It.IsAny<BankBloodGroupMapping>())).Returns(true);

            string uname = "Param14";
            var inputBank = new RegisterBloodBankModel()
            {
                BankName = "Varun-BloodBank",
                State = "Punjab",
                City = "Patiala",
                Address = "Patiala,Punjab",
                BloodUnits = new Dictionary<string, int>{
                    {"1", 0 },
                    {"2", 0 },
                    {"3", 200 },
                    {"4", 300 },
                    {"5", 100 },
                    {"6", 100 },
                    {"7", 100 },
                    {"8", 50 }
                },
            };


            var res = _bankBusiness.AddBloodBank(inputBank, uname);


            Assert.IsTrue(res);

        }


        [TestMethod]
        public void RemoveBloodBank_InputBankId_ReturnsFalse()
        {
            _mockBanksData.Setup(banksData => banksData.GetAllBloodBanks()).Returns(MockData.BloodBanks.ToList());
            int bankId = 3;

            var res = _bankBusiness.RemoveBloodBank(bankId);

            Assert.IsFalse(res);
        }


        [TestMethod]
        public void RemoveBloodBank_InputBankId_ReturnsTrue()
        {
            _mockBanksData.Setup(banksData => banksData.GetAllBloodBanks()).Returns(MockData.BloodBanks.ToList());
            _mockBanksData.Setup(banksData => banksData.RemoveBloodBank(It.IsAny<BloodBank>())).Returns(true);
            int bankId = 1;

            var res = _bankBusiness.RemoveBloodBank(bankId);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void RemoveBloodBank_InputBankId_BankDataReturnsFalse_ReturnsFalse()
        {
            _mockBanksData.Setup(banksData => banksData.GetAllBloodBanks()).Returns(MockData.BloodBanks.ToList());
            _mockBanksData.Setup(banksData => banksData.RemoveBloodBank(It.IsAny<BloodBank>())).Returns(false);
            int bankId = 1;

            var res = _bankBusiness.RemoveBloodBank(bankId);

            Assert.IsFalse(res);
        }


        [TestMethod]
        public void SearchBlood_InputStateAndCityAndBloodType_ReturnsBloodBanksList()
        {

            _mockBloodGroupsData
                .Setup(bloodGrpData => bloodGrpData.GetBloodGroups())
                .Returns(MockData.BloodGroups);
            _mockBanksData
                .Setup(banksData => banksData.GetAllBloodBanks())
                .Returns(MockData.BloodBanks.ToList());
            _mockBanksData
                .Setup(banksData => banksData.GetAllBankBloodGroupMapping())
                .Returns(MockData.BankBloodGrpMap);
            string state = "Punjab";
            string city = "Patiala";
            string bloodType = "A-";


            var res = _bankBusiness.SearchBlood(state, city, bloodType);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count() == 1);


        }

        [TestMethod]
        public void SearchBloodBanks_InputStateAndCity_ReturnsBloodBanksList()
        {

            _mockBanksData
                .Setup(banksData => banksData.GetAllBloodBanks())
                .Returns(MockData.BloodBanks.ToList());
            string state = "Punjab";
            string city = "Patiala";


            var res = _bankBusiness.SearchBloodBanks(state, city);

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Count() == 1);


        }

    }
}
