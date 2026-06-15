using Microsoft.AspNetCore.Mvc;
using WebAPI.Repository;

namespace WebAPI.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioAPIController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioAPIController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        { 
            var usuarios = _usuarioRepository.Listar();
            return Ok(usuarios);
        }
    }
}
