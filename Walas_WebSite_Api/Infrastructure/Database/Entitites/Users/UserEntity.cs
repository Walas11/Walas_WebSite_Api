using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Database.Entitites.Users
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public long Cedula { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Correo { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public required decimal? Celular { get; set; }
        public string? Direccion { get; set; }
    }
}
