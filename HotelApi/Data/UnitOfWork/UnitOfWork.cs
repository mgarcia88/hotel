using System.Threading.Tasks;
using HotelApi.Dominio.Entidades.Repositorio;

namespace HotelApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContexto;

        public IClienteRepositorio ClienteRepositorio { get; }

        public UnitOfWork(ApplicationContext dbContexto,
            IClienteRepositorio clienteRepositorio)
        {
            _dbContexto = dbContexto;
            ClienteRepositorio = clienteRepositorio;
        }
        
        public void Commit()
        {
           _dbContexto.SaveChanges();
        }

        
    }
}