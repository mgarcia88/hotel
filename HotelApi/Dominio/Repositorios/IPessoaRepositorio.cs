
using HotelApi.Dominio.Entidades;

namespace HotelApi.Dominio.Repositorio
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Pessoa RecuperarPessoaPeloNumeroDoDocumento(string cpf);
    }
}