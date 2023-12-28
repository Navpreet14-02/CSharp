using BloodGuardianAPI.Business;
using BloodGuardianAPI.Business.Interfaces;
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
    public class BloodDonationCampBusinessTests
    {

        public Mock<IBloodDonationCampsData> _campsData = new Mock<IBloodDonationCampsData>();

        private IBloodDonationCampBusiness _campBusiness;

        [TestInitialize]
        public void InitializeBusiness()
        {
            _campBusiness = new BloodDonationCampBusiness(_campsData.Object);
        }


        [TestMethod]
        public void GetBloodDonationCampsByBankId_InputBankId_ReturnsNull()
        {
            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);
            int bankId = 3;

            var list = _campBusiness.GetBloodDonationCampsByBankId(bankId);


            Assert.IsTrue(list == null || list.Count() == 0);


        }


        [TestMethod]
        public void GetBloodDonationCampsByBankId_InputBankId_ReturnsCamp()
        {
            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);
            int bankId = 1;

            var list = _campBusiness.GetBloodDonationCampsByBankId(bankId);


            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 1);


        }


        [TestMethod]
        public void GetBloodDonationCampDetails_InputCampId_ReturnsNull()
        {

            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);
            int campId = 3;

            var res = _campBusiness.GetBloodDonationCampDetails(campId);

            Assert.IsNull(res);

        }


        [TestMethod]
        public void GetBloodDonationCampDetails_InputCampId_ReturnsDonationCamp()
        {

            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);
            int campId = 1;
            int expected = 1;

            var actual = _campBusiness.GetBloodDonationCampDetails(campId);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Id);

        }

        [TestMethod]
        public void GetAllBloodDonationCamps_ReturnsBloodDonationCampsList()
        {
            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);

            var list = _campBusiness.GetAllBloodDonationCamps();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 2);
        }


        [TestMethod]
        public void AddBloodDonationCamp_InputCampDetailsAndBankId_ReturnsFalse()
        {
            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);
            int bankid = 1;
            var camp = new BloodDonationCamp()
            {
                Camp_Date = DateTime.Parse("12/25/2023"),
                Camp_City = "Patiala",
                Camp_State = "Punjab",
                Camp_Address = "Patiala,Punjab",
                Start_Time = DateTime.Parse("6:00"),
                End_Time = DateTime.Parse("20:00"),
            };


            var res = _campBusiness.AddBloodDonationCamp(bankid,camp);


            Assert.IsFalse(res);
        }

        [TestMethod]
        public void AddBloodDonationCamp_InputCampDetailsAndBankId_ReturnsTrue()
        {
            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);
            _campsData.Setup(campData => campData.AddBloodDonationCamp(It.IsAny<BloodDonationCamp>()));
            int bankid = 1;
            var camp = new BloodDonationCamp()
            {
                Camp_Date = DateTime.Parse("12/25/2023"),
                Camp_City = "Mohali",
                Camp_State = "Punjab",
                Camp_Address = "Mohali,Punjab",
                Start_Time = DateTime.Parse("10:00"),
                End_Time = DateTime.Parse("20:00")
            };


            var res = _campBusiness.AddBloodDonationCamp(bankid, camp);


            Assert.IsTrue(res);
        }

        [TestMethod]    
        public void RemoveBloodDonationCamp_InputCampId_ReturnsFalse()
        {
            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);
            _campsData.Setup(campData => campData.RemoveBloodDonationCamp(It.IsAny<BloodDonationCamp>()));
            int campid = 3;

            var res = _campBusiness.RemoveBloodDonationCamp(campid);

            Assert.IsFalse(res);    
        
        }

        [TestMethod]
        public void RemoveBloodDonationCamp_InputCampId_ReturnsTrue()
        {
            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);
            _campsData.Setup(campData => campData.RemoveBloodDonationCamp(It.IsAny<BloodDonationCamp>()));
            int campid = 1;

            var res = _campBusiness.RemoveBloodDonationCamp(campid);

            Assert.IsTrue(res);

        }

        [TestMethod]
        public void SearchBloodDonationCamp_InputStateAndCity_ReturnCampsList()
        {
            _campsData.Setup(campData => campData.GetAllBloodDonationCamps()).Returns(MockData.Camps.AsQueryable);
            string state = "Punjab";
            string city = "Patiala";

            var list = _campBusiness.SearchBloodDonationCamps(state, city); 

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 1);
        }
    }
}
