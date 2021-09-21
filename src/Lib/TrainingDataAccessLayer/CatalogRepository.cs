using System;
using Training.Entity;
using System.Linq;
using System.Collections.Generic;
using Training.Helpers;
using System.Threading.Tasks;
using System.IO;

namespace Training.DataAccess
{
    public class CatalogRepository : ICatalogRepository
    {
        private IAWSS3FileRepository m_awsRepository;
        public CatalogRepository(IAWSS3FileRepository awsRepository )
        {
          m_awsRepository = awsRepository;
            
        }

        public async Task<Catalog> Get(int catalogId)
        {
           Stream stream = await m_awsRepository.GetFile(catalogId.ToString() + ".json");

            StreamReader reader = new StreamReader( stream );
            string text = reader.ReadToEnd();

            Catalog catalog =  System.Text.Json.JsonSerializer.Deserialize<Catalog>(text);
            return catalog;
        } 

        public async Task<IEnumerable<Catalog>> GetAll()
        {
           List<string> files =  await m_awsRepository.FilesList();
           List<Catalog> lstCatalog = new List<Catalog>();
           foreach(var fileName in files)
           {
             Stream stream = await m_awsRepository.GetFile(fileName);

             StreamReader reader = new StreamReader( stream );
             string text = reader.ReadToEnd();

            Catalog catalog =  System.Text.Json.JsonSerializer.Deserialize<Catalog>(text);
            lstCatalog.Add(catalog);
           }
           
           return lstCatalog;
        } 

       
    }
}
