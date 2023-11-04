using Data;
using Data.Models.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Services;

namespace EntertainHub_API.Controllers
{
    [Route("entertainHubApi/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly AnimeService _animeService;
        public AnimeController(LibraryContext dbContext) {

            _dbContext = dbContext;
            _animeService = new(_dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_animeService.GetAll());
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var data = _animeService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("Not found");
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromBody] Anime anime)
        {
            return Ok(await _animeService.Create(anime));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Anime anime)
        {
            await _animeService.Update(anime);
            return Ok("Updated");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _animeService.Delete(id);
            return Ok("Deleted!");
        }
    }
}
