//using BloodGuardian.Database.Interface;
//using BloodGuardian.Models;
//using BloodGuardian.Common.Enums;
//using Moq;
//using BloodGuardian.Controller.Interfaces;

//namespace BloodGuardian.Tests.Database.Tests
//{


//    [TestClass]
//    public class DonorDBHandlerTests
//    {
//        Mock<IDonorDBHandler> mockDB = new Mock<IDonorDBHandler>();

//        private static List<Donor> _donorList = new List<Donor>
//        {
//            new Donor(){Donorid= 0,UserName= "Tarun14",Name= "Tarun",Age= 25,Phone= 1293412395,Email= "tarun14@gmail.com",State= "Punjab",Address= "Patiala,Punjab",City= "Patiala",Password= "Tarun1402",BloodGrp= "B+",Role= Roles.Donor },
//            new Donor() {Donorid= 1,UserName= "Shahrukh14",Name= "Shahrukh",Age= 35,Phone= 3953598345,Email= "shah@wg.com",State= "Punjab",Address= "Patiala,Punjab",City= "Patiala",Password= "Sharhrukh14",BloodGrp= "O+",Role= Roles.BloodBankManager},
//        };


//        [TestMethod]
//        public void Get_FetchingDonors_ReturnsList()
//        {

//            mockDB.Setup(donorDB => donorDB.Get()).Returns(_donorList);

//            var donorList = mockDB.Object.Get();

//            Assert.IsTrue(donorList.Count ==2);
//        }


//        [TestMethod]
//        public void Add_AddDonorObject_UpdatesDonorList()
//        {

//            Donor d = new Donor() { Donorid = -1, UserName = "Raja14", Name = "Raja", Age = 25, Phone = 3953556785, Email = "raja@gmail.com", State = "Uttar Pradesh", Address = "Noida,Uttar Pradesh", City = "Noida", Password = "Raja14", BloodGrp = "AB+", Role = Roles.Donor };
//            Donor expected = new Donor() { Donorid = 2, UserName = "Raja14", Name = "Raja", Age = 25, Phone = 3953556785, Email = "raja@gmail.com", State = "Uttar Pradesh", Address = "Noida,Uttar Pradesh", City = "Noida", Password = "Raja14", BloodGrp = "AB+", Role = Roles.Donor };
//            Donor actual=null;
//            mockDB.Setup(donorDB => donorDB.Add(d)).Callback(() =>
//            {
//                d.Donorid = _donorList.Count;
//                _donorList.Add(d);
//                actual =  d;
//            });
            


//            mockDB.Object.Add(d);

//            Console.WriteLine(_donorList.Count);


//            Assert.IsTrue(_donorList.Count == 3);
//            Assert.AreEqual(actual, expected);


//        }


//        [TestMethod]
//        public void Delete_DeleteDonorObject_UpdatesDonorList()
//        {
//            Donor d = new Donor() { Donorid = 1, UserName = "Shahrukh14", Name = "Shahrukh", Age = 35, Phone = 3953598345, Email = "shah@wg.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };
//            mockDB.Setup(donorDB => donorDB.Delete(d)).Callback(() =>
//            {
//                _donorList.Remove(d);
//                foreach (var (donor, ind) in _donorList.Select((val, i) => (val, i)))
//                {
//                    donor.Donorid = ind;
//                }

//            });


//            mockDB.Object.Delete(d);


//            Assert.IsTrue(_donorList.Count == 2);
//            Assert.IsTrue(_donorList[1].UserName== "Raja14");


//        }

//        [TestMethod]
//        public void Update_UpdatesDonorObject()
//        {

//            Donor oldDonor = new Donor() { Donorid = 1, UserName = "Shahrukh14", Name = "Shahrukh", Age = 35, Phone = 3953598345, Email = "shah@wg.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };
//            Donor newDonor = new Donor() { Donorid = 1, UserName = "Shahrukh16", Name = "Shahrukh", Age = 38, Phone = 3953598345, Email = "shah@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };
//            Donor expected = new Donor() { Donorid = 1, UserName = "Shahrukh16", Name = "Shahrukh", Age = 38, Phone = 3953598345, Email = "shah@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };
//            mockDB.Setup(donorDB => donorDB.UpdateDonor(oldDonor,newDonor)).Callback(() =>
//            {
//                int donorIndex = oldDonor.Donorid;
//                _donorList[donorIndex] = newDonor;

//            });


//            mockDB.Object.UpdateDonor(oldDonor,newDonor);



//            Assert.IsTrue(_donorList.Count == 2);
//            Assert.AreEqual(expected, _donorList[oldDonor.Donorid]);


//        }

//        [TestMethod]
//        public void FindDonorByCredentials_UsernameandPassword_ReturnsDonorObject()
//        {

//            string uname = "Tarun14";
//            string password = "Tarun1402";

//            Donor expected = new Donor() { Donorid = 0, UserName = "Tarun14", Name = "Tarun", Age = 25, Phone = 1293412395, Email = "tarun14@gmail.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Tarun1402", BloodGrp = "B+", Role = Roles.Donor };


//            Donor actual = null;
//            mockDB.Setup(donorDB => donorDB.FindDonorByCredentials(uname, password)).Callback(() =>
//            {
//                Donor d = _donorList.Find((donor) => donor.UserName.Equals(uname, StringComparison.InvariantCultureIgnoreCase) && donor.Password.Equals(password));

//                actual = d;
//            });


//            mockDB.Object.FindDonorByCredentials(uname, password);


//            Assert.AreEqual(actual, expected);


//        }


//        [TestMethod]
//        public void FindDonorByBank_InputBloodBankObject_ReturnsDonorObject()
//        {


//            BloodBank bank = new BloodBank()
//            {
//                BankId = 0,
//                ManagerName = "Shahrukh",
//                ManagerUserName = "Shahrukh14",
//                ManagerEmail = "shah@wg.com",
//                Contact = 3953598345,
//                BankName = "shahrukh-bloodbank",
//                State = "Punjab",
//                Address = "Patiala,Punjab",
//                City = "Patiala",
//                Blood_WithDrawal_Record = new List<BloodTransferReceipt>(),
//                Blood_Deposit_Record = new List<BloodTransferReceipt>(),
//                BloodUnits = new Dictionary<string, int>(){
//                  {"A+", 0 },
//                  {"A-", 0 },
//                  {"B+", 0 },
//                  {"B-", 50 },
//                  {"O+", 40 },
//                  {"O-", 0 },
//                  {"AB+",0 },
//                  {"AB-", 0 },
//                },
//                BloodDonationCamps = new List<BloodDonationCamp>(),
//            };

//            Donor expected = new Donor() { Donorid = 1, UserName = "Shahrukh14", Name = "Shahrukh", Age = 35, Phone = 3953598345, Email = "shah@wg.com", State = "Punjab", Address = "Patiala,Punjab", City = "Patiala", Password = "Sharhrukh14", BloodGrp = "O+", Role = Roles.BloodBankManager };


//            Donor actual = null;
//            mockDB.Setup(donorDB => donorDB.FindDonorByBank(bank)).Callback(() =>
//            {
//                Donor d = _donorList.Find((dn) => dn.UserName.Equals(bank.ManagerUserName, StringComparison.InvariantCultureIgnoreCase));

//                actual = d;
//            });


//            mockDB.Object.FindDonorByBank(bank);


//            Assert.AreEqual(actual, expected);


//        }

//    }
//}
