using System.Linq;
using System.Threading.Tasks;
using HotelApi.Dominio.Entidades;

namespace HotelApi.Dominio.Entidades.Repositorio
{
    public interface IRepositorio<T> where T : Entidade
    {
        IQueryable<T> ObterTodos(int pagina = 0, int limite = 50);

        Task<T> ObterPorId(long id);

        T Incluir(T entity);

        T Alterar(T entity);
    }
}