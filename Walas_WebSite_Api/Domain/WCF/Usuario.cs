using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WCF
{
    public class Usuario
    {
        public int Id { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Contacto> Contactos { get; set; }

        public Usuario()
        {
            Contactos = new List<Contacto>();
        }
    }
}
