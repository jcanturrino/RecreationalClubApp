using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{

    [Table("RegistrosAcceso")]
    public class RegistroAcceso
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ClienteId")]
        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Column("FechaHoraEntrada")]
        [Required]
        public DateTime FechaHoraEntrada { get; set; }

        [Column("FechaHoraSalida")]
        public DateTime? FechaHoraSalida { get; set; }

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
