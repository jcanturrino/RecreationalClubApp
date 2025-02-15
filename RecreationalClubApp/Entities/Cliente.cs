using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column("TipoClienteId")]
        [Required]
        public int TipoClienteId { get; set; }

        [ForeignKey("TipoClienteId")]
        public TipoCliente? TipoCliente { get; set; }

        public List<InformacionContacto>? InformacionContacto
        {
            get; set;
        }
    }
}