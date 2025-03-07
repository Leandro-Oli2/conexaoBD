using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Npgsql;

namespace Exemplo3_ADO_FORMS
{
    public class CRUD
    {
        string conexaoSQL = "Host=localhost;Database=conexaoBD;Username=postgres;Password=Oliveira@87185";

        public void InserirUsuario(int id, string nome, string email){
            string query = "INSERT INTO Usuario(id, nome, email) VALUES(@id, @nome, @email)";
            using (NpgsqlConnection conn = new NpgsqlConnection(conexaoSQL))
            {
                conn.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@email", email);

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<string> ListarClientes(){
            List<string> clientes = new List<string>();
            string query = "SELECT * FROM Usuario";
            using (NpgsqlConnection conn = new NpgsqlConnection(conexaoSQL))
            {
                conn.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string linha = $"ID: {reader["id"]}, Nome: {reader["nome"]}, Email: {reader["email"]}";
                            clientes.Add(linha);
                        }
                    }
                }
            }
            return clientes;
        }
        public void AtualizarUsuario(int id, string novoNome){
        string query = $"UPDATE Usuario SET nome = @novoNome WHERE id = @id";
        using (NpgsqlConnection conn = new NpgsqlConnection(conexaoSQL))
        {
            conn.Open();
            using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@novoNome", novoNome);
                command.ExecuteNonQuery();
            }
        }
    }
    public void DeletarUsuario(int id){
            string query = "DELETE FROM Usuario WHERE id = @id";

            using (NpgsqlConnection conn = new NpgsqlConnection(conexaoSQL))
            {
                conn.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}