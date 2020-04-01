using IRIProductSelector.Data.Entities;
using IRIProductSelector.Data.Models;
using IRIProductSelector.Data.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRIProductSelector.Data
{
    public interface IDataProcessor
    {
        IList<RetailerProductResponse> GetLatestDistinctRetailerProducts();
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

        public IList<RetailerProductResponse> GetLatestDistinctRetailerProducts()
        {
            var result = new List<RetailerProductResponse>();

            var groupedProducts = _retailerProductRepository
                .GetAll()
                .GroupBy(g => g.ProductId)
                .Select(s => s.ToList());

            foreach (var groupedProduct in groupedProducts)
            {
                var groupedCodeTypes = groupedProduct
                    .GroupBy(g => g.RetailerProductCodeType)
                    .Select(s => s.ToList());

                foreach (var groupedCodeType in groupedCodeTypes)
                {
                    var latestCodeType = groupedCodeType.OrderByDescending(o => o.DateReceived).FirstOrDefault();
                    
                    result.Add(new RetailerProductResponse { 
                        Code = latestCodeType.RetailerProductCode, 
                        CodeType = latestCodeType.RetailerProductCodeType, 
                        ProductId = latestCodeType.ProductId, 
                        ProductName = _productRepository.GetById(latestCodeType.ProductId).ProductName 
                    });
                }
            }

            return result;
        }
    }
}
