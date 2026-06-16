using Oracle.ManagedDataAccess.Client;

namespace WebAPI.Data
{
    public class DBConnection(IConfiguration configuration)
    {
        public OracleConnection CreateConnection()
        {
            try
            {
                OracleConnection connection = new OracleConnection(configuration.GetConnectionString("DataBase"));
                connection.Open();
                return connection;
            }
            catch (Exception ex) {
                throw new Exception("Erro ao estabelecer conexão com o banco de dados!");
            }
        }
    }
}