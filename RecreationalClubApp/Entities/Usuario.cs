using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("NombreUsuario")]
        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Column("Contrasena")]
        [Required]
        [StringLength(255)]
        public string Contrasena { get; set; }

        [Column("RolId")]
        [Required]
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public Rol? Rol { get; set; }
    }
}