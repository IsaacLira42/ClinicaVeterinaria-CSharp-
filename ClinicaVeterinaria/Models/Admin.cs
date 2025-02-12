namespace ProjetoCS.Models
{
    public class Admin : Usuario
    {
        public string NivelAcesso { get; set; }

        public Admin() { }

        public Admin(int id, string nome, string email, string senha, string nivelAcesso)
            : base(id, nome, email, senha)
        {
            NivelAcesso = nivelAcesso;
        }

        public override string ToString()
        {
            return base.ToString() + $" - Acesso: {NivelAcesso}";
        }
    }
}
