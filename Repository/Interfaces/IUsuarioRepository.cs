using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        public List<Usuario> Listar();
        public Usuario Criar(UsuarioDTO usuario);
        public Usuario ObterPorId(long id);
        public bool Atualizar(Usuario novoUsuario);
        public bool Remover(long id);
    }
}
