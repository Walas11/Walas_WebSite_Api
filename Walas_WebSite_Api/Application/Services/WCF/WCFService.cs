using Application.Dto.WCF.Dto;
using Domain.WCF;
using Infrastructure.Repository.WCF;
using Infrastructure.Repository.WCF.Interface;

namespace Domain.Services.WCF
{
    public class WCFService
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public WCFService(UsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public bool RegistrarPersona(UsuarioDto personaDto)
        {
            // Validación: los campos obligatorios
            if (string.IsNullOrWhiteSpace(personaDto.DocumentoIdentidad) ||
                string.IsNullOrWhiteSpace(personaDto.Nombres) ||
                string.IsNullOrWhiteSpace(personaDto.Apellidos) ||
                personaDto.FechaNacimiento == default)
            {
                throw new ArgumentException("Los campos documento, nombres, apellidos y fecha de nacimiento son obligatorios.");
            }

            // Validación de caracteres válidos
            if (!personaDto.Nombres.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)))
            {
                throw new ArgumentException("Los nombres solo pueden contener caracteres del alfabeto latino.");
            }

            if (!personaDto.Apellidos.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)))
            {
                throw new ArgumentException("Los apellidos solo pueden contener caracteres del alfabeto latino.");
            }

            if (!personaDto.DocumentoIdentidad.All(c => Char.IsLetterOrDigit(c)))
            {
                throw new ArgumentException("El documento de identidad solo acepta caracteres alfanuméricos.");
            }

            // Validación de contactos
            if (personaDto.Contactos.Count == 0 || personaDto.Contactos.Count(c => c.Tipo == "Correo") > 2 || personaDto.Contactos.Count(c => c.Tipo == "Telefono") > 2 || personaDto.Contactos.Count(c => c.Tipo == "Direccion") > 2)
            {
                throw new ArgumentException("Debe registrar al menos un contacto (correo, teléfono o dirección). Máximo 2 contactos por tipo.");
            }

            // Verificar si ya existe una persona con el mismo documento de identidad
            var personaExistente = _UsuarioRepository.GetByDocumentoIdentidad(personaDto.DocumentoIdentidad);
            if (personaExistente != null)
            {
                throw new ArgumentException("Ya existe una persona con el mismo documento de identidad.");
            }

            // Mapeo del DTO a la entidad de dominio
            var Usuario = new Usuario
            {
                DocumentoIdentidad = personaDto.DocumentoIdentidad,
                Nombres = personaDto.Nombres,
                Apellidos = personaDto.Apellidos,
                FechaNacimiento = personaDto.FechaNacimiento,
                Contactos = personaDto.Contactos.Select(c => new Contacto { Tipo = c.Tipo, Valor = c.Valor }).ToList()
            };

            // Guardar en la base de datos
            _UsuarioRepository.Add(Usuario);

            return true;
        }
    }
}
