namespace HotelApi.Dominio.Entidades
{
    public class Cidade : Entidade
    {
        public int EstadoId { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }
    }
}