using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    public class UsuarioController : Controller
    {
        
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _usuarioRepository.Listar();
            return View(lista);
        }


        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(UsuarioDTO usuario)
        {
            Usuario usuarioCriado = _usuarioRepository.Criar(usuario);

            if (usuarioCriado != null)
                return RedirectToAction("Listar");

            return View("Cadastrar");
        }


        [HttpGet]
        public IActionResult Editar(long id)
        {
            Usuario usuario = _usuarioRepository.ObterPorId(id);
            if (usuario != null)
                return View(usuario);

            return RedirectToAction("Listar");
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            bool modificado = _usuarioRepository.Atualizar(usuario);
            return RedirectToAction("Listar");
        }


        [HttpPost]
        public IActionResult Remover(long id)
        {
            _usuarioRepository.Remover(id);
            return RedirectToAction("Listar");
        }
    }
}