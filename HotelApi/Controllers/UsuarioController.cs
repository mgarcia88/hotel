using System.Threading.Tasks;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.DTOs;
using HotelApi.DTOs.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("InserirUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult InserirUsuario(UsuarioInsercaoDTO usuarioInsercaoDto)
        {
            var usuario = new Usuario
            {
                Login = usuarioInsercaoDto.Login,
                Senha = usuarioInsercaoDto.Senha,
                UsuariosGrupo = usuarioInsercaoDto.UsuarioGrupo
            };
            
            _unitOfWork.UsuarioRepositorio.Incluir(usuario);
            _unitOfWork.Commit();
            return  Ok();
        }
    }
}