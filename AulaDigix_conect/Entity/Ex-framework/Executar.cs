using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ex_framework
{
    public class Executar
    {
        static void Main(string[] args){
            Crud crud = new Crud();
            crud.ListarUsuarios();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            System.Console.WriteLine("Inserindo um novo Usuario");
            crud.Inserir(5, "Leandro", "leandro22222@gmail.com");
            crud.ListarUsuarios();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            Console.WriteLine("Atualizando um Usuario");
            crud.Atualizar(5, "Leandro Candido", "leandro@gmail.com");
            crud.ListarUsuarios();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            Console.WriteLine("Deletando um Usuario");
            crud.Deletar(5);
            crud.ListarUsuarios();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

        }
    }
}