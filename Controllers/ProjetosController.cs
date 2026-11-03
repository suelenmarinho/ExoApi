
using Exo.WebApi.Repositories;
using Exo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetosController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_projetoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            _projetoRepository.Cadastrar(projeto);
            return StatusCode(201, projeto);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            _projetoRepository.Atualizar(id, projeto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _projetoRepository.Deletar(id);
            return NoContent();
        }
    }
}
