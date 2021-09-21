using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Entity;

namespace Training.BussinessLayer
{
    public interface ICatalogBussinessService
    {
        Task<Catalog> Get(int catalogId);
        Task<IEnumerable<Catalog>> GetAll();
    }
}
