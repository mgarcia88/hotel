using System;
using System.Collections.Generic;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs.Cliente;

namespace HotelApi.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private IUnitOfWork _unitOfWork;
        private IEnderecoServico _enderecoServico;
        private IPessoaServico _pessoaServico;
        
        public ClienteServico(IUnitOfWork unitOfWork,
            IEnderecoServico enderecoServico,
            IPessoaServico pessoaServico
            )
        {
            _unitOfWork = unitOfWork;
            _enderecoServico = enderecoServico;
            _pessoaServico = pessoaServico;
        }
        
        public async Task<dynamic> InserirCliente(InsercaoClienteDTO insercaoClienteDto)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var endereco = _enderecoServico.InserirEndereco(insercaoClienteDto.Endereco);

                var pessoa = _pessoaServico.InserirPessoa(insercaoClienteDto.Pessoa, endereco.Id);
            
                var Cliente = new Cliente
                {
                    TelefoneCelular = insercaoClienteDto.TelefoneCelular,
                    PessoaId = pessoa.Id
                };
            
                var retorno =_unitOfWork.ClienteRepositorio.Incluir(Cliente);
                await _unitOfWork.CommitTransaction();

                return new
                {
                    sucesso = true,
                    data = Cliente
                };
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransaction();
                return new
                {
                    sucesso = false,
                    erro = e.Message
                };
            }
        }

        public List<ListagemClienteDTO> RecuperarClientes()
        {
            var todosClientes = _unitOfWork.ClienteRepositorio.ObterTodos()
                .Select(x =>
                    new ListagemClienteDTO()
                    {
                        Id = x.Id, TelefoneCelular = x.TelefoneCelular, 
                        Documento = x.Pessoa.Documento.ToString(),
                        Email = x.Pessoa.Email.ToString(),
                        Pessoa = new Pessoa()
                        {
                            Nome = x.Pessoa.Nome,
                            Documento = x.Pessoa.Documento,
                            Email = x.Pessoa.Email,
                            Endereco =  new Endereco()
                            {
                                Cep = x.Pessoa.Endereco.Cep,
                                Logradouro = x.Pessoa.Endereco.Logradouro,
                                Numero = x.Pessoa.Endereco.Numero,
                                Bairro = x.Pessoa.Endereco.Bairro,
                                Complemento = x.Pessoa.Endereco.Complemento
                            }
                        }
                    })
                .ToList();

            return todosClientes;
        }
    }
}