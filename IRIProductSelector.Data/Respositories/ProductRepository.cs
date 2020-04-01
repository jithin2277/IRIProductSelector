using IRIProductSelector.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRIProductSelector.Data.Respositories
{
    public class ProductRepository : IRepository<Product>
    {
        private IDataRetriever<Product> _dataRetriever;

        public ProductRepository(IDataRetriever<Product> dataRetriever)
        {
            _dataRetriever = dataRetriever ?? throw new ArgumentNullException(nameof(dataRetriever));
        }

        public IList<Product> GetAll()
        {
            return _dataRetriever.GetResults();
        }

        public Product GetById(string id)
        {
            return GetAll()
                .Where(w => w.ProductId == id).FirstOrDefault();
        }
    }
}
