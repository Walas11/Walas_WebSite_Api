using Infrastructure.Database.Context;
using Infrastructure.Database.Entitites.Users;

namespace Infrastructure.Repository.Usuarios
{
    public class UserRepository(WalasWebSiteContext context) : IUserRepository
    {
        private readonly WalasWebSiteContext _context = context;

        public UserEntity Actualizar(UserEntity clienteEntity)
        {
            _context.User.Update(clienteEntity);
            _context.SaveChanges();
            return clienteEntity;
        }

        public UserEntity Crear(UserEntity clienteEntity)
        {
            _context.User.Add(clienteEntity);
            _context.SaveChanges();
            return clienteEntity;
        }

        public void Eliminar(UserEntity clienteEntity)
        {
            _context.User.Remove(clienteEntity);
            _context.SaveChanges();
        }

        public List<UserEntity> ObtenerClientes()
        {
            return [.. _context.User];
        }

        public UserEntity ObtenerClientes(long id)
        {
            return _context.User.Find(id);
        }
    }
}
