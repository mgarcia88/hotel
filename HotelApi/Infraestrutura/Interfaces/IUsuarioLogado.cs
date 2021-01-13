using HotelApi.Infraestrutura.Transporte;

namespace HotelApi.Infraestrutura.Interfaces
{
    public interface IUsuarioLogado
    {
        RepresentacaoUsuario RecuperarUsuarioLogado();
    }
}