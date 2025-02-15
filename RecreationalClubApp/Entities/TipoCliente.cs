﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("TiposClientes")]
    public class TipoCliente
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }
    }
}