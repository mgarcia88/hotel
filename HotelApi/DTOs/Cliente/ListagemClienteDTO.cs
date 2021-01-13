using HotelApi.ValueObjects;

namespace HotelApi.DTOs.Cliente
{
    public class ListagemClienteDTO
    {
        public int Id { get; set; }
        public StatusPessoa ClienteStatus { get; set; }
        public Dominio.Entidades.Pessoa Pessoa { get; set; }
        public string TelefoneCelular { get; set; }

        public string Documento { get; set; }
        
        public string Email { get; set; }

        public Dominio.Entidades.Endereco Endereco { get; set; }
    }
}