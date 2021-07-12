using Diego.Redis.WebApi.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Diego.Redis.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        private readonly ITrajetoPrevistoRepository _trajetoPrevistoRepository;

        public HomeController(ITrajetoPrevistoRepository trajetoPrevistoRepository)
        {
            _trajetoPrevistoRepository = trajetoPrevistoRepository;
        }



        [HttpGet]
        public IActionResult Get()
        {
            using var db = new Context.ApiDbContext();

            //Console.WriteLine("Criando a base ==============================");

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            _trajetoPrevistoRepository.PopularTabela();

            return Ok();
        }
    }
}
