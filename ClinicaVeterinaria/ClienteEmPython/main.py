import json
from persistence import GenericPersistence
from models import Cliente, Funcionario


def menu():
    print("Escolha a operação:")
    print("1 - Adicionar Cliente")
    print("2 - Listar Clientes")
    print("3 - Atualizar Cliente")
    print("4 - Excluir Cliente")
    print("5 - Adicionar Funcionario")
    print("6 - Listar Funcionarios")
    print("7 - Atualizar Funcionario")
    print("8 - Excluir Funcionario")
    print("0 - Sair")

    escolha = input("Digite a opção: ")

    if escolha == '1':
        nome = input("Nome: ")
        email = input("Email: ")
        telefone = input("Telefone: ")
        endereco = input("Endereço: ")
        cliente = Cliente(nome, email, telefone, endereco)
        persistencia = GenericPersistence('/workspaces/ClinicaVeterinaria-CSharp-/ClinicaVeterinaria/clientes.json')
        persistencia.inserir(cliente)
        print("Cliente adicionado com sucesso!")
    elif escolha == '2':
        persistencia = GenericPersistence('/workspaces/ClinicaVeterinaria-CSharp-/ClinicaVeterinaria/clientes.json')
        clientes = persistencia.listar()
        for cliente in clientes:
            print(cliente)
    elif escolha == '3':
        id_cliente = int(input("Digite o ID do cliente a ser atualizado: "))
        nome = input("Novo nome: ")
        email = input("Novo email: ")
        telefone = input("Novo telefone: ")
        endereco = input("Novo endereço: ")
        cliente = Cliente(nome, email, telefone, endereco, id_cliente)
        persistencia = GenericPersistence('/workspaces/ClinicaVeterinaria-CSharp-/ClinicaVeterinaria/clientes.json')
        persistencia.atualizar(cliente)
        print("Cliente atualizado com sucesso!")
    elif escolha == '4':
        id_cliente = int(input("Digite o ID do cliente a ser excluído: "))
        persistencia = GenericPersistence('/workspaces/ClinicaVeterinaria-CSharp-/ClinicaVeterinaria/clientes.json')
        persistencia.excluir(id_cliente)
        print("Cliente excluído com sucesso!")
    elif escolha == '5':
        nome = input("Nome: ")
        email = input("Email: ")
        cargo = input("Cargo: ")
        salario = float(input("Salário: "))
        funcionario = Funcionario(nome, email, cargo, salario)
        persistencia = GenericPersistence('/workspaces/ClinicaVeterinaria-CSharp-/ClinicaVeterinaria/funcionarios.json')
        persistencia.inserir(funcionario)
        print("Funcionário adicionado com sucesso!")
    elif escolha == '6':
        persistencia = GenericPersistence('/workspaces/ClinicaVeterinaria-CSharp-/ClinicaVeterinaria/funcionarios.json')
        funcionarios = persistencia.listar()
        for funcionario in funcionarios:
            print(funcionario)
    elif escolha == '7':
        id_funcionario = int(input("Digite o ID do funcionário a ser atualizado: "))
        nome = input("Novo nome: ")
        email = input("Novo email: ")
        cargo = input("Novo cargo: ")
        salario = float(input("Novo salário: "))
        funcionario = Funcionario(nome, email, cargo, salario, id_funcionario)
        persistencia = GenericPersistence('/workspaces/ClinicaVeterinaria-CSharp-/ClinicaVeterinaria/funcionarios.json')
        persistencia.atualizar(funcionario)
        print("Funcionário atualizado com sucesso!")
    elif escolha == '8':
        id_funcionario = int(input("Digite o ID do funcionário a ser excluído: "))
        persistencia = GenericPersistence('/workspaces/ClinicaVeterinaria-CSharp-/ClinicaVeterinaria/funcionarios.json')
        persistencia.excluir(id_funcionario)
        print("Funcionário excluído com sucesso!")
    elif escolha == '0':
        print("Saindo...")
        exit()
    else:
        print("Opção inválida!")

if __name__ == "__main__":
    while True:
        menu()
