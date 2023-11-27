using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodGuardian.Controller.Interfaces;
using BloodGuardian.Common.Enums;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.Controller;
using Moq;
using System.Reflection;

namespace BloodGuardian.Tests.Controller.Tests
{

    [TestClass]
    public class BloodBankControllerTests
    {
        Mock<IBloodBankDBHandler> mockBankDB = new Mock<IBloodBankDBHandler>();
        Mock<IDonorDBHandler> mockDonorDB = new Mock<IDonorDBHandler>();


        [TestMethod]
        public void AddBloodBank_InputsBank_UpdatesBankList()
        {

            var newBank = new BloodBank()
            {
                BankId = -1,
                ManagerName = "Akshay Kumar",
                ManagerUserName = "Akshay14",
                ManagerEmail = "akshay@gmail.com",
                Contact = 3953598345,
                BankName = "akshay-bloodbank",
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
            var expected = new BloodBank()
            {
                BankId = 3,
                ManagerName = "Akshay Kumar",
                ManagerUserName = "Akshay14",
                ManagerEmail = "akshay@gmail.com",
                Contact = 3953598345,
                BankName = "akshay-bloodbank",
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
            mockBankDB.Setup((bankDB) => bankDB.Add(newBank)).Callback(() =>
            {
                newBank.BankId = MockData._banksList.Count;
                MockData._banksList.Add(newBank);
            });


            var bankController = new BloodBankController(mockBankDB.Object, mockDonorDB.Object);
            bankController.AddBloodBank(newBank);

            Assert.IsTrue(MockData._banksList.Count == 4);
            Assert.AreEqual(expected, MockData._banksList[3]);


        }

        [TestMethod]
        public void GetBloodBanks_ReturnBanksList()
        {
            mockBankDB.Setup((bankDB)=>bankDB.Get()).Returns(MockData._banksList);


            var bankController = new BloodBankController(mockBankDB.Object, mockDonorDB.Object);
            var list = bankController.GetBloodBanks();

            Assert.IsTrue(MockData._banksList.Count == 3 || MockData._banksList.Count==4);


        }

        [TestMethod]
        public void FindBloodBankbyId_InputId_ReturnsBloodBank()
        {
            mockBankDB.Setup((bankDB) => bankDB.Get()).Returns(MockData._banksList);
            int id = 0;
            var expected = new BloodBank()
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

            var bankController = new BloodBankController(mockBankDB.Object, mockDonorDB.Object);
            var actual = bankController.FindBloodBankbyId(id);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void FindBloodBankbyId_InputId_ReturnsNull()
        {
            mockBankDB.Setup((bankDB) => bankDB.Get()).Returns(MockData._banksList);
            int id = 4;
            BloodBank expected = null;

            var bankController = new BloodBankController(mockBankDB.Object, mockDonorDB.Object);
            var actual = bankController.FindBloodBankbyId(id);

            Assert.AreEqual(expected, actual);

        }



        [TestMethod]
        public void FindBloodBankByDonor_InputDonor_ReturnsBloodBank()
        {
            var donor = new Donor() { Donorid = 1, UserName = "Shahrukh14", Name = "Shahrukh", Age = 35, Phone = 3953598345, Email = "shah@wg.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };
            mockBankDB
                .Setup((bankDB) => bankDB.FindBloodBankbyDonor(donor))
                .Returns
                (
                    MockData._banksList.Find((b) => b.ManagerUserName.Equals(donor.UserName, StringComparison.InvariantCultureIgnoreCase))
                );
            var expected = new BloodBank()
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

            var bankController = new BloodBankController(mockBankDB.Object, mockDonorDB.Object);
            var actual = bankController.FindBloodBankByDonor(donor);

            Assert.AreEqual(expected, actual);



        }

        [TestMethod]
        public void FindBloodBankByDonor_InputDonor_ReturnsNull()
        {
            var donor = new Donor() { Donorid = 1, UserName = "Shahrukh16", Name = "Shahrukh", Age = 35, Phone = 3953598345, Email = "shah@wg.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };
            mockBankDB
                .Setup((bankDB) => bankDB.FindBloodBankbyDonor(donor))
                .Returns
                (
                    MockData._banksList.Find((b) => b.ManagerUserName.Equals(donor.UserName, StringComparison.InvariantCultureIgnoreCase))
                );
            BloodBank expected = null;

            var bankController = new BloodBankController(mockBankDB.Object, mockDonorDB.Object);
            var actual = bankController.FindBloodBankByDonor(donor);

            Assert.AreEqual(expected, actual);



        }

        [TestMethod]
        public void UpdateBloodBank_OldAndNewBloodBank_UpdatesBanksList()
        {

            var oldBank = new BloodBank()
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
            var newBank = new BloodBank()
            {
                BankId = 0,
                ManagerName = "Shahrukh",
                ManagerUserName = "Shahrukh14",
                ManagerEmail = "shah@wg.com",
                Contact = 3953598345,
                BankName = "shah-bloodbank",
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
            var expected = new BloodBank()
            {
                BankId = 0,
                ManagerName = "Shahrukh",
                ManagerUserName = "Shahrukh14",
                ManagerEmail = "shah@wg.com",
                Contact = 3953598345,
                BankName = "shah-bloodbank",
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



            mockBankDB
                .Setup((bankDB) => bankDB.UpdateBloodBank(oldBank, newBank))
                .Callback
                (() => { 
                    int bbIndex = oldBank.BankId;
                    newBank.BankId = oldBank.BankId;
                    MockData._banksList[bbIndex] = newBank;
                });


            var bankController = new BloodBankController(mockBankDB.Object, mockDonorDB.Object);
            bankController.UpdateBloodBank(oldBank,newBank);



            Assert.AreEqual(expected, MockData._banksList[oldBank.BankId]);

        }

        

        [TestMethod]
        public void AdminRemoveBloodBank_InputBloodBank_UpdatesBanksList()
        {

            var bank = new BloodBank()
            {
                BankId = 1,
                ManagerName = "Salman",
                ManagerUserName = "Salman14",
                ManagerEmail = "salman@gmail.com",
                Contact = 3953598345,
                BankName = "salman-bloodbank",
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

            mockBankDB
                .Setup((bankDB) => bankDB.Delete(bank))
                .Callback
                (() =>
                {
                    MockData._banksList.Remove(bank);

                    foreach (var (bank, ind) in MockData._banksList.Select((val, i) => (val, i)))
                    {
                        bank.BankId = ind;
                    }

                });
            mockDonorDB.Setup(donorDB => donorDB.Delete(null));

            var bankController = new BloodBankController(mockBankDB.Object, mockDonorDB.Object);
            bankController.AdminRemoveBloodBank(bank);



            Assert.IsTrue(MockData._banksList.Count==2|| MockData._banksList.Count == 3);
            Assert.IsTrue(MockData._banksList[bank.BankId].ManagerUserName == "Varun14");

        }

    }
}
