using Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Configurations.JWT
{

    [Table("Tokens")]
    public class Tokens
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Column("Token")]
        [Required]
        [StringLength(255)]
        public string Token { get; set; }

        [Column("RefreshToken")]
        [Required]
        [StringLength(255)]
        public string RefreshToken { get; set; }

        [Column("ExpiryDate")]
        public DateTime ExpiryDate { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [Column("FechaUltimaModificacion")]
        public DateTime FechaUltimaModificacion { get; set; }
    }

}
