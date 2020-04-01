using IRIProductSelector.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace IRIProductSelector.Data.CsvMappers
{
    public class CsvProductMapping : CsvMapping<Product>, ICsvMapping<Product>
    {
        public CsvProductMapping() : base()
        {
            MapProperty(0, x => x.ProductId);
            MapProperty(1, x => x.ProductName);
        }
    }
}
