class Modelo:
    def __init__(self, id=None):
        self.id = id


class Cliente(Modelo):
    def __init__(self, nome, email, telefone, endereco, id=None):
        super().__init__(id)
        self.nome = nome
        self.email = email
        self.telefone = telefone
        self.endereco = endereco


class Funcionario(Modelo):
    def __init__(self, nome, email, cargo, salario, id=None):
        super().__init__(id)
        self.nome = nome
        self.email = email
        self.cargo = cargo
        self.salario = salario