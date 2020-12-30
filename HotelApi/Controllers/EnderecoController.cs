using System.Threading.Tasks;
using HotelApi.Dominio.Servicos;
using HotelApi.Infraestrutura.Transporte;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoServico _enderecoServico;
        
        public EnderecoController(IEnderecoServico enderecoServico)
        {
            _enderecoServico = enderecoServico;
        }
        
        [HttpGet("RecuperarEnderecoPeloCep")]
        [ProducesResponseType(typeof(RetornoCepTransporte), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        public IActionResult RecuperarEnderecoPeloCep(string cep)
        {
            var endereco = _enderecoServico.RecuperarEnderecoPeloCep(cep).Result;

            if (!endereco.Sucesso)
            {
                return Problem(endereco.Mensagem, statusCode: StatusCodes.Status404NotFound);
            }

            return Ok(endereco);
        }
    }
}