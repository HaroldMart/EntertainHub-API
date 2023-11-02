using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace EntertainHub_API.Controllers
{
    [Route("entertainHubApi/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly Services<Anime> _animeService;
        public AnimeController(LibraryContext dbContext) {

            _dbContext = dbContext;
            _animeService = new(_dbContext);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _animeService.GetAll());
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _animeService.Get(id);
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
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _animeService.Delete(id);
            return NoContent();
        }
    }
}
