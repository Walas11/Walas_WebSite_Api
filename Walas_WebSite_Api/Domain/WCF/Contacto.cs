namespace Domain.WCF
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // "Telefono", "Correo", "Direccion"
        public string Valor { get; set; }
    }
}