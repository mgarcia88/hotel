using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Servicos;
using Microsoft.IdentityModel.Tokens;

namespace HotelApi.Servicos
{
    public class TokenServico : ITokenServico
    {
        public string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Login),
                    new Claim(ClaimTypes.Role, usuario.UsuariosGrupo.ToString()),
                    new Claim("idUsuario", usuario.Id.ToString()),
                    new Claim("hotelId", usuario.Funcionario.HotelId.ToString()), 
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}