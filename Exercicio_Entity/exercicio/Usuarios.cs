using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercicio
{
    [Table("usuarios")]
    public class Usuarios
    {
         [Key]
        [Column("id_usuario")]
        public int Id { get; set; }  // Correspondente à coluna id_Usuario no banco de dados

        [Column("senha")]
        public string Senha { get; set; } = string.Empty;

        [Column("nome_usuario")]
        public string Nome { get; set; } = string.Empty;

        [Column("ramal")]
        public int Ramal { get; set; }  // Agora em PascalCase

        [Column("especialidade")]
        public string Especialidade { get; set; } = string.Empty;
    }
}
