using System.Threading.Tasks;
using HotelApi.Dominio.Entidades;
using HotelApi.DTOs.Endereco;
using HotelApi.Infraestrutura.Transporte;

namespace HotelApi.Dominio.Servicos
{
    public interface IEnderecoServico
    {
        Endereco InserirEndereco(InsercaoEnderecoDTO endereco, int PessoaId);

        Task<RetornoCepTransporte> RecuperarEnderecoPeloCep(string cep);
    }
}