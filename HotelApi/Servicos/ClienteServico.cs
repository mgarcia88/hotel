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
            var Endereco = new Endereco
            {
                Cep    = insercaoClienteDto.Endereco.Cep,
                Logradouro = insercaoClienteDto.Endereco.Logradouro,
                Bairro = insercaoClienteDto.Endereco.Bairro,
                Numero = insercaoClienteDto.Endereco.Numero,
                CidadeId = 1,
                Complemento = insercaoClienteDto.Endereco.Complemento
            };

            _unitOfWork.EnderecoRepositorio.Incluir(Endereco);

            var Pessoa = new Pessoa
            {
                Nome = insercaoClienteDto.Nome,
                Documento = insercaoClienteDto.Documento,
                Email = insercaoClienteDto.Email,
                //EnderecoId = enderecoId
            };

            var pessoaId = _unitOfWork.PessoaRepositorio.Incluir(Pessoa).Id;
            
            var Cliente = new Cliente
            {
                TelefoneCelular = insercaoClienteDto.TelefoneCelular,
                PessoaId = pessoaId
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
                        Id = x.Id, //ClienteStatus = x.ClienteStatus
                    })
                .ToList();

            return todosClientes;
        }
    }
}