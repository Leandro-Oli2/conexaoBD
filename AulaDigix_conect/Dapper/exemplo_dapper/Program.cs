using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Exemplo_Dapper_1;
public class Program
{
    public static void Main(string [] args)
    {
         CRUD crud = new CRUD();
            Stopwatch sw = new Stopwatch();
            TimeSpan tempoTotal;
            System.Console.WriteLine("------------------------------------------");

            // Inserção
            sw.Start();
            crud.InserirUsuario(6, "Leandro", "leandro@gmail.com");
            sw.Stop();
            Console.WriteLine($"Tempo de Inserção: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoInsercao = sw.Elapsed;
            System.Console.WriteLine("------------------------------------------");

            // Leitura
            sw.Restart();
            Console.WriteLine($"Leitura de Registros:");
            crud.ListarUsuario();
            sw.Stop();
            Console.WriteLine($"Tempo de leitura: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoLeitura = sw.Elapsed;

            System.Console.WriteLine("------------------------------------------");
            // Atualização
            sw.Restart();
            Console.WriteLine($"Atualização de Registros:");
            crud.AtualizarUsuario(6, "Leandro de Oliveira Candido"); // Certifique-se de que o ID existe
            sw.Stop();
            Console.WriteLine($"Tempo de atualização: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoAtualizacao = sw.Elapsed;

            System.Console.WriteLine("------------------------------------------");
            // Deleção
            sw.Restart();
            Console.WriteLine($"Deleção de Registros:");
            crud.DeletarUsuario(6); // Certifique-se de que o ID existe
            sw.Stop();
            Console.WriteLine($"Tempo de deleção: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoDelecao = sw.Elapsed;
            
            System.Console.WriteLine("------------------------------------------");
            // Tempo total de execução
            tempoTotal = tempoInsercao + tempoLeitura + tempoAtualizacao + tempoDelecao;
            Console.WriteLine($"Tempo Total de Execução: {tempoTotal}");
    }
}