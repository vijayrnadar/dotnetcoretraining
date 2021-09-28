using System;
using Training.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Options;
using Amazon.S3;
using Training.Models;
using Amazon.S3.Model;

namespace Training.DataAccess
{
    public class CatalogRepository : ICatalogRepository
    {
        private ServiceConfiguration _settings;
        private IAmazonS3 _amazonS3;

        public CatalogRepository(IAmazonS3 s3Client, IOptions<ServiceConfiguration> settings)
        {
          this._settings = settings.Value;
          //this._amazonS3 = new AmazonS3Client(this._settings.AWSS3.AccessKey, this._settings.AWSS3.SecretKey, RegionEndpoint.USEast1);
          
            
        }



        public async Task<Catalog> Get(int catalogId)
        {
            GetObjectResponse response = await _amazonS3.GetObjectAsync(_settings.AWSS3.BucketName, catalogId.ToString() + ".json");  
            Stream stream;
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)  
                stream = response.ResponseStream;  
            else  
                return null;  
            
            StreamReader reader = new StreamReader( stream );
            string text = reader.ReadToEnd();

            Catalog catalog =  System.Text.Json.JsonSerializer.Deserialize<Catalog>(text);
            return catalog;
        } 

        public async Task<IEnumerable<Catalog>> GetAll()
        {
           ListVersionsResponse listVersions = await _amazonS3.ListVersionsAsync(_settings.AWSS3.BucketName);  
           List<string> files = listVersions.Versions.Select(c => c.Key).ToList(); 
           List<Catalog> lstCatalog = new List<Catalog>();
           foreach(var fileName in files)
           {
             Catalog catalog = await this.Get(int.Parse(fileName.Replace(".json", string.Empty)));

            
              lstCatalog.Add(catalog);
           }
           
           return lstCatalog;
        } 

       
    }
}
