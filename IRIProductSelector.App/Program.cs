using IRIProductSelector.Data;
using IRIProductSelector.Data.CsvMappers;
using IRIProductSelector.Data.Entities;
using IRIProductSelector.Data.Respositories;
using Ninject;
using System;
using TinyCsvParser;

namespace IRIProductSelector.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();

            kernel.Bind<ICsvMapperFactory>().To<CsvMapperFactory>();
            var csvParserOptions = new CsvParserOptions(false, ',');
            var csvMapper = kernel.Get<ICsvMapperFactory>();
            
            var csvParserProduct = new CsvParser<Product>(csvParserOptions, csvMapper.GetCsvMapper<Product>());
            var csvParserRetailerProduct = new CsvParser<RetailerProduct>(csvParserOptions, csvMapper.GetCsvMapper<RetailerProduct>());

            kernel.Bind<ICsvParserAdapter<Product>>().To<CsvParserAdapter<Product>>().WithConstructorArgument(csvParserProduct);
            kernel.Bind<IDataRetriever<Product>>().To<CsvDataRetriever<Product>>().WithConstructorArgument("csvFilePath", "data/IRIProducts.csv");
            kernel.Bind<IRepository<Product>>().To<ProductRepository>();

            kernel.Bind<ICsvParserAdapter<RetailerProduct>>().To<CsvParserAdapter<RetailerProduct>>().WithConstructorArgument(csvParserRetailerProduct);
            kernel.Bind<IDataRetriever<RetailerProduct>>().To<CsvDataRetriever<RetailerProduct>>().WithConstructorArgument("csvFilePath", "data/RetailerProducts.csv");
            kernel.Bind<IRepository<RetailerProduct>>().To<RetailerProductRepository>();

            kernel.Bind<IDataProcessor>().To<DataProcessor>();

            var dataProcessor = kernel.Get<IDataProcessor>();

            var temp = dataProcessor.GetDistinctRetailerProducts();

            Console.WriteLine("Hello world");
        }
    }
}
