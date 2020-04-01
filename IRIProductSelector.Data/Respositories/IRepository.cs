using System;
using System.Collections.Generic;
using System.Text;

namespace IRIProductSelector.Data.Respositories
{
    public interface IRepository<T>
    {
        IList<T> GetAll();

        T GetById(string id);
    }
}
