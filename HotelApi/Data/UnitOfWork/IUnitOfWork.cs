
using System.Threading.Tasks;
using HotelApi.Dominio.Repositorio;

namespace HotelApi.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        IClienteRepositorio ClienteRepositorio { get; } 
        IUsuarioRepositorio UsuarioRepositorio { get; }
        IPessoaRepositorio PessoaRepositorio { get; }
        IEnderecoRepositorio EnderecoRepositorio { get; }
    }
}