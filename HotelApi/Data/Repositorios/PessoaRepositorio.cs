using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Repositorio;

namespace HotelApi.Data.Repositorios
{
    public class PessoaRepositorio : Repositorio<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}