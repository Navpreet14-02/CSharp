using BloodGuardian.Common.Enums;
using BloodGuardian.Controller;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using Moq;

namespace BloodGuardian.Tests.Controller.Tests
{
    [TestClass]
    public class DonorControllerTests
    {

        Mock<IDonorDBHandler> mockDonorDB = new Mock<IDonorDBHandler>();
        Mock<IBloodBankDBHandler> mockBankDB = new Mock<IBloodBankDBHandler>();




        [TestMethod]
        public void GetDonors_ReturnsDonorList()
        {

            mockDonorDB.Setup((donorDB) => donorDB.Get()).Returns(MockData._donorList);

            var donorController = new DonorController(mockBankDB.Object, mockDonorDB.Object);

            var list = donorController.GetDonors(); 

            Assert.IsTrue(list != null);
            Assert.IsTrue(list.Count == 3|| list.Count == 4);

        }



        [TestMethod]
        public void FindDonorByBank_BloodBank_ReturnsDonor()
        {

            BloodBank bank = new BloodBank()
            {
                BankId = 0,
                ManagerName = "Shahrukh",
                ManagerUserName = "Shahrukh14",
                ManagerEmail = "shah@wg.com",
                Contact = 3953598345,
                BankName = "shahrukh-bloodbank",
                State = "Punjab",
                Address = "Patiala,Punjab",
                City = "Patiala",
                Blood_WithDrawal_Record = new List<BloodTransferReceipt>(),
                Blood_Deposit_Record = new List<BloodTransferReceipt>(),
                BloodUnits = new Dictionary<string, int>{
                    { "A+", 200 },
                    { "A-", 200 },
                    { "B+", 200 },
                    { "B-", 300 },
                    { "O+", 100 },
                    { "O-", 100 },
                    { "AB+", 100 },
                    { "AB-", 50 }
                },
                BloodDonationCamps = new List<BloodDonationCamp>(),
            };

            var expected = new Donor() { Donorid = 1, UserName = "Shahrukh14", Name = "Shahrukh", Age = 35, Phone = 3953598345, Email = "shah@wg.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };

            mockDonorDB.Setup((donorDB) => donorDB.Get()).Returns(MockData._donorList);

            var donorController = new DonorController(mockBankDB.Object, mockDonorDB.Object);

            var actual = donorController.FindDonorByBank(bank);

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void UpdateProfile_UpdatesDonorList()
        {

            var oldDonor = new Donor() { Donorid = 1, UserName = "Shahrukh14", Name = "Shahrukh", Age = 35, Phone = 3953598345, Email = "shah@wg.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };
            var newDonor = new Donor() { Donorid = 1, UserName = "Shahrukh16", Name = "Shahrukh", Age = 35, Phone = 3953598345, Email = "shahrukh@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };

            var expected = new Donor() { Donorid = 1, UserName = "Shahrukh16", Name = "Shahrukh", Age = 35, Phone = 3953598345, Email = "shahrukh@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };
            


            mockDonorDB.Setup((donorDB) => donorDB.UpdateDonor(oldDonor, newDonor)).Callback(() =>
            {
                int donorIndex = oldDonor.Donorid;

                MockData._donorList[donorIndex] = newDonor;

            });

            var donorController = new DonorController(mockBankDB.Object, mockDonorDB.Object);

            donorController.UpdateProfile(oldDonor, newDonor);

            Assert.AreEqual(expected, MockData._donorList[1]);

        }

        [TestMethod]
        public void FindDonorByUserName_InputString_ReturnsDonor()
        {


            var expected = new Donor() { Donorid = 0, UserName = "Tarun14", Name = "Tarun", Age = 25, Phone = 1293412395, Email = "tarun14@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Tarun1402", BloodGrp = "B+", Role = Roles.Donor };
            string uname = "Tarun14";
            mockDonorDB.Setup((donorDB) => donorDB.Get()).Returns(MockData._donorList);


            var donorController = new DonorController(mockBankDB.Object, mockDonorDB.Object);
            var actual = donorController.FindDonorByUserName(uname);

            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void GetBloodDonationHistory_Donor_ReturnsDictionary()
        {


            var d = new Donor() { Donorid = 0, UserName = "Tarun14", Name = "Tarun", Age = 25, Phone = 1293412395, Email = "tarun14@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Tarun1402", BloodGrp = "B+", Role = Roles.Donor };
            string uname = "Tarun14";
            mockBankDB.Setup((bankDB) => bankDB.GetDonorBloodDonationHistory(d)).Returns(new Dictionary<BloodBank, List<BloodTransferReceipt>>());


            var donorController = new DonorController(mockBankDB.Object, mockDonorDB.Object);
            var dict = donorController.GetBloodDonationHistory(d);

            Assert.IsTrue(dict.Count==0);



        }
    }
}
