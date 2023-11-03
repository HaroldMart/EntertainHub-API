using Data.Models.Content;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Repository.Services;

namespace EntertainHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly CharacterService _characterService;
        public CharacterController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
            _characterService = new(_dbContext);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _characterService.GetAll());
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _characterService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("Not found");
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert([FromBody] Character character)
        {
            return Ok(await _characterService.Create(character));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Character character)
        {
            await _characterService.Update(character);
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _characterService.Delete(id);
            return NoContent();
        }
    }
}
