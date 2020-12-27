using HotelApi.Dominio.Entidades;
using HotelApi.DTOs.Pessoa;

namespace HotelApi.Dominio.Servicos
{
    public interface IPessoaServico
    {
        Pessoa InserirPessoa(InsercaoPessoaDTO pessoaDto, int enderecoId);
    }
}