using System;
using System.Collections.Generic;
using System.Linq;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs;
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
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult InserirCliente(InsercaoClienteDTO insercaoClienteDto)
        {
            try
            {
                _clienteServico.InserirCliente(insercaoClienteDto);
            }
            catch (ArgumentException e)
            {
                return Problem(e.Message, statusCode: StatusCodes.Status400BadRequest);
            }

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(List<ListagemClienteDTO>), StatusCodes.Status200OK)]
        public IActionResult ObterTodosClientes()
        {
            var todosClientes = _clienteServico.RecuperarClientes();
            return Ok(todosClientes.OrderBy(c => c.Id));
        }
    }
}