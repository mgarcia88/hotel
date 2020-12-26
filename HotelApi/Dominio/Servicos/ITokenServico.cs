using HotelApi.Dominio.Entidades;

namespace HotelApi.Dominio.Servicos
{
    public interface ITokenServico
    {
        string GerarToken(Usuario usuario);
    }
}