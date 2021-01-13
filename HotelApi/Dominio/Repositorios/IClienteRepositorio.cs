using System.Linq;
using HotelApi.Dominio.Entidades;
using HotelApi.ValueObjects;

namespace HotelApi.Dominio.Repositorio
{
    public interface IClienteRepositorio: IRepositorio<Cliente>
    {
        Cliente PesquisarClientePeloDocumento(Cpf documento);
        
        IQueryable<Cliente> ObterTodos(int idHotel,int pagina = 0, int limite = 50);
    }
}