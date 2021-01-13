using HotelApi.ValueObjects;

namespace HotelApi.Dominio.Entidades
{
    public class Pessoa : Entidade
    {
        public string Nome { get; set; }

        public Cpf Documento { get; set; }

        public Email Email { get; set; }
    }
}