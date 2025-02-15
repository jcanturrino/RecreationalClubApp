using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("CodigosUbicacion")]
    public class CodigoUbicacion
    {
        [Key]
        [Column("Codigo")]
        [StringLength(20)]
        public string Codigo { get; set; }

        [Column("Descripcion")]
        [StringLength(255)]
        public string? Descripcion { get; set; }

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