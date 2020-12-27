using System;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs.Login;
using HotelApi.DTOs.Usuario;
using HotelApi.Excecões;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioServico _usuarioServico;

        public UsuarioController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        
        [HttpPost("InserirUsuario")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult InserirUsuario(UsuarioInsercaoDTO usuarioInsercaoDto)
        {
            try
            {
                _usuarioServico.InserirUsuario(usuarioInsercaoDto);
            }
            catch (ArgumentException ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
            
            return  Ok();
        }

        [HttpPost("LoginComSenha")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult AutenticarUsuarioComLogineSenha(LoginDTO loginDto)
        {
            if (loginDto.Login == string.Empty)
            {
                return Problem("O campo login é obrigatório", statusCode: StatusCodes.Status400BadRequest);
            }
            
            if (loginDto.Senha == string.Empty)
            {
                return Problem("O campo senha é obrigatório", statusCode: StatusCodes.Status400BadRequest);
            }

            try
            {
               return Ok(_usuarioServico.AutenticarUsuarioComLogineSenha(loginDto.Login, loginDto.Senha));
            }
            catch (UsuarioNaoEncontradoExceção e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status401Unauthorized);
            }
        }
    }
}