using Diego.Redis.WebApi.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get()
        {
            using var db = new Context.ApiDbContext();

            //Console.WriteLine("Criando a base ==============================");

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            await Task.WhenAll(_trajetoPrevistoRepository.PopularTabela(),
            _trajetoPrevistoRepository.PopularTabela(),
            _trajetoPrevistoRepository.PopularTabela(),
            _trajetoPrevistoRepository.PopularTabela(),
            _trajetoPrevistoRepository.PopularTabela(),
            _trajetoPrevistoRepository.PopularTabela(),
            _trajetoPrevistoRepository.PopularTabela(),
            _trajetoPrevistoRepository.PopularTabela(),
            _trajetoPrevistoRepository.PopularTabela()
            );

            return Ok();
        }

        [HttpGet("trajeto/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var trajeto = await _trajetoPrevistoRepository.ObterTrajetoPorId(id);
            return Ok(trajeto);
        }

        [HttpGet("trajetos/paradas/adicionar/{id}")]
        public async Task<IActionResult> AdicionarParadas(Guid id)
        {
            var trajeto = await _trajetoPrevistoRepository.AdicionarListaParadas(id);
            return Ok(trajeto);
        }

        [HttpGet("trajetos/paradas/obter/{id}")]
        public IActionResult ObterParadasAdicionadas(Guid id)
        {
            var trajeto = _trajetoPrevistoRepository.ObterListaDEParadas(id);
            return Ok(trajeto);
        }

        [HttpGet("obter/keys/{filtro}")]
        public IActionResult ObterKeys(string filtro)
        {
            var keys = _trajetoPrevistoRepository.ObterKeys(filtro); return Ok(keys);

        }

    }
}
