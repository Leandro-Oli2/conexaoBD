using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercicio
{
    [Table("software")]
    public class Software
    {
        [Key]
        [Column("id_software")]
        public int Id_soft { get; set; }

        [Column("produto")]
        public string Produto { get; set; } = string.Empty;

        [Column("harddisk")]
        public int HardDisk { get; set; }

        [Column("memora_ram")]
        public int MemoriaRam { get; set; }

        // Chave estrangeira para a Maquina
        [Column("fk_maquina")]
        public int FkMaquina { get; set; }

        // Definindo o relacionamento com a Maquina
        [ForeignKey("fk_maquina")]
        public Maquina Maquina { get; set; }
    }
}