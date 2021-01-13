using System.Linq;
using System.Threading.Tasks;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Repositorio;
using HotelApi.DTOs.Cliente;
using HotelApi.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Cliente> ObterTodos(int idHotel,int pagina = 0, int limite = 50)
        {
            return DbSet.AsNoTracking()
                .Where(c => c.HotelId == idHotel)
                .OrderBy(e => e.Id)
                .Skip(pagina)
                .Take(limite).Include(p => p.Pessoa).
                Include(e => e.Endereco);
        }

        public Cliente PesquisarClientePeloDocumento(Cpf documento)
        {
            return DbSet
                .Include(p=> p.Pessoa)
                .Include(e => e.Endereco)
                .AsEnumerable().
                FirstOrDefault(c => c.Pessoa.Documento.ToString() == documento.ToString());
        }
    }
}