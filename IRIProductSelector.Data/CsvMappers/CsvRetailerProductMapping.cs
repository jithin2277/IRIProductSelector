using IRIProductSelector.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace IRIProductSelector.Data.CsvMappers
{
    public class CsvRetailerProductMapping : CsvMapping<RetailerProduct>
    {
        public CsvRetailerProductMapping() 
            : base()
        {
            MapProperty(0, x => x.ProductId);
            MapProperty(1, x => x.RetailerName);
            MapProperty(2, x => x.RetailerProductCode);
            MapProperty(3, x => x.RetailerProductCodeType);
            MapProperty(4, x => x.DateReceived);
        }
    }
}
