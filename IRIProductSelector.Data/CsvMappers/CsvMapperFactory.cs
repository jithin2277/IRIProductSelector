using IRIProductSelector.Data.CsvMappers;
using IRIProductSelector.Data.Entities;
using System;
using System.Runtime.CompilerServices;
using TinyCsvParser.Mapping;

[assembly: InternalsVisibleTo("IRIProductSelector.Data.Tests")]
namespace IRIProductSelector.Data.CsvMappers
{
    public interface ICsvMapperFactory
    {
        ICsvMapping<TEntity> GetCsvMapper<TEntity>();
    }

    public class CsvMapperFactory : ICsvMapperFactory
    {
        public ICsvMapping<TEntity> GetCsvMapper<TEntity>()
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return (ICsvMapping<TEntity>)new CsvProductMapping();
            }
            else if (typeof(TEntity) == typeof(RetailerProduct))
            {
                return (ICsvMapping<TEntity>)new CsvRetailerProductMapping();
            }

            throw new InvalidOperationException();
        }
    }
}
