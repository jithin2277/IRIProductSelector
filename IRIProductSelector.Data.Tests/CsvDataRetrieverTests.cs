using IRIProductSelector.Data.CsvMappers;
using IRIProductSelector.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TinyCsvParser.Mapping;
using Moq;
using TinyCsvParser;
using System.Collections.Generic;

namespace IRIProductSelector.Data.Tests
{
    [TestClass]
    public class CsvDataRetrieverTests
    {
        private Mock<ICsvParserAdapter<TestClass>> _mockCsvParserAdapter;
        private string _csvFilePath = "Foo";
        private IDataRetriever<TestClass> _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockCsvParserAdapter = new Mock<ICsvParserAdapter<TestClass>>(MockBehavior.Strict);
            _sut = new CsvDataRetriever<TestClass>(_mockCsvParserAdapter.Object, _csvFilePath);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockCsvParserAdapter.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_When_ParametersAreNull_ThrowsException()
        {
            _ = new CsvDataRetriever<TestClass>(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_When_ParserAdapterIsNull_ThrowsException()
        {
            _ = new CsvDataRetriever<TestClass>(null, _csvFilePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_When_CsvFilePathIsNull_ThrowsException()
        {
            _ = new CsvDataRetriever<TestClass>(_mockCsvParserAdapter.Object, null);
        }

        [TestMethod]
        public void GetResults_Succeeds()
        {
            var expected = new List<TestClass>() 
            {
                new TestClass() { Foo = "Foo", Bar = "Bar"},
                new TestClass() { Foo = "test", Bar = "test"}
            };

            _mockCsvParserAdapter.Setup(s => s.ReadFromFile(_csvFilePath)).Returns(expected);

            var actual = _sut.GetResults();

            Assert.AreEqual(expected, actual);
        }
               
    }
}
