namespace HotelApi.Dominio.Entidades
{
    public class Endereco : Entidade
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Complemento { get; set; }

        public int CidadeId { get; set; }
    }
}