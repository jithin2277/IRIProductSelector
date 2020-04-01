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
    public class ProductRepositoryTests
    {
        private Mock<IDataRetriever<Product>> _mockDataRetriever;
        private IRepository<Product> _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDataRetriever = new Mock<IDataRetriever<Product>>(MockBehavior.Strict);
            _sut = new ProductRepository(_mockDataRetriever.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockDataRetriever.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_WhenDataRetriever_IsNull_ThrowsException()
        {
            _ = new ProductRepository(null);
        }

        [TestMethod]
        public void GetAll_GetsAllProducts()
        {
            var expected = new List<Product> {
                new Product { ProductId = "1", ProductName = "Foo"},
                new Product { ProductId = "2", ProductName = "Bar"}
            };

            _mockDataRetriever.Setup(s => s.GetResults()).Returns(expected);

            var actual = _sut.GetAll();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetById_GetsProductById()
        {
            var product = new Product { ProductId = "1", ProductName = "Foo" };
            var products = new List<Product> {
                product
            };

            _mockDataRetriever.Setup(s => s.GetResults()).Returns(products);

            var actual = _sut.GetById(product.ProductId);

            Assert.AreEqual(product, actual);
        }
    }
}
