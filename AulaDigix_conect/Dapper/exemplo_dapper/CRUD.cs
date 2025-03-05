using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Exemplo_Dapper_1
{
    public class CRUD
    {
        public void InserirUsuario(int id, string nome, string email)
        {
            using (IDbConnection db = Conexao.GetConexao())
            {
                string query = $"INSERT INTO usuario (id, nome, email) VALUES ({id}, '{nome}', '{email}')";
                db.Execute(query);
                System.Console.WriteLine($"Usuário {nome} inserido com sucesso!");
            }
        }

        public void ListarUsuario()
        {
            using (IDbConnection db = Conexao.GetConexao())
            {
                string query = "Select * from usuario";
                var usuarios = db.Query<Usuario>(query).ToList(); // Query é um método genérico que retorna uma lista de objetos

                System.Console.WriteLine("\n Lista de usuários: \n");
                foreach (var usuario in usuarios)
                {
                    System.Console.WriteLine($"Id: {usuario.Id} | Nome: {usuario.Nome} | Email: {usuario.Email}");
                }
            }
        }

        public void AtualizarUsuario (int id, string novoNome)
        {
            using (IDbConnection db = Conexao.GetConexao())
            {
                string query = $"Update usuario set nome = '{novoNome}' where id = {id}";
                db.Execute(query);
                System.Console.WriteLine($"Usuário com id {id} atualizado com sucesso!");
            }
        }

        public void DeletarUsuario(int id)
        {
            using (IDbConnection db = Conexao.GetConexao())
            {
                string query = $"Delete from usuario where id = {id}";
                db.Execute(query);
                System.Console.WriteLine($"Usuário com id {id} deletado com sucesso!");
            }
        }
    }
}