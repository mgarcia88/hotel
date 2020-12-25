using System.Collections.Generic;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs;
using System.Linq;

namespace HotelApi.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private IUnitOfWork _unitOfWork;
        
        public ClienteServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public Cliente InserirCliente(InsercaoClienteDTO insercaoClienteDto)
        {
            var Cliente = new Cliente
            {
                Nome = insercaoClienteDto.Nome,
                Email = insercaoClienteDto.Email,
                Documento = insercaoClienteDto.Documento,
                ClienteStatus = insercaoClienteDto.ClienteStatus
            };
            
            var retorno =_unitOfWork.ClienteRepositorio.Incluir(Cliente);
            
            _unitOfWork.Commit();

            return retorno;
        }

        public List<ListagemClienteDTO> RecuperarClientes()
        {
            var todosClientes = _unitOfWork.ClienteRepositorio.ObterTodos()
                .Select(x =>
                    new ListagemClienteDTO()
                    {
                        Id = x.Id, Nome = x.Nome, Email = x.Email.ToString(),
                        Documento = x.Documento.ToString(), ClienteStatus = x.ClienteStatus
                    })
                .ToList();

            return todosClientes;
        }
    }
}