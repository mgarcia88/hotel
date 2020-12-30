using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using HotelApi.Infraestrutura.Interfaces;
using HotelApi.Infraestrutura.Transporte;

namespace HotelApi.Infraestrutura.Servicos
{
    public class ConsultaEnderecoViaCep : IConsultaCep
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ConsultaEnderecoViaCep(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<ViaCepRetornoTransporte> RecuperarEnderecoPeloCep(string cep)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri($"https://viacep.com.br/ws/{cep}/json");
            var retorno = await httpClient.GetAsync("");
            
            var endereco = JsonSerializer.Deserialize<ViaCepRetornoTransporte>(
                await retorno.Content.ReadAsStringAsync());

            return endereco;
        }
    }
}