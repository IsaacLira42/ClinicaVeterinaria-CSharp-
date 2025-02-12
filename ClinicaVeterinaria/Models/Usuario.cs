namespace ProjetoCS.Models
{
    public class Usuario : Modelo
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario() { }

        public Usuario(int id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Email}";
        }
    }
}
