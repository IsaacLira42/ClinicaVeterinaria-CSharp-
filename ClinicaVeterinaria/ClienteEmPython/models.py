class Modelo:
    def __init__(self, id=None):
        self.id = id


class Cliente(Modelo):
    def __init__(self, Nome, Email, Telefone, Endereco, id=None):
        super().__init__(id)
        self.Nome = Nome
        self.Email = Email
        self.Telefone = Telefone
        self.Endereco = Endereco


class Funcionario(Modelo):
    def __init__(self, Nome, Email, Cargo, Salario, id=None):
        super().__init__(id)
        self.Nome = Nome
        self.Email = Email
        self.Cargo = Cargo
        self.Salario = Salario