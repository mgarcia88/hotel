
using HotelApi.Dominio.Repositorio;

namespace HotelApi.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        
        IClienteRepositorio ClienteRepositorio { get; } 
        IUsuarioRepositorio UsuarioRepositorio { get; }
    }
}