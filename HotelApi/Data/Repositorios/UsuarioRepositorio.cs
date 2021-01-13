using System.Linq;
using System.Threading.Tasks;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async Task<Usuario> AutenticarUsuarioComLogineSenha(string login, string senha)
        {
           return await DbSet.Include(f => f.Funcionario)
                .ThenInclude(h => h.Hotel).AsNoTracking().
                FirstOrDefaultAsync(u => u.Login == login && u.Senha == senha);
        }
    }
}