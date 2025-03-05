using System;
using Npgsql;

using System.Diagnostics;

namespace Ex1
{
    public class Crud
    {
        string conexao = "Host=localhost;Database=conexaoBD;Username=postgres;Password=Oliveira@87185";

        public void InserirUsuario(int id_user, string nome, string email)
        {
            string insertQuery = $"INSERT INTO public.Usuario(id_user, nome, email) VALUES ({id_user}, '{nome}', '{email}')";
            using (NpgsqlConnection conn = new NpgsqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, conn))
                    {
                        command.Parameters.AddWithValue("id_user", id_user);
                        command.Parameters.AddWithValue("nome", nome);
                        command.Parameters.AddWithValue("email", email);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Usuário inserido com sucesso.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        public void LerUsuario()
        {
            string selectQuery = "SELECT * FROM public.Usuario";

            using (NpgsqlConnection conn = new NpgsqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, conn))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(
                                    $"id_user: {reader["id_user"]} | " +
                                    $"Nome: {reader["nome"]} | " +
                                    $"Email: {reader["email"]}"
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        public void AtualizarUsuario(int id_user, string nome, string email)
        {
            string updateQuery = $"UPDATE public.Usuario SET nome='{nome}', email='{email}' WHERE id_user={id_user}";
            using (NpgsqlConnection conn = new NpgsqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, conn))
                    {
                        command.Parameters.AddWithValue("id_user", id_user);
                        command.Parameters.AddWithValue("nome", nome);
                        command.Parameters.AddWithValue("email", email);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} linha(s) atualizada(s).");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        public void DeletarUsuario(int id_user)
        {
            string deleteQuery = "DELETE FROM public.Usuario WHERE id_user=id_user";
            using (NpgsqlConnection conn = new NpgsqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(deleteQuery, conn))
                    {
                        command.Parameters.AddWithValue("id_user", id_user);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} linha(s) deletada(s).");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        static void Main(string[] args)
        {
            Crud crud = new Crud();
            Stopwatch sw = new Stopwatch();
            TimeSpan tempoTotal;

            //1
            sw.Start();
            crud.InserirUsuario(12, "isso", "leandro@gmail.com");
            sw.Stop();
            Console.WriteLine($"Tempo de Inserção: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoInsercao = sw.Elapsed;
            
            //2
            sw.Restart();
            Console.WriteLine($"Leitura de Registros: ");
            crud.LerUsuario();
            sw.Stop();
            Console.WriteLine($"Tempo de leitura: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoLeitura = sw.Elapsed;

            //3
            sw.Restart();
            Console.WriteLine($"Atualização de Registros: ");
            crud.AtualizarUsuario(12, "Leandro Candido", "leandro22@gmail.com");
            sw.Stop();
            Console.WriteLine($"Tempo de atualização: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoAtualizacao = sw.Elapsed;

            //4
            sw.Restart();
            Console.WriteLine($"Deleção de Registros: ");
            crud.DeletarUsuario(12);
            sw.Stop();
            Console.WriteLine($"Tempo de deleção: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoDelecao = sw.Elapsed;
            
            //Calculando o tempo total de exceução
            tempoTotal = tempoInsercao + tempoLeitura + tempoAtualizacao + tempoDelecao;
            Console.WriteLine($"Tempo Total de Execução: {tempoTotal}");

        }
    }
}
