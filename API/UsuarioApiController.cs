using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.API
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioApiController : ControllerBase
    {

        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioApiController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        // buscar todos os usuarios cadastrados
        [HttpGet]
        public IActionResult Listar()
        { 
            var usuarios = _usuarioRepository.Listar();
            return Ok(usuarios);
        }


        // buscar usuario por id
        [HttpGet("{id}")]
        public IActionResult ObterPorId(long id)
        {
            Usuario usuario = _usuarioRepository.ObterPorId(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado");

            return Ok(usuario);
        }


        // cadastrar um usuario
        [HttpPost]
        public IActionResult Cadastrar(UsuarioDTO usuario)
        {
            Usuario usuarioCriado = _usuarioRepository.Criar(usuario);
            if (usuarioCriado != null)
                return StatusCode(201, usuarioCriado);

            return StatusCode(500, "Erro ao criar o usuario");
        }


        // remover um usuario
        [HttpDelete]
        public IActionResult Remover(long id)
        {
            bool removido = _usuarioRepository.Remover(id);
            if (removido)
                return Ok("Usuario removido com sucesso");

            return StatusCode(404,"Usuario não encontrado para remover");
        }

    }
}
