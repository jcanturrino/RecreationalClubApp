using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{

    [Table("TiposContacto")]
    public class TipoContacto
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Column("UsuarioId")]
        [Required]
        public int UsuarioId { get; set; }

        [Column("FechaCreacion")]
        [Required]
        public DateTime FechaCreacion { get; set; }

        [Column("FechaUltimaModificacion")]
        public DateTime? FechaUltimaModificacion { get; set; }
    }
}