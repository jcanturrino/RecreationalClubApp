using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("RolPermisos")]
    public class RolPermiso
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        [Column("RolId")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        [ForeignKey("Permiso")]
        [Column("PermisoId")]
        public int PermisoId { get; set; }
        public Permiso Permiso { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("FechaUltimaModificacion")]
        public DateTime FechaUltimaModificacion { get; set; }
    }

}
