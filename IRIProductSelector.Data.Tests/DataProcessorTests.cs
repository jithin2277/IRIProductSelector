using IRIProductSelector.Data.Entities;
using IRIProductSelector.Data.Respositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRIProductSelector.Data.Tests
{
    [TestClass]
    public class DataProcessorTests
    {
        private Mock<IRepository<RetailerProduct>> _mockRetailerProductRepository;
        private Mock<IRepository<Product>> _mockProductRepository;
        private IDataProcessor _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRetailerProductRepository = new Mock<IRepository<RetailerProduct>>(MockBehavior.Strict);
            _mockProductRepository = new Mock<IRepository<Product>>(MockBehavior.Strict);
            _sut = new DataProcessor(_mockRetailerProductRepository.Object, _mockProductRepository.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockRetailerProductRepository.VerifyAll();
            _mockProductRepository.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_When_Parameters_AreNull_ThrowsException()
        {
            _ = new DataProcessor(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_When_RetailerProductRepo_IsNull_ThrowsException()
        {
            _ = new DataProcessor(null, _mockProductRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_When_ProductRepo_ISNull_ThrowsException()
        {
            _ = new DataProcessor(_mockRetailerProductRepository.Object, null);
        }

        [TestMethod]
        public void GetLatestDistinctRetailerProducts_GetsLatestDistinctRetailerProducts()
        {
            var product1 = new Product { 
                ProductId = "1",
                ProductName = "Foobar 1"
            };
            var product2 = new Product
            {
                ProductId = "2",
                ProductName = "Foobar 2"
            };

            var retailerProducts = new List<RetailerProduct> { 
                new RetailerProduct { 
                    DateReceived = new DateTime(2020, 4, 1),
                    ProductId = product1.ProductId,
                    RetailerName = "Foobar 1",
                    RetailerProductCode = "Code 1",
                    RetailerProductCodeType = "Barcode"
                },
                new RetailerProduct {
                    DateReceived = new DateTime(2019, 3, 31),
                    ProductId = product1.ProductId,
                    RetailerName = "Foobar 2",
                    RetailerProductCode = "Code 1",
                    RetailerProductCodeType = "Refno"
                },
                new RetailerProduct {
                    DateReceived = new DateTime(2019, 1, 1),
                    ProductId = product1.ProductId,
                    RetailerName = "Foobar 3",
                    RetailerProductCode = "Code 1",
                    RetailerProductCodeType = "Barcode"
                },
                new RetailerProduct {
                    DateReceived = new DateTime(2018, 1, 1),
                    ProductId = product2.ProductId,
                    RetailerName = "Foobar 3",
                    RetailerProductCode = "Code 1",
                    RetailerProductCodeType = "BarCode"
                },
                new RetailerProduct {
                    DateReceived = new DateTime(2017, 1, 1),
                    ProductId = product2.ProductId,
                    RetailerName = "Foobar 4",
                    RetailerProductCode = "Code 1",
                    RetailerProductCodeType = "Refno"
                },
                new RetailerProduct {
                    DateReceived = new DateTime(2017, 1, 1),
                    ProductId = product2.ProductId,
                    RetailerName = "Foobar 4",
                    RetailerProductCode = "Code 1",
                    RetailerProductCodeType = "BarCode"
                }
            };

            _mockRetailerProductRepository.Setup(s => s.GetAll()).Returns(retailerProducts);
            _mockProductRepository.Setup(s => s.GetById(product1.ProductId)).Returns(product1);
            _mockProductRepository.Setup(s => s.GetById(product2.ProductId)).Returns(product2);

            var result = _sut.GetLatestDistinctRetailerProducts();

            Assert.IsTrue(result.Count == 4);
        }
    }
}
