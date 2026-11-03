
using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var usuarioEncontrado = _usuarioRepository.Login(
                usuario.Email, usuario.Senha);

            if (usuarioEncontrado == null)
            {
                return Unauthorized("Email ou senha inválidos.");
            }

            return Ok(new
            {
                mensagem = "Login realizado com sucesso!",
                id = usuarioEncontrado.Id,
                email = usuarioEncontrado.Email
            });
        }
    }
}
