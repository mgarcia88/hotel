using System.Threading.Tasks;
using HotelApi.DTOs.Endereco;
using HotelApi.Infraestrutura.Transporte;

namespace HotelApi.Infraestrutura.Interfaces
{
    public interface IConsultaCep
    {
        Task<ViaCepRetornoTransporte> RecuperarEnderecoPeloCep(string cep);
    }
}