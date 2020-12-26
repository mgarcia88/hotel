using HotelApi.Dominio.Repositorio;

namespace HotelApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _dbContexto;

        public IClienteRepositorio ClienteRepositorio { get; }
        
        public IUsuarioRepositorio UsuarioRepositorio { get; }
        public IPessoaRepositorio PessoaRepositorio { get; }
        public IEnderecoRepositorio EnderecoRepositorio { get; }

        public UnitOfWork(ApplicationContext dbContexto,
            IClienteRepositorio clienteRepositorio,
            IUsuarioRepositorio usuarioRepositorio,
            IEnderecoRepositorio enderecoRepositorio,
            IPessoaRepositorio pessoaRepositorio)
        {
            _dbContexto = dbContexto;
            ClienteRepositorio = clienteRepositorio;
            UsuarioRepositorio = usuarioRepositorio;
            PessoaRepositorio = pessoaRepositorio;
            EnderecoRepositorio = enderecoRepositorio;
        }
        
        public void Commit()
        {
           _dbContexto.SaveChanges();
        }

        
    }
}