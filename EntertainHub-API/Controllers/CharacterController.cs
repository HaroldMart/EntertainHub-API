using Data.Models.Content;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Repository.Services;

namespace EntertainHub_API.Controllers
{
    [Route("entertainHubApi/[controller]")]
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
        public IActionResult GetAll()
        {
            return Ok(_characterService.GetAll());
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var data = _characterService.Get(id);
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
            return Ok("Updated");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _characterService.Delete(id);
            return Ok("Deleted!");
        }
    }
}
