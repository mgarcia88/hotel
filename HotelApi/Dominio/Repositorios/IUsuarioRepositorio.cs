using System.Threading.Tasks;
using HotelApi.Dominio.Entidades;

namespace HotelApi.Dominio.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<Usuario> AutenticarUsuarioComLogineSenha(string login, string senha);
    }
}