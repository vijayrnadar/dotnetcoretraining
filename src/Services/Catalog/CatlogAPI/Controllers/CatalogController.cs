using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Training.BussinessLayer;
using Training.Entity;

namespace Training.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ICatalogBussinessService m_catalogBussinessService;

        public CatalogController(ILogger<CatalogController> logger, ICatalogBussinessService catalogBussinessService)
        {
            _logger = logger;
            m_catalogBussinessService = catalogBussinessService;
        }

        [HttpGet]
        [Route("{Id?}")]
        public async Task<Catalog> Get(int? Id)
        {
            return await m_catalogBussinessService.Get(Id.Value); 
        }

       [HttpGet]
        public async Task<IEnumerable<Catalog>> GetAll()
        {
            return await m_catalogBussinessService.GetAll(); 
        }
    }
}
