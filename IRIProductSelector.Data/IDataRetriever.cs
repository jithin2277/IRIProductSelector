using System;
using System.Collections.Generic;

namespace IRIProductSelector.Data
{
    public interface IDataRetriever<T>
    {
        IList<T> GetResults();
    }
}
