using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Entidades.Repositorio;

namespace HotelApi.Data.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}