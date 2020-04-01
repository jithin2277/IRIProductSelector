using IRIProductSelector.Data;
using IRIProductSelector.Data.CsvMappers;
using IRIProductSelector.Data.Entities;
using IRIProductSelector.Data.Respositories;
using Ninject;
using System;
using System.Reflection;
using TinyCsvParser;

namespace IRIProductSelector.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new NinjectBindings());
            
            var dataProcessor = kernel.Get<IDataProcessor>();
            var retailerProducts = dataProcessor.GetLatestDistinctRetailerProducts();

            Console.WriteLine("ProductId,ProductName,CodeType,Code");
            foreach (var retailerProduct in retailerProducts)
            {
                Console.WriteLine($"{retailerProduct.ProductId},{retailerProduct.ProductName},{retailerProduct.CodeType},{retailerProduct.Code}");
            }
            Console.ReadLine();
        }
    }
}
