using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Models.Content;
using Repository.Services;

namespace EntertainHub_API.Controllers
{
    [Route("entertainHubApi/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly MangaService _mangaService;
        public MangaController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
            _mangaService = new(_dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mangaService.GetAll());
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get(int id)
        {
            var data = _mangaService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("Not found");
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromBody] Manga manga)
        {
            return Ok(await _mangaService.Create(manga));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Manga manga)
        {
            await _mangaService.Update(manga);
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mangaService.Delete(id);
            return NoContent();
        }
    }
}
