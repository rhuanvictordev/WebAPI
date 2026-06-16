using Oracle.ManagedDataAccess.Client;
using WebAPI.Data;
using WebAPI.DTOs;
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
            using (var conn = _connection.CreateConnection())
            {
                var command = conn.CreateCommand();
                command.CommandText = "UPDATE USUARIOS SET NOME = :nome WHERE IDUSUARIO = :id";
                command.Parameters.Add("nome", novoUsuario.Nome);
                command.Parameters.Add("id", novoUsuario.Id);
                int afetado = command.ExecuteNonQuery();
                if (afetado > 0)
                    return true;
            }
            return false;
        }


        public Usuario Criar(UsuarioDTO usuario)
        {
            long idGerado;

            using (var conn = _connection.CreateConnection())
            {
                var command = conn.CreateCommand();
                command.CommandText = "SELECT SEQ_IDUSUARIO.NEXTVAL FROM DUAL";
                idGerado = Convert.ToInt64(command.ExecuteScalar());
                
                command.CommandText = "INSERT INTO USUARIOS (IDUSUARIO, NOME) VALUES (:id, :nome)";

                command.Parameters.Clear();
                command.Parameters.Add("id", idGerado);
                command.Parameters.Add("nome", usuario.Nome);

                int afetado = command.ExecuteNonQuery();
                if (afetado > 0)
                { 
                    return new Usuario(idGerado, usuario.Nome);
                }
            }
            return null;
        }



        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();

            try
            {
                using (var conn = _connection.CreateConnection())
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SELECT IDUSUARIO,NOME FROM USUARIOS ORDER BY IDUSUARIO ASC";
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

        public Usuario ObterPorId(long id)
        {
            try
            {
                using (var conn = _connection.CreateConnection())
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "SELECT IDUSUARIO, NOME FROM USUARIOS WHERE IDUSUARIO = :id";
                    command.Parameters.Add("id", id);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Usuario usuario = new Usuario(long.Parse(reader[0].ToString()), reader[1].ToString());
                        return usuario;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar usuario por id", ex);
            }
        }

        public bool Remover(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool Remover(long id)
        {
            using (var conn = _connection.CreateConnection())
            {
                var command = conn.CreateCommand();
                command.CommandText = "DELETE FROM USUARIOS WHERE IDUSUARIO = :id";
                command.Parameters.Add("id", id);
                int afetado = command.ExecuteNonQuery();
                if (afetado > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
