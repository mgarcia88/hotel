using System;
using System.Collections.Generic;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.DTOs.Cliente;
using HotelApi.Excecões;
using HotelApi.Infraestrutura.Interfaces;
using HotelApi.ValueObjects;

namespace HotelApi.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private IUnitOfWork _unitOfWork;
        private IEnderecoServico _enderecoServico;
        private IPessoaServico _pessoaServico;
        private readonly IUsuarioLogado _usuarioLogado;

        public ClienteServico(IUnitOfWork unitOfWork,
            IEnderecoServico enderecoServico,
            IPessoaServico pessoaServico,
            IUsuarioLogado usuarioLogado
        )
        {
            _unitOfWork = unitOfWork;
            _enderecoServico = enderecoServico;
            _pessoaServico = pessoaServico;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<dynamic> InserirCliente(InsercaoClienteDTO insercaoClienteDto)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var usuarioLogado = _usuarioLogado.RecuperarUsuarioLogado();
                
                var pessoa = _pessoaServico.InserirPessoa(insercaoClienteDto.Pessoa);

                var endereco = _enderecoServico.InserirEndereco(insercaoClienteDto.Endereco, pessoa.Id);

                var Cliente = new Cliente
                {
                    TelefoneCelular = insercaoClienteDto.TelefoneCelular,
                    PessoaId = pessoa.Id,
                    HotelId =  usuarioLogado.HotelId,
                    EnderecoId = endereco.Id
                };

                _unitOfWork.ClienteRepositorio.Incluir(Cliente);
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
            var usuarioLogado = _usuarioLogado.RecuperarUsuarioLogado();
            
            var todosClientes = _unitOfWork.ClienteRepositorio.ObterTodos(usuarioLogado.HotelId)
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
                        },
                        Endereco = new Endereco(x.Endereco.Cep,x.Endereco.Logradouro,
                            x.Endereco.Numero,x.Endereco.Bairro, x.Endereco.Complemento, x.Endereco.CidadeId)
                    })
                .ToList();

            return todosClientes;
        }

        public ListagemClienteDTO PesquisarClientePeloDocumento(string cpf)
        {
            var documento = Cpf.Parse(cpf);

            var cliente = _unitOfWork.ClienteRepositorio.PesquisarClientePeloDocumento(documento);

            if (cliente == null)
            {
                throw new ClienteNaoEncontradoExcecao("Cliente não encontrado na base de dados");
            }

            return new ListagemClienteDTO()
            {
                Id = cliente.Id, TelefoneCelular = cliente.TelefoneCelular,
                Documento = cliente.Pessoa.Documento.ToString(),
                Email = cliente.Pessoa.Email.ToString(),
                Pessoa = new Pessoa()
                {
                    Nome = cliente.Pessoa.Nome,
                    Documento = cliente.Pessoa.Documento,
                    Email = cliente.Pessoa.Email,
                },
                Endereco = new Endereco(cliente.Endereco.Cep,cliente.Endereco.Logradouro,
                    cliente.Endereco.Numero,cliente.Endereco.Bairro, cliente.Endereco.Complemento, cliente.Endereco.CidadeId)
            };
        }
    }
}