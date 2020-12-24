using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Repositorio;

namespace HotelApi.Data.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}