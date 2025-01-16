namespace Application.Dto.WCF.Dto
{
    public class UsuarioDto
    {
        public required string DocumentoIdentidad { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public required List<ContactoDto> Contactos { get; set; }
    }
}
