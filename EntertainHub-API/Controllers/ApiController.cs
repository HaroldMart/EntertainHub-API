using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Utils;
using Data.Models.Content;
using Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EntertainHub_API.Controllers
{
    [Route("entertainHubApi/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly InfoApi _infoApi;

        public ApiController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
            _infoApi = new(_dbContext);
        }

        [HttpGet]
        public IActionResult Home()
        {
            var count = _infoApi.CountData();
            var urls = _infoApi.ListEndpoints();
            var methods = _infoApi.ListMethods();
            var schemas = _infoApi.ListSchemas();

            return Ok(_infoApi.GenerateJson(count, urls, methods, schemas));
        }
    }
}
