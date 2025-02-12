using System;
using ProjetoCS.Models;
using ProjetoCS.Persistence;

namespace ProjetoCS.Services
{
    public class Menu
    {
        private GenericPersistence<Cliente> clientes = new GenericPersistence<Cliente>("clientes.json");
        private GenericPersistence<Funcionario> funcionarios = new GenericPersistence<Funcionario>("funcionarios.json");
        private GenericPersistence<Admin> admins = new GenericPersistence<Admin>("admins.json");

        public void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== MENU PRINCIPAL =====");
                Console.WriteLine("1 - Gerenciar Clientes");
                Console.WriteLine("2 - Gerenciar Funcionários");
                Console.WriteLine("3 - Gerenciar Administradores");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                
                switch (Console.ReadLine())
                {
                    case "1": Gerenciar(clientes, "Cliente"); break;
                    case "2": Gerenciar(funcionarios, "Funcionário"); break;
                    case "3": Gerenciar(admins, "Administrador"); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            }
        }

        private void Gerenciar<T>(GenericPersistence<T> persistencia, string tipo) where T : Usuario, new()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"===== GERENCIAR {tipo.ToUpper()}S =====");
                Console.WriteLine("1 - Adicionar");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Atualizar");
                Console.WriteLine("4 - Remover");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");
                
                switch (Console.ReadLine())
                {
                    case "1": Adicionar(persistencia, tipo); break;
                    case "2": Listar(persistencia); break;
                    case "3": Atualizar(persistencia); break;
                    case "4": Remover(persistencia); break;
                    case "0": return;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            }
        }

        private void Adicionar<T>(GenericPersistence<T> persistencia, string tipo) where T : Usuario, new()
        {
            Console.Clear();
            Console.WriteLine($"==== ADICIONAR {tipo.ToUpper()} ====");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            T usuario = new T { Nome = nome, Email = email, Senha = senha };

            if (usuario is Cliente cliente)
            {
                Console.Write("Telefone: ");
                cliente.Telefone = Console.ReadLine();
                Console.Write("Endereço: ");
                cliente.Endereco = Console.ReadLine();
            }
            else if (usuario is Funcionario funcionario)
            {
                Console.Write("Cargo: ");
                funcionario.Cargo = Console.ReadLine();
                Console.Write("Salário: ");
                funcionario.Salario = double.Parse(Console.ReadLine());
            }
            else if (usuario is Admin admin)
            {
                Console.Write("Nível de Acesso: ");
                admin.NivelAcesso = Console.ReadLine();
            }

            persistencia.Inserir(usuario);
            Console.WriteLine($"{tipo} adicionado com sucesso!");
            Console.ReadKey();
        }

        private void Listar<T>(GenericPersistence<T> persistencia) where T : Usuario
        {
            Console.Clear();
            Console.WriteLine($"==== LISTA DE {typeof(T).Name.ToUpper()}S ====");
            var lista = persistencia.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum registro encontrado.");
            }
            else
            {
                foreach (var item in lista)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();
        }

        private void Atualizar<T>(GenericPersistence<T> persistencia) where T : Usuario, new()
        {
            Console.Clear();
            Console.WriteLine($"==== ATUALIZAR {typeof(T).Name.ToUpper()} ====");
            Listar(persistencia);
            Console.Write("Digite o ID para atualizar: ");
            int id = int.Parse(Console.ReadLine());

            var usuario = persistencia.ListarPorId(id);
            if (usuario == null)
            {
                Console.WriteLine("ID não encontrado!");
                Console.ReadKey();
                return;
            }

            Console.Write("Novo Nome: ");
            usuario.Nome = Console.ReadLine();
            Console.Write("Novo Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Nova Senha: ");
            usuario.Senha = Console.ReadLine();

            if (usuario is Cliente cliente)
            {
                Console.Write("Novo Telefone: ");
                cliente.Telefone = Console.ReadLine();
                Console.Write("Novo Endereço: ");
                cliente.Endereco = Console.ReadLine();
            }
            else if (usuario is Funcionario funcionario)
            {
                Console.Write("Novo Cargo: ");
                funcionario.Cargo = Console.ReadLine();
                Console.Write("Novo Salário: ");
                funcionario.Salario = double.Parse(Console.ReadLine());
            }
            else if (usuario is Admin admin)
            {
                Console.Write("Novo Nível de Acesso: ");
                admin.NivelAcesso = Console.ReadLine();
            }

            persistencia.Atualizar(usuario);
            Console.WriteLine("Atualização realizada!");
            Console.ReadKey();
        }

        private void Remover<T>(GenericPersistence<T> persistencia) where T : Usuario
        {
            Console.Clear();
            Console.WriteLine($"==== REMOVER {typeof(T).Name.ToUpper()} ====");
            Listar(persistencia);
            Console.Write("Digite o ID para remover: ");
            int id = int.Parse(Console.ReadLine());

            persistencia.Excluir(id);
            Console.WriteLine("Removido com sucesso!");
            Console.ReadKey();
        }
    }
}
