namespace ProjetoCS.Models
{
    public class Funcionario : Usuario
    {
        public string Cargo { get; set; }
        public double Salario { get; set; }

        public Funcionario() { }

        public Funcionario(int id, string nome, string email, string senha, string cargo, double salario)
            : base(id, nome, email, senha)
        {
            Cargo = cargo;
            Salario = salario;
        }

        public override string ToString()
        {
            return base.ToString() + $" - {Cargo} - R$ {Salario:F2}";
        }
    }
}
