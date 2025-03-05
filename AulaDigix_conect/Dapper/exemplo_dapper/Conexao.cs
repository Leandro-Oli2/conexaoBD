using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


// Para usar o Dapper, é necessário instalar o pacote Dapper

// dotnet add package Dapper -- version 2.0.90
// dotnet add package Npgsql
using Npgsql;

namespace Exemplo_Dapper_1
{
    public class Conexao
    {
        private static readonly string conecxaoDB = "Host=localhost;Database=conexaoBD; Username=postgres;Password=Oliveira@87185";

        public static IDbConnection GetConexao() // IDbConnection é uma interface que representa uma conexão aberta com um banco de dados
        {
            return new NpgsqlConnection(conecxaoDB);
        }
    }
}