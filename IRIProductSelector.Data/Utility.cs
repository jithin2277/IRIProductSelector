
using IRIProductSelector.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRIProductSelector.Data
{
    public static class Utility
    {
        public static string GetCsvFile(Type type)
        {
            if (type == typeof(Product))
            {
                return "data/IRIProducts.csv";
            }
            else if (type == typeof(RetailerProduct))
            {
                return "data/RetailerProducts.csv";
            }

            return null;
        }
           
    }
}
