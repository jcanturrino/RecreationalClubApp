
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{

    [Table("Modelos")]
    public class Modelo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column("MarcaId")]
        [Required]
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca? Marca { get; set; }

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
