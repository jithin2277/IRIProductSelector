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
        private Mock<IRepository<Product>> _mockProductRepository;
        private IRepository<RetailerProduct> _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDataRetriever = new Mock<IDataRetriever<RetailerProduct>>(MockBehavior.Strict);
            _mockProductRepository = new Mock<IRepository<Product>>(MockBehavior.Strict);
            _sut = new RetailerProductRepository(_mockDataRetriever.Object, _mockProductRepository.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockProductRepository.VerifyAll();
            _mockDataRetriever.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WhenParameters_AreNull_ThrowsException()
        {
            _ = new RetailerProductRepository(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WhenDataReteiver_IsNull_ThrowsException()
        {
            _ = new RetailerProductRepository(null, _mockProductRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WhenProductRepository_IsNull_ThrowsException()
        {
            _ = new RetailerProductRepository(_mockDataRetriever.Object, null);
        }

        [TestMethod]
        public void GetAll_GetsAllRetailerProducts()
        {
            var product = new Product { ProductId = "1", ProductName = "Foo" };
            var retailerProduct = new RetailerProduct { DateReceived = "1/1/2001", ProductId = product.ProductId, ProductName = product.ProductName, RetailerName = "foobar", RetailerProductCode = "code", RetailerProductCodeType = "type" };

            var products = new List<Product> {
                product
            };

            var retailerProducts = new List<RetailerProduct> {
                retailerProduct
            };

            _mockDataRetriever.Setup(s => s.GetResults()).Returns(retailerProducts);
            _mockProductRepository.Setup(s => s.GetById(product.ProductId)).Returns(product);

            var result = _sut.GetAll();

            Assert.AreEqual(retailerProducts.Count, result.Count);

            foreach (var item in retailerProducts)
            {
                Assert.AreEqual(item.DateReceived, retailerProduct.DateReceived);
                Assert.AreEqual(item.ProductId, retailerProduct.ProductId);
                Assert.AreEqual(item.ProductName, retailerProduct.ProductName);
                Assert.AreEqual(item.RetailerName, retailerProduct.RetailerName);
                Assert.AreEqual(item.RetailerProductCode, retailerProduct.RetailerProductCode);
                Assert.AreEqual(item.RetailerProductCodeType, retailerProduct.RetailerProductCodeType);
            }
        }
    }
}
