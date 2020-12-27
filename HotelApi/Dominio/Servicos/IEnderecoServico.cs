using HotelApi.Dominio.Entidades;
using HotelApi.DTOs.Endereco;

namespace HotelApi.Dominio.Servicos
{
    public interface IEnderecoServico
    {
        Endereco InserirEndereco(InsercaoEnderecoDTO endereco);
    }
}