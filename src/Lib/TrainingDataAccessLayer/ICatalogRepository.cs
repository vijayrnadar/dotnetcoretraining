using System;
using Training.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Training.DataAccess
{
    public interface ICatalogRepository
    {
        Task<Catalog> Get(int catalogId);
        Task<IEnumerable<Catalog>> GetAll();
    }
}
