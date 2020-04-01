using System;
using System.Collections.Generic;
using System.Text;

namespace IRIProductSelector.Data.Entities
{
    public class RetailerProduct
    {
        public string ProductId { get; set; }
        public string RetailerName { get; set; }
        public string RetailerProductCode { get; set; }
        public string RetailerProductCodeType { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
