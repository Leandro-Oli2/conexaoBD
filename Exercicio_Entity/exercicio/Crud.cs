using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Npgsql;

namespace exercicio
{
    public class Crud
    {
        public void InserirUsuario(int id, string senha, string nome, int ramal, string especialidade)
        {
            using (var db = new DB())
            {
                db.Usuarios.Add(new Usuarios 
                { 
                    Id = id, 
                    Senha = senha, 
                    Nome = nome, 
                    Ramal = ramal, 
                    Especialidade = especialidade 
                });
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
                    Console.WriteLine($"Id: {usuario.Id} Nome: {usuario.Nome} Especialidade: {usuario.Especialidade}");
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


        //Maquina
        public void InserirMaquina(int id, string senha, int velocidade, int hardD, int Placa, int memoria, int fk_user )
        {
            using (var db = new DB())
            {
                db.Maquinas.Add(new Maquina { Id_maquina = id, Senha = senha, Velocidade = velocidade, HardDisk = hardD, Placa = Placa, Memoria = memoria, FkUsuario = fk_user });
                db.SaveChanges();
            }
        }
        public void ListarMaquina()
        {
            using (var db = new DB())
            {
                var maquinas = db.Maquinas.ToList();
                foreach (var maquina in maquinas)
                {
                    Console.WriteLine($"Id: {maquina.Id_maquina} Velocidade: {maquina.Velocidade} HardDisk: {maquina.HardDisk}");
                }
            }
        }
         public void AtualizarMaquina(int id, int novaVelocidade, int placa)
        {
            using (var db = new DB())
            {
                var maquinas = db.Maquinas.Find(id);
                if (maquinas != null)
                {
                    maquinas.Velocidade = novaVelocidade;
                    maquinas.Placa = placa;
                    db.SaveChanges();
                    Console.WriteLine("Maquina Atualizada com sucesso");
                }
                else
                {
                    Console.WriteLine("Maquina não encontrado");
                }
            }
        }
        public void DeletarMaquina(int id)
        {
            using (var db = new DB())
            {
                var maquinas = db.Maquinas.Find(id);
                if (maquinas != null)
                {
                    db.Maquinas.Remove(maquinas);
                    db.SaveChanges();
                    Console.WriteLine("Maquina Deletada com sucesso");
                }
                else
                {
                    Console.WriteLine("Maquina não encontrado");
                }
            }
        }

        //SOFTWARE
        public void InserirSoftware(int id, string produto, int hardD, int memoria, int fk_maq )
        {
            using (var db = new DB())
            {
                db.Software.Add(new Software { Id_soft = id, Produto = produto, HardDisk = hardD, MemoriaRam = memoria, FkMaquina = fk_maq });
                db.SaveChanges();
            }
        }
        public void ListarSoftware()
        {
            using (var db = new DB())
            {
                var softwares = db.Software.ToList();
                foreach (var software in softwares)
                {
                    Console.WriteLine($"Id: {software.Id_soft}, Produto: {software.Produto} HardDisk: {software.HardDisk}");
                }
            }
        }
         public void AtualizarSoftware(int id, string novoProd, int HardD)
        {
            using (var db = new DB())
            {
                var softwares = db.Software.Find(id);
                if (softwares != null)
                {
                    softwares.Produto = novoProd;
                    softwares.HardDisk = HardD;
                    db.SaveChanges();
                    Console.WriteLine("Software Atualizado com sucesso");
                }
                else
                {
                    Console.WriteLine("Software não encontrado");
                }
            }
        }
        public void DeletarSoftware(int id)
        {
            using (var db = new DB())
            {
                var softwares = db.Software.Find(id);
                if (softwares != null)
                {
                    db.Software.Remove(softwares);
                    db.SaveChanges();
                    Console.WriteLine("Software Deletado com sucesso");
                }
                else
                {
                    Console.WriteLine("Software não encontrado");
                }
            }
        }
    }
}