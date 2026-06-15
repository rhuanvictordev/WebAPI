using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Listar()
        {
            var lista = _usuarioRepository.Listar();

            foreach (Usuario u in lista)
            {
                System.Diagnostics.Debug.WriteLine(u.Nome);
            }

            return View(lista);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}