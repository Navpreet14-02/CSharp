using BloodGuardianAPI.Data;
using BloodGuardianAPI.DataAccess;
using BloodGuardianAPI.DataAccess.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BloodGuardianAPI.tests.DataAccess.Tests
{
    [TestClass]
    public class BloodBankDataTests
    {
        Mock<AppDbContext> _dbContext;

        private IBloodBanksData _banksData;

        [TestInitialize]
        public void Initialize()
        {
            //var options = new DbContextOptionsBuilder<AppDbContext>()
            //.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            //.Options;
            _dbContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _banksData = new BloodBanksData(_dbContext.Object);
        }

        [TestMethod]
        public void GetAllBloodBanks_ReturnsBanksList()
        {

            _dbContext.Setup(context => context.BloodBanks).ReturnsDbSet(MockData.BloodBanks);

            var list = _banksData.GetAllBloodBanks();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count==2);


        }
    }
}
