using HotelApi.ValueObjects;

namespace HotelApi.DTOs
{
    public class ListagemClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public ClienteStatus ClienteStatus { get; set; }
    }
}