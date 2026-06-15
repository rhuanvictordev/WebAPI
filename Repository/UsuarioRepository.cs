using Oracle.ManagedDataAccess.Client;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repository.Interfaces;

namespace WebAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DBConnection _connection;

        public UsuarioRepository(DBConnection connection)
        {
            _connection = connection;
        }

        public bool Atualizar(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Criar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();

            try
            {
                using (var conn = _connection.CreateConnection())
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SELECT IDUSUARIO,NOME FROM USUARIOS";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Usuario(long.Parse(reader[0].ToString()), reader[1].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception("Erro ao listar os usuarios", ex);
            }

            return lista;
        }

        public bool Remover(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
