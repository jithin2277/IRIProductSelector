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
        private Mock<ICsvParserAdapter<FooBar>> _mockCsvParserAdapter;
        private string _csvFilePath = "Foo";
        private IDataRetriever<FooBar> _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockCsvParserAdapter = new Mock<ICsvParserAdapter<FooBar>>(MockBehavior.Strict);
            _sut = new CsvDataRetriever<FooBar>(_mockCsvParserAdapter.Object, _csvFilePath);
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
            _ = new CsvDataRetriever<FooBar>(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_When_ParserAdapterIsNull_ThrowsException()
        {
            _ = new CsvDataRetriever<FooBar>(null, _csvFilePath);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_When_CsvFilePathIsNull_ThrowsException()
        {
            _ = new CsvDataRetriever<FooBar>(_mockCsvParserAdapter.Object, null);
        }

        [TestMethod]
        public void GetResults_Succeeds()
        {
            var expected = new List<FooBar>() 
            {
                new FooBar() { Foo = "Foo", Bar = "Bar"},
                new FooBar() { Foo = "test", Bar = "test"}
            };

            _mockCsvParserAdapter.Setup(s => s.ReadFromFile(_csvFilePath)).Returns(expected);

            var actual = _sut.GetResults();

            Assert.AreEqual(expected, actual);
        }

        public class FooBar
        {
            public string Foo { get; set; }
            public string Bar { get; set; }
        }
    }
}
