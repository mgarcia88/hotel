using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        
        public ClientesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost("InserirCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult InserirCliente(InsercaoClienteDTO insercaoClienteDto)
        {
            var Cliente = new Cliente
            {
                Nome = insercaoClienteDto.Nome,
                Email = insercaoClienteDto.Email,
                Documento = insercaoClienteDto.Documento,
                ClienteStatus = insercaoClienteDto.ClienteStatus
            };
            
            _unitOfWork.ClienteRepositorio.Incluir(Cliente);
            
            _unitOfWork.Commit();

           return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ListagemClienteDTO>), StatusCodes.Status200OK)]
        public IActionResult ObterTodosClientes()
        {
            var todosClientes = _unitOfWork.ClienteRepositorio.ObterTodos()
                .Select(x => 
                    new ListagemClienteDTO() { Id = x.Id, Nome = x.Nome, Email = x.Email, 
                        Documento = x.Documento, ClienteStatus = x.ClienteStatus})
                .ToList();

            return Ok(todosClientes.OrderBy(c => c.Id));
        }
    }
}