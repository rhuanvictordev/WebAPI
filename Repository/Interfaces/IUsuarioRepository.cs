using WebAPI.Models;

namespace WebAPI.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        public List<Usuario> Listar();
        public Usuario Criar(Usuario usuario);
        public bool Atualizar(Usuario novoUsuario);
        public bool Remover(Usuario usuario);
    }
}
