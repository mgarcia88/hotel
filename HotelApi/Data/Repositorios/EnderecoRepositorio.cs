using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Repositorio;

namespace HotelApi.Data.Repositorios
{
    public class EnderecoRepositorio : Repositorio<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}