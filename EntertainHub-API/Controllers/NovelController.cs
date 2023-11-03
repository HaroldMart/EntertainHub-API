using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Models.Content;
using Repository.Services;

namespace EntertainHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovelController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly NovelService _novelService;
        public NovelController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
            _novelService = new(_dbContext);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _novelService.GetAll());
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _novelService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("Not found");
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromBody] Novel novel)
        {
            return Ok(await _novelService.Create(novel));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Novel novel)
        {
            await _novelService.Update(novel);
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _novelService.Delete(id);
            return NoContent();
        }
    }
}
