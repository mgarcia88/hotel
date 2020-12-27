using System.Linq;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Repositorio;
using HotelApi.DTOs.Cliente;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Cliente> ObterTodos(int pagina = 0, int limite = 50)
        {
            return DbSet.AsNoTracking()
                .OrderBy(e => e.Id)
                .Skip(pagina)
                .Take(limite).Include(p => p.Pessoa).
                ThenInclude(e => e.Endereco);
        }
    }
}