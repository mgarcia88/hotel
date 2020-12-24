using System;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Entidades.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T: Entidade
    {
        protected ApplicationContext Db { get; }

        protected DbSet<T> DbSet { get; }

        public Repositorio(ApplicationContext dbContext)
        {
            Db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = Db.Set<T>();
        }
        
        public IQueryable<T> ObterTodos(int pagina = 0, int limite = 50)
        {
            return DbSet.AsNoTracking()
                .OrderBy(e => e.Id)
                .Skip(pagina)
                .Take(limite);
        }

        public async Task<T> ObterPorId(long id)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public T Incluir(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public T Alterar(T entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}