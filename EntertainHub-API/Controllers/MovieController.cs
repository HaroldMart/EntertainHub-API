using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Models.Content;
using Repository.Services;

namespace EntertainHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly MovieService _movieService;
        public MovieController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
            _movieService = new(_dbContext);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _movieService.GetAll());
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _movieService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("Not found");
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromBody] Movie movie)
        {
            return Ok(await _movieService.Create(movie));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Movie movie)
        {
            await _movieService.Update(movie);
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.Delete(id);
            return NoContent();
        }
    }
}
