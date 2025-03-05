using System;
using Npgsql; // Não se esqueça de ter esse "using" para importar a biblioteca Npgsql.

namespace Ex1
{
    public class Executar
    {
        // static void Main(string[] args)
        // {
        //     string conexao = "Host=localhost;Database=conexaoBD;Username=postgres;Password=Oliveira@87185";

        //     using (NpgsqlConnection conn = new NpgsqlConnection(conexao))
        //     {
        //         try
        //         {
        //             conn.Open();
        //             Console.WriteLine("Conexão Aberta com Postgres!");

        //             // Consulta para listar os registros da tabela Usuario
        //             string query = "SELECT id_user, nome, email FROM public.Usuario";

        //             // Consulta para inserir um novo registro
        //             string insertQuery = "INSERT INTO public.Usuario (id_user, nome, email) VALUES(4, 'marcos', 'loudthurzin@gmail.com')";

        //             // Consulta para deletar o registro
        //             string deleteQuery = "DELETE FROM public.Usuario WHERE id_user = 3";

        //             string updateQuery = "UPDATE public.Usuario SET id_user = 3 WHERE id_user = 4";

        //             using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, conn))
        //             {
        //                 int row = command.ExecuteNonQuery();
        //                 console.WriteLine("Update Realizado");
        //             }
        //             // Inserir o novo registro
        //             using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, conn))
        //             {
        //                 int row = command.ExecuteNonQuery();
        //                 Console.WriteLine("Linhas afetadas: " + row);
        //             }

        //             using (NpgsqlCommand command = new NpgsqlCommand(deleteQuery, conn))
        //             {
        //                 int row = command.ExecuteNonQuery();
        //                 Console.WriteLine("Deletado com sucesso");
        //             }

        //             // Listar os registros da tabela Usuario
        //             using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //             {
        //                 using (NpgsqlDataReader dr = cmd.ExecuteReader())
        //                 {
        //                     Console.WriteLine("Registros da tabela Usuario:");
        //                     while (dr.Read())
        //                     {
                                
        //                         Console.WriteLine(
        //                             $"id_user: {dr["id_user"]} | " +
        //                             $"Nome: {dr["nome"]} | " +
        //                             $"Email: {dr["email"]}"
        //                         );
        //                     }
        //                 }
        //             }
 

        //         }
        //         catch (NpgsqlException e)
        //         {
        //             Console.WriteLine($"Erro ao conectar: {e.Message}");
        //         }
        //     }
        // }
    }
}
