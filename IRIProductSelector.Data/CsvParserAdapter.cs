using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;

namespace IRIProductSelector.Data
{
    public interface ICsvParserAdapter<T>
    {
        IList<T> ReadFromFile(string filePath);
    }

    public class CsvParserAdapter<T> : ICsvParserAdapter<T>
    {
        private readonly CsvParser<T> _csvParser;

        public CsvParserAdapter(CsvParser<T> csvParser)
        {
            _csvParser = csvParser ?? throw new ArgumentNullException(nameof(csvParser));
        }

        public IList<T> ReadFromFile(string filePath)
        {
            return _csvParser
                .ReadFromFile(filePath, Encoding.ASCII)
                .Where(w => w.IsValid)
                .Select(s => s.Result)
                .ToList();
        }
    }
}
