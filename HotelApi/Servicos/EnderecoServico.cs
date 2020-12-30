using System;
using System.Threading.Tasks;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs.Endereco;
using HotelApi.Infraestrutura.Interfaces;
using HotelApi.Infraestrutura.Transporte;

namespace HotelApi.Servicos
{
    public class EnderecoServico : IEnderecoServico
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConsultaCep _consultaCep;
        private readonly ICidadeServico _cidadeServico;

        public EnderecoServico(
            IUnitOfWork unitOfWork,
            IConsultaCep consultaCep,
            ICidadeServico cidadeServico
        )
        {
            _unitOfWork = unitOfWork;
            _consultaCep = consultaCep;
            _cidadeServico = cidadeServico;
        }

        public Endereco InserirEndereco(InsercaoEnderecoDTO insercaoEnderecoDto)
        {
            var Endereco = new Endereco
            {
                Cep = insercaoEnderecoDto.Cep,
                Logradouro = insercaoEnderecoDto.Logradouro,
                Bairro = insercaoEnderecoDto.Bairro,
                Numero = insercaoEnderecoDto.Numero,
                CidadeId = 1,
                Complemento = insercaoEnderecoDto.Complemento
            };

            _unitOfWork.EnderecoRepositorio.Incluir(Endereco);
            _unitOfWork.Commit();

            return Endereco;
        }

        public async Task<RetornoCepTransporte> RecuperarEnderecoPeloCep(string cep)
        {
            try
            {
                var enderecoViaCep = await _consultaCep.RecuperarEnderecoPeloCep(cep);

                if (enderecoViaCep.Cep == null)
                {
                    return new RetornoCepTransporte()
                    {
                        Sucesso = false
                    };
                }

                var cidadeDoBancoDeDados = await
                    _cidadeServico.RecuperarCidadePeloNome(enderecoViaCep.Localidade);

                var cidadeId = 0;

                if (cidadeDoBancoDeDados == null)
                {
                    var cidadeNova = await 
                    InserirCidadeNova(enderecoViaCep.Localidade, enderecoViaCep.UF);

                    cidadeId = cidadeNova.Id;
                }
                else
                {
                    cidadeId = cidadeDoBancoDeDados.Id;
                }

                return new RetornoCepTransporte()
                {
                    Cep = enderecoViaCep.Cep,
                    Logradouro = enderecoViaCep.Logradouro,
                    Localidade = enderecoViaCep.Localidade,
                    Bairro = enderecoViaCep.Bairro,
                    Complemento = enderecoViaCep.Complemento,
                    UF = enderecoViaCep.UF,
                    CidadeId = cidadeId,
                    Mensagem = "Endereço recuperado com sucesso",
                    Sucesso = true
                };
            }
            catch (Exception)
            {
                throw new Exception("Erro ao recuperar o cep do cliente");
            }
        }

        public async Task<Cidade> InserirCidadeNova(string localidade, string sigla)
        {
            var estadoId = await RecuperarIdEstadoPelaSigla(sigla);

            var cidadeNova = new Cidade()
            {
                Nome = localidade,
                EstadoId = estadoId
            };

            return _cidadeServico.InserirCidade(cidadeNova);
        }

        public async Task<int> RecuperarIdEstadoPelaSigla(string sigla)
        {
            var estado = await _unitOfWork.EstadoRepositorio.RecuperarEstadoPelaSigla(sigla);

            return estado.Id;
        }
    }
}