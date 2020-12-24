
using HotelApi.Dominio.Entidades.Repositorio;

namespace HotelApi.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        
        IClienteRepositorio ClienteRepositorio { get; } 
    }
}