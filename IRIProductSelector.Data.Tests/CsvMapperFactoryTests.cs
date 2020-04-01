using IRIProductSelector.Data.CsvMappers;
using IRIProductSelector.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TinyCsvParser.Mapping;
using Moq;
using TinyCsvParser;

namespace IRIProductSelector.Data.Tests
{
    [TestClass]
    public class CsvMapperFactoryTests
    {
        private readonly ICsvMapperFactory _sut;

        public CsvMapperFactoryTests()
        {
            _sut = new CsvMapperFactory();
        }

        [TestMethod]
        public void GetCsvMapper_When_Valid_MapperType_ReturnsCsvMapper()
        {
            var resultProduct = _sut.GetCsvMapper<Product>();
            Assert.IsInstanceOfType(resultProduct, typeof(ICsvMapping<Product>));

            var resultRetailerProduct = _sut.GetCsvMapper<RetailerProduct>();
            Assert.IsInstanceOfType(resultRetailerProduct, typeof(ICsvMapping<RetailerProduct>));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetCsvMapper_When_InValid_MapperType_ThrowsException()
        {           
            _ = _sut.GetCsvMapper<object>();
        }

    }
}
