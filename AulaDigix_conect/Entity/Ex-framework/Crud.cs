using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex_framework
{
    public class Crud
    {
        public void InserirUsuario(int id, string nome, string email){
            using(var db = new DB()){
                db.Usuario.Add(new Usuario { Id = id, Nome = nome, Email = email });
                db.SaveChanges();
            }
        }

        public void ListarUsuarios(){
            using(var db = new DB()){
                var usuarios = db.Usuario.ToList();
                foreach(var usuario in usuario){
                    Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}, Email: {usuario.Email}");
                }
            }
        }
        public void AtualizarUsuario(int id, string novoNome){
            using(var db = new DB()){
                var usuario = db.Usuario.Find(id);
                if(usuario != null){
                    usuario.Nome = novoNome;
                    db.SaveChanges();
                    System.Console.WriteLine("Usuario Atualizado com Sucesso!");
                }else{
                    Console.WriteLine("Usuário não encontrado.");
                }
            }
        }
        public void DeletarUsuario(int id){
            using(var db = new DB()){
                var usuario = db.Usuario.Find(id);
                if(usuario != null){
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    Console.WriteLine("Usuario Deletado com Sucesso!"); 
                }else{
                    Console.WriteLine("Usuário não encontrado.");
                }
            }
        }
    }
}