using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs;
using HotelApi.DTOs.Cliente;
using HotelApi.Excecões;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientesController : ControllerBase
    {
        private IClienteServico _clienteServico;

        public ClientesController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpPost("InserirCliente")]
        [Authorize(Roles = "Admin, FuncionarioHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult InserirCliente(InsercaoClienteDTO insercaoClienteDto)
        {
            var resultadoInsercao = _clienteServico.InserirCliente(insercaoClienteDto).Result;

            if (!resultadoInsercao.sucesso)
            {
                return Problem(resultadoInsercao.erro, statusCode: StatusCodes.Status400BadRequest);
            }

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, FuncionarioHotel")]
        [ProducesResponseType(typeof(List<ListagemClienteDTO>), StatusCodes.Status200OK)]
        public IActionResult ObterTodosClientes()
        {
            var todosClientes = _clienteServico.RecuperarClientes();
            return Ok(todosClientes.OrderBy(c => c.Id));
        }

        [HttpGet("PesquisarClientePeloDocumento")]
        [Authorize(Roles = "Admin, FuncionarioHotel")]
        [ProducesResponseType(typeof(ListagemClienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails),statusCode:StatusCodes.Status404NotFound)]
        public IActionResult PesquisarClientePeloDocumento(string documento)
        {
            try
            {
                var cliente = _clienteServico.PesquisarClientePeloDocumento(documento);

                return Ok(cliente);
            }
            catch (ClienteNaoEncontradoExcecao e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (ArgumentException e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status400BadRequest);
            }
        }
    }
}