using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Servicos;
using HotelApi.DTOs.Endereco;

namespace HotelApi.Servicos
{
    public class EnderecoServico : IEnderecoServico
    {
        private IUnitOfWork _unitOfWork;

        public EnderecoServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public Endereco InserirEndereco(InsercaoEnderecoDTO insercaoEnderecoDto)
        {
            var Endereco = new Endereco
            {
                Cep    = insercaoEnderecoDto.Cep,
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
    }
}