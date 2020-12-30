using System.Collections.Generic;
using System.Linq;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EstadosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<Estado>), statusCode: StatusCodes.Status200OK)]
        [Authorize]
        public IActionResult RecuperarEstados()
        {
           var todosEstados = _unitOfWork.EstadoRepositorio.ObterTodos();

           return Ok(todosEstados.OrderBy(e => e.Nome));
        }
    }
}