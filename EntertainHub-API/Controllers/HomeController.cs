using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Utils;
using Data.Models.Content;

namespace EntertainHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly LibraryContext _dbContext;
        private readonly InfoApi _animeService;
        //public HomeController(LibraryContext dbContext)
        //{

        //    _dbContext = dbContext;
        //    _animeService = new(_dbContext);
        //}

        //[HttpGet]
        //[Route("GetAll")]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await _animeService.GetAll());
        //}

        //[HttpGet]
        //[Route("Get")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var data = await _animeService.Get(id);
        //    if (data != null)
        //    {
        //        return Ok(data);
        //    }
        //    return NotFound("Not found");
        //}

        //[HttpPost]
        //[Route("Insert")]
        //public async Task<IActionResult> Insert([FromBody] Anime anime)
        //{
        //    return Ok(await _animeService.Create(anime));
        //}

        //[HttpPut]
        //[Route("Update")]
        //public async Task<IActionResult> Update([FromBody] Anime anime)
        //{
        //    await _animeService.Update(anime);
        //    return NoContent();
        //}

        //[HttpDelete]
        //[Route("Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _animeService.Delete(id);
        //    return NoContent();
        //}
    }
}
