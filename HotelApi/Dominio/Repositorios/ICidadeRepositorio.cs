using System.Threading.Tasks;
using HotelApi.Dominio.Entidades;

namespace HotelApi.Dominio.Repositorio
{
    public interface ICidadeRepositorio : IRepositorio<Cidade>
    {
        Task<Cidade> RecuperarCidadePeloNome(string nome);
    }
}