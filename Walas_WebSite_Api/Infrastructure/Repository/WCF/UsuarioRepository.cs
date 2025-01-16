using Domain.WCF;
using Infrastructure.Repository.WCF.Interface;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repository.WCF
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Usuario GetByDocumentoIdentidad(string documentoIdentidad)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Personas WHERE DocumentoIdentidad = @DocumentoIdentidad";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DocumentoIdentidad", documentoIdentidad);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = (int)reader["Id"],
                        DocumentoIdentidad = reader["DocumentoIdentidad"].ToString(),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        FechaNacimiento = (DateTime)reader["FechaNacimiento"]
                    };
                }
                return null;
            }
        }

        public void Add(Usuario persona)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Personas (DocumentoIdentidad, Nombres, Apellidos, FechaNacimiento) VALUES (@DocumentoIdentidad, @Nombres, @Apellidos, @FechaNacimiento)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DocumentoIdentidad", persona.DocumentoIdentidad);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@FechaNacimiento", persona.FechaNacimiento);
                connection.Open();
                command.ExecuteNonQuery();
            }

            // Agregar los contactos (teléfonos, correos, direcciones)
            foreach (var contacto in persona.Contactos)
            {
                var query = "INSERT INTO Contactos (PersonaId, Tipo, Valor) VALUES (@PersonaId, @Tipo, @Valor)";
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PersonaId", persona.Id);
                    command.Parameters.AddWithValue("@Tipo", contacto.Tipo);
                    command.Parameters.AddWithValue("@Valor", contacto.Valor);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
