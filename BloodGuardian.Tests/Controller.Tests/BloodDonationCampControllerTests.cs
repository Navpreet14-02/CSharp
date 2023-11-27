using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.Controller;
using Moq;

namespace BloodGuardian.Tests.Controller.Tests
{
    [TestClass]
    public class BloodDonationCampControllerTests
    {


        Mock<IBloodBankDBHandler> mockBankDB = new Mock<IBloodBankDBHandler>();

        private static BloodBank _bank = new BloodBank()
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
            BloodDonationCamps = new List<BloodDonationCamp>(){
                new BloodDonationCamp(){
                    camp_id= 0,
                    Date= DateTime.Parse("2023-12-10"),
                    Camp_State= "Punjab",
                    Camp_City= "Patiala",
                    Camp_Address= "Patiala,Punjab",
                    Start_Time= TimeOnly.Parse("10:00"),
                    End_Time= TimeOnly.Parse("20:00")
                },
                new BloodDonationCamp(){
                    camp_id= 1,
                    Date= DateTime.Parse("2023-12-15"),
                    Camp_State= "Punjab",
                    Camp_City= "Patiala",
                    Camp_Address= "Patiala,Punjab",
                    Start_Time= TimeOnly.Parse("10:00"),
                    End_Time= TimeOnly.Parse("20:00")
                },
            },
        };



        [TestMethod]
        public void OrganizeBloodDonationCamps_BankAndCamp_UpdatesBank()
        {
            var camp = new BloodDonationCamp()
            {
                camp_id = -1,
                Date = DateTime.Parse("2023-12-20"),
                Camp_State = "Punjab",
                Camp_City = "Patiala",
                Camp_Address = "Patiala,Punjab",
                Start_Time = TimeOnly.Parse("10:00"),
                End_Time = TimeOnly.Parse("20:00")
            };
            var expected = new BloodDonationCamp()
            {
                camp_id = 2,
                Date = DateTime.Parse("2023-12-20"),
                Camp_State = "Punjab",
                Camp_City = "Patiala",
                Camp_Address = "Patiala,Punjab",
                Start_Time = TimeOnly.Parse("10:00"),
                End_Time = TimeOnly.Parse("20:00")
            };

            var campController = new BloodDonationCampController(mockBankDB.Object);
            campController.OrganizeBloodDonationCamps(_bank,camp);

            Assert.IsTrue(_bank.BloodDonationCamps.Count == 3);
            Assert.AreEqual(expected, _bank.BloodDonationCamps[2]);

        }

        [TestMethod]
        public void RemoveBloodDonationCamps_BankAndCampid_UpdatesBank()
        {
            var campid = 0;

            var campController = new BloodDonationCampController(mockBankDB.Object);
            campController.RemoveBloodDonationCamps(_bank, campid);

            Assert.IsTrue(_bank.BloodDonationCamps.Count == 1|| _bank.BloodDonationCamps.Count == 2);


        }

    }
}
