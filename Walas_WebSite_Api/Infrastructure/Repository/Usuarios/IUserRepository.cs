using Infrastructure.Database.Entitites.Users;

namespace Infrastructure.Repository.Usuarios
{
    public interface IUserRepository
    {
        List<UserEntity> ObtenerClientes();
        UserEntity ObtenerClientes(long id);
        UserEntity Crear(UserEntity clienteEntity);
        UserEntity Actualizar(UserEntity clienteEntity);
        void Eliminar(UserEntity clienteEntity);
    }
}
