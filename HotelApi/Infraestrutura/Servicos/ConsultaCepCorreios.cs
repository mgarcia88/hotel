using System.Threading.Tasks;
using HotelApi.Infraestrutura.Interfaces;
using HotelApi.Infraestrutura.Transporte;

namespace HotelApi.Infraestrutura.Servicos
{
    public class ConsultaCepCorreios : IConsultaCep
    {
        public Task<ViaCepRetornoTransporte> RecuperarEnderecoPeloCep(string cep)
        {
            throw new System.NotImplementedException();
        }
    }
}