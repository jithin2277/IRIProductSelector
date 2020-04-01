using IRIProductSelector.Data.Entities;
using IRIProductSelector.Data.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRIProductSelector.Data
{
    public interface IDataProcessor
    {
        IList<RetailerProduct> GetDistinctRetailerProducts();
    }

    public class DataProcessor : IDataProcessor
    {
        private readonly IRepository<RetailerProduct> _retailerProductRepository;
        private readonly IRepository<Product> _productRepository;

        public DataProcessor(IRepository<RetailerProduct> retailerProductRepository, IRepository<Product> productRepository)
        {
            _retailerProductRepository = retailerProductRepository ?? throw new ArgumentNullException(nameof(retailerProductRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public IList<RetailerProduct> GetDistinctRetailerProducts()
        {
            var retailerProducts = _retailerProductRepository.GetAll().ToList();
            return retailerProducts;
        }
    }
}
