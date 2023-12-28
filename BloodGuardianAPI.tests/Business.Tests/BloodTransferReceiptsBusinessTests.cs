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
    public class BloodTransferReceiptsBusinessTests
    {

        public Mock<IBloodBanksData> _mockBanksData = new Mock<IBloodBanksData>();
        public Mock<IBloodTransferReceiptsData> _mockReceiptsData = new Mock<IBloodTransferReceiptsData>();

        private IBloodTransferReceiptsBusiness _receiptsBusiness;
        [TestInitialize]
        public void InitializeBusiness()
        {
            _receiptsBusiness = new BloodTransferReceiptsBusiness(_mockReceiptsData.Object, _mockBanksData.Object);
        }


        [TestMethod]
        public void GetBloodTransferReceipts_InputBankIdAndTypeNull_ReturnsReceiptList()
        {

            _mockReceiptsData
                .Setup(receiptsData => receiptsData.GetAllBloodTransferReceipts())
                .Returns(MockData.Receipts.AsQueryable);
            int bankId = 1;
            string type = null;

            var list = _receiptsBusiness.GetBloodTransferReceipts(bankId, type);

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 3);


        }

        [TestMethod]
        public void GetBloodTransferReceipts_InputBankIdAndType_ReturnsReceiptList()
        {

            _mockReceiptsData
                .Setup(receiptsData => receiptsData.GetAllBloodTransferReceipts())
                .Returns(MockData.Receipts.AsQueryable);
            int bankId = 1;
            string type = "Deposit";

            var list = _receiptsBusiness.GetBloodTransferReceipts(bankId, type);

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count() == 1);


        }

        [TestMethod]
        public void AddBloodTransferReceipt_InputReceiptAndWrongBankId_ReturnsNegative1()
        {
            _mockBanksData
                .Setup(bankData => bankData.GetAllBloodBanks())
                .Returns(MockData.BloodBanks.ToList);
            //_mockBanksData
            //    .Setup(bankData => bankData.GetAllBankBloodGroupMapping())
            //    .Returns(MockData.BankBloodGrpMap.ToList);

            //_mockReceiptsData
            //    .Setup(receiptsData => receiptsData.GetAllBloodTransferReceipts())
            //    .Returns(MockData.Receipts.AsQueryable);
            int bankId = 3;
            var receipt = new BloodTransferReceipt()
            {
                CustomerName = "Ravi2",
                BloodId = 2,
                CustomerEmail = "ravi214@gmail.com",
                CustomerPhone = "4569804456",
                BloodTransferDate = DateTime.Parse("12/19/2023"),
                BloodAmount = 100,
                Receipt_Type = "Deposit",
                BankId = 1,
            };
            var expected = -1;

            var actual = _receiptsBusiness.AddBloodTransferReceipt(receipt,bankId);

            Assert.AreEqual(expected,actual);


        }

        [TestMethod]
        public void AddBloodTransferReceipt_InputReceiptAndBankId_Returns0()
        {
            _mockBanksData
                .Setup(bankData => bankData.GetAllBloodBanks())
                .Returns(MockData.BloodBanks.ToList);
            _mockBanksData
                .Setup(bankData => bankData.GetAllBankBloodGroupMapping())
                .Returns(MockData.BankBloodGrpMap.ToList);

            _mockReceiptsData
                .Setup(receiptsData => receiptsData.GetAllBloodTransferReceipts())
                .Returns(MockData.Receipts.AsQueryable);

            int bankId = 1;
            var receipt = new BloodTransferReceipt()
            {
                CustomerName = "Ravi2",
                BloodId = 2,
                CustomerEmail = "ravi214@gmail.com",
                CustomerPhone = "4569804456",
                BloodTransferDate = DateTime.Parse("12/19/2023"),
                BloodAmount = 100,
                Receipt_Type = "Deposit",
                BankId = 1,
            };
            var expected = 0;

            var actual = _receiptsBusiness.AddBloodTransferReceipt(receipt, bankId);

            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void AddBloodTransferReceipt_InputReceiptAndBankId_Returns1()
        {
            _mockBanksData
                .Setup(bankData => bankData.GetAllBloodBanks())
                .Returns(MockData.BloodBanks.ToList);
            _mockBanksData
                .Setup(bankData => bankData.GetAllBankBloodGroupMapping())
                .Returns(MockData.BankBloodGrpMap.ToList);
            _mockBanksData
                .Setup(bankData => bankData.UpdateBloodGroupAmount(It.IsAny<BankBloodGroupMapping>(), It.IsAny<string>(), It.IsAny<int>()));

            _mockReceiptsData
                .Setup(receiptsData => receiptsData.GetAllBloodTransferReceipts())
                .Returns(MockData.Receipts.AsQueryable);
            _mockReceiptsData
                .Setup(receiptsData => receiptsData.AddBloodTransferReceipt(It.IsAny<BloodTransferReceipt>()));



            int bankId = 1;
            var receipt = new BloodTransferReceipt()
            {
                CustomerName = "Rohan2",
                BloodId = 2,
                CustomerEmail = "Rohan214@gmail.com",
                CustomerPhone = "4569804456",
                BloodTransferDate = DateTime.Parse("12/19/2023"),
                BloodAmount = 100,
                Receipt_Type = "Deposit",
                BankId = 1,
            };
            var expected = 1;

            var actual = _receiptsBusiness.AddBloodTransferReceipt(receipt, bankId);

            Assert.AreEqual(expected, actual);


        }

    }
}
