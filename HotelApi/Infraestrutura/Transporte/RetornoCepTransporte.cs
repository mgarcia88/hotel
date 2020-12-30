namespace HotelApi.Infraestrutura.Transporte
{
    public class RetornoCepTransporte : Transporte
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
    }
}