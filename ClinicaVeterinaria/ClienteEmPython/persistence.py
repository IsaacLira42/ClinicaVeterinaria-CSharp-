import json
import os
from models import Cliente, Funcionario


class GenericPersistence:
    def __init__(self, arquivo):
        if not arquivo:
            raise ValueError("O caminho do arquivo não pode estar vazio!")
        self.arquivo = arquivo
        self.objetos = []

    def abrir(self):
        if not os.path.exists(self.arquivo):
            os.makedirs(os.path.dirname(self.arquivo), exist_ok=True)
            with open(self.arquivo, 'w') as f:
                json.dump([], f)
        
        with open(self.arquivo, 'r') as f:
            self.objetos = json.load(f)
        
        # Normalizar chave 'Id' para 'id'
        for obj in self.objetos:
            if 'Id' in obj:
                obj['id'] = obj.pop('Id')  # Renomear chave 'Id' para 'id'


    def salvar(self):
        with open(self.arquivo, 'w') as f:
            json.dump(self.objetos, f, indent=4)

    def inserir(self, obj):
        self.abrir()
        # Alterar para acessar a chave 'id' no dicionário
        obj.id = max([o['id'] for o in self.objetos], default=0) + 1
        # Adiciona o objeto como dicionário
        self.objetos.append(obj.__dict__)
        self.salvar()


    def listar(self):
        self.abrir()
        return [obj for obj in self.objetos]

    def listar_por_id(self, id):
        self.abrir()
        return next((obj for obj in self.objetos if obj['id'] == id), None)

    def atualizar(self, obj):
        self.abrir()
        for i, o in enumerate(self.objetos):
            if o['id'] == obj.id:
                self.objetos[i] = obj.__dict__
                self.salvar()
                break

    def excluir(self, id):
        self.abrir()
        self.objetos = [o for o in self.objetos if o['id'] != id]
        self.salvar()
