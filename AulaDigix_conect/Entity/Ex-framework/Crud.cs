using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Npgsql;

namespace Ex_framework
{
   public class Crud
    {
        public void InserirUsuario(int id, string nome, string email)
        {
            using (var db = new DB())
            {
                db.Usuarios.Add(new Usuario { Id = id, Nome = nome, Email = email });
                db.SaveChanges();
            }
        }

        public void ListarUsuarios()
        {
            using (var db = new DB())
            {
                var usuarios = db.Usuarios.ToList();
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"Id: {usuario.Id} Nome: {usuario.Nome} Email: {usuario.Email}");
                }
            }
        }

        public void AtualizarUsuario(int id, string novoNome)
        {
            using (var db = new DB())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    usuario.Nome = novoNome;
                    db.SaveChanges();
                    Console.WriteLine("Usuário atualizado com sucesso");
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado");
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            using (var db = new DB())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    Console.WriteLine("Usuário deletado com sucesso");
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado");
                }
            }
        }

        public static void Main(string[] args)  // ➜ O código precisa estar dentro do método Main!
        {
            Crud crud = new Crud();

            Stopwatch sw = new Stopwatch();
            TimeSpan tempoTotal;

            sw.Start();
            crud.InserirUsuario(7, "Fulano", "fulano@gmail.com");
            sw.Stop();
            Console.WriteLine($"Tempo de inserção: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoInsercao = sw.Elapsed;

            sw.Restart();
            Console.WriteLine("Leitura de registros:");
            crud.ListarUsuarios();  // ➜ O nome correto do método é ListarUsuarios(), não LerUsuario()
            sw.Stop();
            Console.WriteLine($"Tempo de leitura: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoLeitura = sw.Elapsed;

            sw.Restart();
            Console.WriteLine("Atualização de registros:");
            crud.AtualizarUsuario(7, "Ciclano");
            sw.Stop();
            Console.WriteLine($"Tempo de atualização: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoAtualizacao = sw.Elapsed;

            sw.Restart();
            Console.WriteLine("Deleção de registros:");
            crud.DeletarUsuario(7);
            sw.Stop();
            Console.WriteLine($"Tempo de deleção: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoDelecao = sw.Elapsed;

            tempoTotal = tempoInsercao + tempoLeitura + tempoAtualizacao + tempoDelecao;
            Console.WriteLine($"Tempo total de execução: {tempoTotal}");
        }
    }
}
