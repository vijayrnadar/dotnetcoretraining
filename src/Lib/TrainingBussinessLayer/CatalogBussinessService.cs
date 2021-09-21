using System;
using Training.Entity;
using Training.DataAccess;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Training.BussinessLayer
{
    public class CatalogBussinessService: ICatalogBussinessService
    {
        private ICatalogRepository m_catalogRepository;

        public CatalogBussinessService(ICatalogRepository repository)
        {
          m_catalogRepository = repository;
        }

         public async Task<Catalog> Get(int catalogId)
         {
            return await m_catalogRepository.Get(catalogId);
         }

         public async Task<IEnumerable<Catalog>> GetAll()
         {
            return await m_catalogRepository.GetAll();
         }
    }
}
