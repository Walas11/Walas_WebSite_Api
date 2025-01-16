namespace Application.Dto.WCF.Dto
{
    public class ContactoDto
    {
        public int Id { get; set; }
        public required string Tipo { get; set; } // "Telefono", "Correo", "Direccion"
        public required string Valor { get; set; }
    }
}
