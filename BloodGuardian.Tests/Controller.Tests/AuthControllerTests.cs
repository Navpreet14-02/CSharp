using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Tests.Controller.Tests
{
    [TestClass]
    public class AuthControllerTests
    {

        Mock<IDonorDBHandler> mockDonorDB = new Mock<IDonorDBHandler>();


        [TestMethod]

        public void Register_InputDonor_UpdatesDonorList()
        {

            Donor d = new Donor() { Donorid = -1, UserName = "Vishal14", Name = "Vishal", Age = 22, Phone = 4964694569, Email = "vishal@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Vishal1402", BloodGrp = "B-", Role = Roles.Donor };
            var expected = new Donor() { Donorid = 3, UserName = "Vishal14", Name = "Vishal", Age = 22, Phone = 4964694569, Email = "vishal@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Vishal1402", BloodGrp = "B-", Role = Roles.Donor };
            mockDonorDB.Setup(donorDB => donorDB.Add(d)).Callback(() =>
            {
                d.Donorid = MockData._donorList.Count;
                MockData._donorList.Add(d);
            
            });


            var authController = new AuthController(mockDonorDB.Object);
            authController.Register(d);

            Assert.IsTrue(MockData._donorList.Count==4);
            Assert.AreEqual(expected, MockData._donorList[3]);




        }

        [TestMethod]

        public void Login_InputUserNameAndPassword_ReturnsDonor()
        {


            string uname = "Tarun14";
            string password = "Tarun1402";
            var expected = new Donor() { Donorid = 0, UserName = "Tarun14", Name = "Tarun", Age = 25, Phone = 1293412395, Email = "tarun14@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Tarun1402", BloodGrp = "B+", Role = Roles.Donor };
            
            mockDonorDB
                .Setup(donorDB => donorDB.FindDonorByCredentials(uname, password))
                .Returns
                (
                    MockData._donorList.Find((donor) => donor.UserName == uname && donor.Password == password)
                );


            var authController = new AuthController(mockDonorDB.Object);
            var actual = authController.Login(uname,password);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void Login_InputUserNameAndPassword_ReturnsNull()
        {


            string uname = "Tarun14";
            string password = "Tarun1412";
            Donor expected = null;
            mockDonorDB
                .Setup(donorDB => donorDB.FindDonorByCredentials(uname, password))
                .Returns
                (
                    MockData._donorList.Find((donor) => donor.UserName == uname && donor.Password == password)
                );


            var authController = new AuthController(mockDonorDB.Object);
            Donor actual = authController.Login(uname, password);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void CheckUserNameExists_InputUserName_ReturnsTrue()
        {


            string uname = "Tarun14";
            var expected = true;

            mockDonorDB
                .Setup(donorDB => donorDB.FindDonorByUserName(uname))
                .Returns
                (
                    MockData._donorList.Find((donor) => donor.UserName.Equals(uname, StringComparison.InvariantCultureIgnoreCase))
                );


            var authController = new AuthController(mockDonorDB.Object);
            var actual = authController.CheckUserNameExists(uname);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void CheckUserNameExists_InputUserName_ReturnsFalse()
        {


            string uname = "Tarun16";
            var expected = false;

            mockDonorDB
                .Setup(donorDB => donorDB.FindDonorByUserName(uname))
                .Returns
                (
                    MockData._donorList.Find((donor) => donor.UserName.Equals(uname, StringComparison.InvariantCultureIgnoreCase))
                );


            var authController = new AuthController(mockDonorDB.Object);
            var actual = authController.CheckUserNameExists(uname);

            Assert.AreEqual(expected, actual);

        }

    }
}
