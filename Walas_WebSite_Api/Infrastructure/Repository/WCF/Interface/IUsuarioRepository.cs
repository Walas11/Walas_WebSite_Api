using Domain.WCF;

namespace Infrastructure.Repository.WCF.Interface
{
    public interface IUsuarioRepository
    {
        Usuario GetByDocumentoIdentidad(string documentoIdentidad);
        void Add(Usuario usuario);
    }
}
