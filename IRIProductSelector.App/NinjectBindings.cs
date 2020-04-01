using IRIProductSelector.Data;
using IRIProductSelector.Data.CsvMappers;
using IRIProductSelector.Data.Entities;
using IRIProductSelector.Data.Respositories;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser;

namespace IRIProductSelector.App
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICsvMapperFactory>().To<CsvMapperFactory>();
            var csvParserOptions = new CsvParserOptions(false, ',');
            var csvMapper = Kernel.Get<ICsvMapperFactory>();

            var csvParserProduct = new CsvParser<Product>(csvParserOptions, csvMapper.GetCsvMapper<Product>());
            var csvParserRetailerProduct = new CsvParser<RetailerProduct>(csvParserOptions, csvMapper.GetCsvMapper<RetailerProduct>());

            Bind<ICsvParserAdapter<Product>>().To<CsvParserAdapter<Product>>().WithConstructorArgument(csvParserProduct);
            Bind<IDataRetriever<Product>>().To<CsvDataRetriever<Product>>().WithConstructorArgument("csvFilePath", "data/IRIProducts.txt");
            Bind<IRepository<Product>>().To<ProductRepository>();

            Bind<ICsvParserAdapter<RetailerProduct>>().To<CsvParserAdapter<RetailerProduct>>().WithConstructorArgument(csvParserRetailerProduct);
            Bind<IDataRetriever<RetailerProduct>>().To<CsvDataRetriever<RetailerProduct>>().WithConstructorArgument("csvFilePath", "data/RetailerProducts.txt");
            Bind<IRepository<RetailerProduct>>().To<RetailerProductRepository>();

            Bind<IDataProcessor>().To<DataProcessor>();
        }
    }
}
