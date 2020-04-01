using IRIProductSelector.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IRIProductSelector.Data.Respositories
{
    public class RetailerProductRepository : IRepository<RetailerProduct>
    {
        private readonly IDataRetriever<RetailerProduct> _dataRetriever;
        private readonly IRepository<Product> _productRepository;

        public RetailerProductRepository(IDataRetriever<RetailerProduct> dataRetriever, IRepository<Product> productRepository)
        {
            _dataRetriever = dataRetriever ?? throw new ArgumentNullException(nameof(dataRetriever));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public IList<RetailerProduct> GetAll()
        {
            return _dataRetriever.GetResults().Select(item => new RetailerProduct() {
                DateReceived = item.DateReceived,
                ProductId = item.ProductId,
                ProductName = _productRepository.GetById(item.ProductId).ProductName,
                RetailerName = item.RetailerName,
                RetailerProductCode = item.RetailerProductCode,
                RetailerProductCodeType = item.RetailerProductCodeType
            }).ToList();
        }

        public RetailerProduct GetById(string id)
        {
            return GetAll()
                .Where(w => w.ProductId == id).FirstOrDefault();
        }
    }
}
