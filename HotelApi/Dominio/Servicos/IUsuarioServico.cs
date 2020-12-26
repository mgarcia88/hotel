using HotelApi.Dominio.Entidades;
using HotelApi.DTOs.Usuario;

namespace HotelApi.Dominio.Servicos
{
    public interface IUsuarioServico
    {
        Usuario InserirUsuario(UsuarioInsercaoDTO usuarioInsercaoDto);

        dynamic AutenticarUsuarioComLogineSenha(string login, string senha);
    }
}