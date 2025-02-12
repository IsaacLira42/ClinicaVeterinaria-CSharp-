namespace ProjetoCS.Models
{
    public class Cliente : Usuario
    {
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Cliente() { }

        public Cliente(int id, string nome, string email, string senha, string telefone, string endereco)
            : base(id, nome, email, senha)
        {
            Telefone = telefone;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return base.ToString() + $" - {Telefone} - {Endereco}";
        }
    }
}
