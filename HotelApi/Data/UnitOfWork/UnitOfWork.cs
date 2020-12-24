using HotelApi.Dominio.Repositorio;

namespace HotelApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContexto;

        public IClienteRepositorio ClienteRepositorio { get; }
        
        public IUsuarioRepositorio UsuarioRepositorio { get; }

        public UnitOfWork(ApplicationContext dbContexto,
            IClienteRepositorio clienteRepositorio,
            IUsuarioRepositorio usuarioRepositorio)
        {
            _dbContexto = dbContexto;
            ClienteRepositorio = clienteRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
        }
        
        public void Commit()
        {
           _dbContexto.SaveChanges();
        }

        
    }
}