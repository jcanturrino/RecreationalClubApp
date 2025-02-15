
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("MarcaId")]
        [Required]
        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public Marca? Marca { get; set; }

        [Column("ModeloId")]
        [Required]
        public int ModeloId { get; set; }

        [ForeignKey("ModeloId")]
        public Modelo? Modelo { get; set; }

        [Column("Placa")]
        [Required]
        [StringLength(20)]
        public string Placa { get; set; }

        [Column("ClienteId")]
        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Column("ParqueoValetId")]
        [Required]
        public int ParqueoValetId { get; set; }

        [ForeignKey("ParqueoValetId")]
        public ParqueoValet? ParqueoValet { get; set; }

        [Column("CodigoUbicacion")]
        [Required]
        [StringLength(20)]
        public string CodigoUbicacion { get; set; }

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
