using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Database.Entitites.WCF
{
    [Table("Usuario")]
    public class UsuariosEntity
    {
        [Key]
        public long DocumentoIdentidad { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required string Email1 { get; set; }
        public string Email2 { get; set; } = string.Empty;
        public required string Telefono1 { get; set; }
        public string Telefono2 { get; set; } = string.Empty;
        public required string Dirreccion1 { get; set; }
        public string Dirreccion2 { get; set; } = string.Empty;
    }
}
