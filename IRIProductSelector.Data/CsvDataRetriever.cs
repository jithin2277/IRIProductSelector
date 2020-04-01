using IRIProductSelector.Data.CsvMappers;
using IRIProductSelector.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;

namespace IRIProductSelector.Data
{
    public class CsvDataRetriever<T> : IDataRetriever<T>
    {
        private readonly ICsvParserAdapter<T> _csvParserAdapter;
        private readonly string _csvFilePath;

        public CsvDataRetriever(ICsvParserAdapter<T> csvParserAdapter, string csvFilePath)
        {
            _csvParserAdapter = csvParserAdapter ?? throw new ArgumentNullException(nameof(csvParserAdapter));
            _csvFilePath = csvFilePath ?? throw new ArgumentNullException(nameof(csvFilePath));
        }

        public IList<T> GetResults()
        {
            return _csvParserAdapter.ReadFromFile(_csvFilePath);
        }
    }
}
