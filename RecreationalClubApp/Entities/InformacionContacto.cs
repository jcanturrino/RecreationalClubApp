using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{


    [Table("InformacionContacto")]
    public class InformacionContacto
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ClienteId")]
        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Column("TipoContactoId")]
        [Required]
        public int TipoContactoId { get; set; }

        [ForeignKey("TipoContactoId")]
        public TipoContacto? TipoContacto { get; set; }

        [Column("Informacion")]
        [Required]
        [StringLength(255)]
        public string Informacion { get; set; }

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