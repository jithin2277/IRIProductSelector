using IRIProductSelector.Data.CsvMappers;
using IRIProductSelector.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TinyCsvParser.Mapping;
using Moq;
using TinyCsvParser;
using IRIProductSelector.Data.Respositories;
using System.Collections.Generic;

namespace IRIProductSelector.Data.Tests
{
    [TestClass]
    public class RetailerProductRepositoryTests
    {
        private Mock<IDataRetriever<RetailerProduct>> _mockDataRetriever;
        private IRepository<RetailerProduct> _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDataRetriever = new Mock<IDataRetriever<RetailerProduct>>(MockBehavior.Strict);
            _sut = new RetailerProductRepository(_mockDataRetriever.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockDataRetriever.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WhenParameters_AreNull_ThrowsException()
        {
            _ = new RetailerProductRepository(null);
        }

        [TestMethod]
        public void GetAll_GetsAllRetailerProducts()
        {
            var retailerProduct = new RetailerProduct { DateReceived = new DateTime(), ProductId = "1" , RetailerName = "foobar", RetailerProductCode = "code", RetailerProductCodeType = "type" };

            var retailerProducts = new List<RetailerProduct> {
                retailerProduct
            };

            _mockDataRetriever.Setup(s => s.GetResults()).Returns(retailerProducts);

            var result = _sut.GetAll();

            Assert.AreEqual(retailerProducts, result);
        }
    }
}
