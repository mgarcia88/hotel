using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs.Pessoa;
using HotelApi.Excecões;

namespace HotelApi.Servicos
{
    public class PessoaServico : IPessoaServico
    {
        private IUnitOfWork _unitOfWork;

        public PessoaServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Pessoa InserirPessoa(InsercaoPessoaDTO pessoaDto, int enderecoId)
        {
            var pessoaBaseDados =
                _unitOfWork.PessoaRepositorio.RecuperarPessoaPeloNumeroDoDocumento(pessoaDto.Documento.ToString());

            if (pessoaBaseDados != null)
            {
                throw new PessoaJaCadastradaExcecao("Pessoa já possui cadastro");
            }

            var Pessoa = new Pessoa
            {
                Nome = pessoaDto.Nome,
                Documento = pessoaDto.Documento,
                Email = pessoaDto.Email,
                EnderecoId = enderecoId
            };

            _unitOfWork.PessoaRepositorio.Incluir(Pessoa);
            _unitOfWork.Commit();

            return Pessoa;
        }
    }
}