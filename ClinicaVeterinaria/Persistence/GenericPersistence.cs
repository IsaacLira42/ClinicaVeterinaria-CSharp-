using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ProjetoCS.Models;

namespace ProjetoCS.Persistence
{
    public class GenericPersistence<T> where T : Modelo
    {
        protected List<T> objetos = new List<T>();
        protected string arquivo;

        public GenericPersistence(string arquivo)
        {
            if (string.IsNullOrWhiteSpace(arquivo))
                throw new ArgumentException("O caminho do arquivo não pode estar vazio!", nameof(arquivo));

            this.arquivo = arquivo;
        }


        public void Inserir(T obj)
        {
            Abrir();
            obj.Id = objetos.Any() ? objetos.Max(o => o.Id) + 1 : 1;
            objetos.Add(obj);
            Salvar();
        }

        public List<T> Listar()
        {
            Abrir();
            return new List<T>(objetos);
        }

        public T ListarPorId(int id)
        {
            Abrir();
            return objetos.FirstOrDefault(o => o.Id == id);
        }

        public void Atualizar(T obj)
        {
            Abrir();
            int index = objetos.FindIndex(o => o.Id == obj.Id);
            if (index != -1)
            {
                objetos[index] = obj;
                Salvar();
            }
        }

        public void Excluir(int id)
        {
            Abrir();
            objetos.RemoveAll(o => o.Id == id);
            Salvar();
        }

        protected void Abrir()
        {
            if (!File.Exists(arquivo))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(arquivo));
                File.WriteAllText(arquivo, "[]");
            }
            try
            {
                string json = File.ReadAllText(arquivo);
                objetos = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch
            {
                objetos = new List<T>();
            }
        }

        protected void Salvar()
        {
            string json = JsonSerializer.Serialize(objetos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(arquivo, json);
        }
    }
}
