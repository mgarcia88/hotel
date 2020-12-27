using System.Linq;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Repositorio;
using HotelApi.ValueObjects;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data.Repositorios
{
    public class PessoaRepositorio : Repositorio<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public Pessoa RecuperarPessoaPeloNumeroDoDocumento(string cpf)
        {
            return DbSet.AsEnumerable().
                Where(p => p.Documento.ToString() == cpf).ToList().FirstOrDefault();
        }
    }
}