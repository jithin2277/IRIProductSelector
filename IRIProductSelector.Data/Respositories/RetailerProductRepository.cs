using IRIProductSelector.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IRIProductSelector.Data.Respositories
{
    public class RetailerProductRepository : IRepository<RetailerProduct>
    {
        private readonly IDataRetriever<RetailerProduct> _dataRetriever;

        public RetailerProductRepository(IDataRetriever<RetailerProduct> dataRetriever)
        {
            _dataRetriever = dataRetriever ?? throw new ArgumentNullException(nameof(dataRetriever));
        }

        public IList<RetailerProduct> GetAll()
        {
            return _dataRetriever.GetResults();
        }

        public RetailerProduct GetById(string id)
        {
            return GetAll()
                .Where(w => w.ProductId == id).FirstOrDefault();
        }
    }
}
