using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; // Importando o namespace para usar o atributo de mapeamento

namespace Exemplo_Dapper_1
{
    // Vamos usar o atributo de mapeamento C# para mapear os campos da tabela de usuários
    // para a classe de usuários
    [Table("usuario")]
    public class Usuario
    {
        
        // [Key] // Atributo de mapeamento de chave primaria 
        // Se for chave estrangeira, usar [ForeignKey("nome_da_coluna")]
        [Column("id")]
        public int Id { get; set; }   

        [Column("nome")]
        public string Nome { get; set; } = string.Empty; // Inicializando a variável com string vazia

        [Column("email")]
        public string Email { get; set; } = string.Empty; // Inicializando a variável com string vazia
    }
}