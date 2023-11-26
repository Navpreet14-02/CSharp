using BloodGuardian.Common.Enums;
using BloodGuardian.Database.Interface;
using BloodGuardian.Models;
using BloodGuardian.Controller;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodGuardian.Tests.Controller.Tests
{
    [TestClass]
    public class DonorControllerTests
    {

        Mock<IDonorDBHandler> mockDonorDB = new Mock<IDonorDBHandler>();
        Mock<IBloodBankDBHandler> mockBankDB = new Mock<IBloodBankDBHandler>();


        private static List<Donor> _donorList = new List<Donor>
        {
            
            new Donor(){Donorid= 0,UserName= "Tarun14",Name= "Tarun",Age= 25,Phone= 1293412395,Email= "tarun14@gmail.com",State= "Punjab",Address= "Patiala,Punjab",City= "Patiala",Password= "Tarun1402",BloodGrp= "B+",Role= Roles.Donor },
            new Donor() {Donorid= 1,UserName= "Shahrukh14",Name= "Shahrukh",Age= 35,Phone= 3953598345,Email= "shah@wg.com",State= "Punjab",Address= "Patiala,Punjab",City= "Patiala",Password= "Sharhrukh14",BloodGrp= "O+",Role= Roles.BloodBankManager},
        };


        [TestMethod]
        public void GetDonors_ReturnsDonorList()
        {
            mockDonorDB.Setup((donorDB) => donorDB.Get()).Returns(_donorList);

            var donorController = new DonorController(mockBankDB.Object,mockDonorDB.Object);

            Assert.IsTrue(_donorList != null);
            Assert.IsTrue(_donorList.Count == 2);

        }


        //[TestMethod]
        //public void GetDonors_ReturnsDonorList()
        //{
        //    mockDonorDB.Setup((donorDB) => donorDB.Get()).Returns(_donorList);

        //    var donorController = new DonorController(null, mockBankDB.Object, mockDonorDB.Object);

        //    Assert.IsTrue(_donorList != null);
        //    Assert.IsTrue(_donorList.Count == 2);

        //}




    }
}
