using System;
using Training.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Training.DataAccess
{
/*    public class MockCatalogRepository : ICatalogRepository
    {
        public readonly  List<Catalog> m_Catalogs;

        public CatalogRepository(IAWSS3BucketHelper Aw )
        {
            m_Catalogs = new List<Catalog>();

            Catalog catalog = new Catalog();
            catalog.Id = 1;
            catalog.Name = "Toy";
            catalog.CreateAt = new DateTime(2021, 1, 1);
            m_Catalogs.Add(catalog); 

            catalog = new Catalog();
            catalog.Id = 2;
            catalog.Name = "Bike";
            catalog.CreateAt = new DateTime(2021, 1, 1);
            m_Catalogs.Add(catalog); 

            catalog = new Catalog();
            catalog.Id = 3;
            catalog.Name = "Car";
            catalog.CreateAt = new DateTime(2021, 1, 1);
            m_Catalogs.Add(catalog); 

            catalog = new Catalog();
            catalog.Id = 4;
            catalog.Name = "Electronics";
            catalog.CreateAt = new DateTime(2021, 1, 1);
            m_Catalogs.Add(catalog); 

            catalog = new Catalog();
            catalog.Id = 5;
            catalog.Name = "Games";
            catalog.CreateAt = new DateTime(2021, 1, 1);
            m_Catalogs.Add(catalog); 
            
        }

        public Task<Catalog> Get(int catalogId)
        {
           return m_Catalogs.FirstOrDefault(x => x.Id == catalogId);
        } 
    }*/
}
