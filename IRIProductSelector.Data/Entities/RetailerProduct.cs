﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IRIProductSelector.Data.Entities
{
    public class RetailerProduct
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string RetailerName { get; set; }
        public string RetailerProductCode { get; set; }
        public string RetailerProductCodeType { get; set; }
        public string DateReceived { get; set; }
    }
}