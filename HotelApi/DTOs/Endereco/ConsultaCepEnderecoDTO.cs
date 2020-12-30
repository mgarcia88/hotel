namespace HotelApi.DTOs.Endereco
{
    public class ConsultaCepEnderecoDTO
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public bool sucesso { get; set; }
    }
}