using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{

    [Table("Permisos")]
    public class Permiso
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("FechaUltimaModificacion")]
        public DateTime FechaUltimaModificacion { get; set; }

        public List<RolPermiso> RolPermisos { get; set; }
    }

}
