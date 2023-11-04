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
    public class HomeController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly InfoApi _infoApi;

        public HomeController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
            _infoApi = new(_dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var count = _infoApi.CountData();
            var urls = _infoApi.ListEndpoints();
            var methods = _infoApi.ListMethods();

            return Ok(_infoApi.GenerateJson(count, urls, methods));
        }
    }
}
