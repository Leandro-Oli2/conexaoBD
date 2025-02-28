using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace exercicio
{
    public class Executar
    {
        static void Main(string[] args){
            Crud crud = new Crud();
            crud.InserirUsuario(1, "12345", "Leandro", 23, "Developer Senior");
            crud.InserirMaquina(1, "12345", 10, 500, 200, 8, 1);
            crud.InserirSoftware(1, "League of Legends", 20, 2, 1);
        }
    }
}