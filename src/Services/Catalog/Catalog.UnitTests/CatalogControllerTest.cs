using System;
using Training.BussinessLayer;
using Training.DataAccess;
using Xunit;
using Moq;
using Training.Entity;
using Amazon.S3;
using Amazon.S3.Model;
using System.Net;
using System.Threading;
using System.IO;

namespace Catalog.Unit.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void Get_Item_Found()
        {
           //Arrange
           Training.Entity.Catalog catalog = new Training.Entity.Catalog();
           catalog.Id = 1;
           catalog.Name = "toy";

           var repository = new Mock<ICatalogRepository>();           
           //var bussiness = new Mock<ICatalogBussinessService>();

           repository.Setup(x => x.Get(1)).ReturnsAsync(catalog);

           var service = new CatalogBussinessService(repository.Object);

           //Act
           var catalogres = await service.Get(1);
           
           //Assert
           Assert.True(catalog.Id == catalogres.Id);
        }

        [Fact]
        public async void Get_ItemAmazon_Found()
        {
           Training.Entity.Catalog catalog = new Training.Entity.Catalog();
           catalog.Id = 1;
           catalog.Name = "toy";
            
           var text = System.Text.Json.JsonSerializer.Serialize<Training.Entity.Catalog>(catalog);
           File.WriteAllText("1.json", text);

           var docStream = new FileInfo("1.json").OpenRead();

            var s3ClientMock= new Mock<IAmazonS3>();
            s3ClientMock.Setup(am => am.GetObjectAsync(
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<CancellationToken>())).
                ReturnsAsync((string bucket, string key, CancellationToken ct) =>
                new GetObjectResponse
                {
                BucketName = bucket,
                Key = key,
                HttpStatusCode = HttpStatusCode.OK,
                ResponseStream = docStream,
                });


               var result = await s3ClientMock.Object.GetObjectAsync("Test", "1.json");


                StreamReader reader = new StreamReader( result.ResponseStream );
                string text2 = reader.ReadToEnd();



        }

        
    }
}
