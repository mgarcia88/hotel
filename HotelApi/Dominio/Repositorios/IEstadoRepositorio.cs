using System.Threading.Tasks;
using HotelApi.Dominio.Entidades;

namespace HotelApi.Dominio.Repositorio
{
    public interface IEstadoRepositorio : IRepositorio<Estado>
    {
        Task<Estado> RecuperarEstadoPelaSigla(string sigla);
    }
}