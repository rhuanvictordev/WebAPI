namespace WebAPI.Models
{
    public class Usuario
    {
        public Usuario()
        {
            
        }

        public Usuario(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
    }
}
