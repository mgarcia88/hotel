using System.Linq;
using System.Security.Claims;
using HotelApi.Infraestrutura.Interfaces;
using HotelApi.Infraestrutura.Transporte;
using Microsoft.AspNetCore.Http;

namespace HotelApi.Infraestrutura.Identidade
{
    public class UsuarioLogado : IUsuarioLogado
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UsuarioLogado(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public RepresentacaoUsuario RecuperarUsuarioLogado()
        {
            return new RepresentacaoUsuario()
            {
                Id = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == "idUsuario")
                    ?.Value,
                Login = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.Name)
                    ?.Value,
                HotelId =int.Parse(_httpContextAccessor.HttpContext.User.Claims.
                    FirstOrDefault(c => c.Type == "hotelId")?.Value ?? "0")
            };
        }
    }
}