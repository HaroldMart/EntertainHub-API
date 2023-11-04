using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Models.Content;
using Repository.Services;

namespace EntertainHub_API.Controllers
{
    [Route("entertainHubApi/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly SerieService _serieService;
        public SerieController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
            _serieService = new(_dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_serieService.GetAll());
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var data = _serieService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("Not found");
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromBody] Serie serie)
        {
            return Ok(await _serieService.Create(serie));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Serie serie)
        {
            await _serieService.Update(serie);
            return Ok("Updated");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serieService.Delete(id);
            return Ok("Deleted!");
        }
    }
}
