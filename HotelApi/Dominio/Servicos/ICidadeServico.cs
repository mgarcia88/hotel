using System.Threading.Tasks;
using HotelApi.Dominio.Entidades;

namespace HotelApi.Dominio.Servicos
{
    public interface ICidadeServico
    {
        Cidade InserirCidade(Cidade cidade);
        Task<Cidade> RecuperarCidadePeloNome(string nome);
    }
}