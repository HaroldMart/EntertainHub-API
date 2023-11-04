using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Models.Content;
using Repository.Services;

namespace EntertainHub_API.Controllers
{
    [Route("entertainHubApi/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly ComicService _comicService;
        public ComicController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
            _comicService = new(_dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_comicService.GetAll());
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = _comicService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("Not found");
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromBody] Comic comic)
        {
            return Ok(await _comicService.Create(comic));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Comic comic)
        {
            await _comicService.Update(comic);
            return Ok("Updated");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _comicService.Delete(id);
            return Ok("Deleted!");
        }
    }
}
