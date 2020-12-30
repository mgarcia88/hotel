using System.Threading.Tasks;
using HotelApi.Data.UnitOfWork;
using HotelApi.Dominio.Entidades;
using HotelApi.Dominio.Servicos;

namespace HotelApi.Servicos
{
    public class CidadeServico : ICidadeServico
    {
        private readonly IUnitOfWork _unitOfWork;

        public CidadeServico(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public Cidade InserirCidade(Cidade cidade)
        {
            _unitOfWork.CidadeRepositorio.Incluir(cidade);
            _unitOfWork.Commit();
            return cidade;
        }

        public async Task<Cidade> RecuperarCidadePeloNome(string nome)
        {
            return await _unitOfWork.CidadeRepositorio.RecuperarCidadePeloNome(nome);
        }
    }
}