using System;

namespace HotelApi.Dominio.Entidades
{
    public class Funcionario : Entidade
    {
        public Pessoa Pessoa { get; private set; }
        public int PessoaId { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public DateTime DataDemissao { get; private set; }
        public int HotelId { get; private set; }
        public Hotel Hotel { get; private set; }
        public int EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }

        /// <summary>
        /// construtor classe funcionario
        /// </summary>
        /// <param name="dataAdmissao"></param>
        /// <param name="dataDemissao"></param>
        /// <param name="hotelId"></param>
        /// <param name="enderecoId"></param>
        public Funcionario(DateTime dataAdmissao, DateTime dataDemissao, int hotelId, int enderecoId)
        {
            DataAdmissao = dataAdmissao;
            DataDemissao = dataDemissao;
            HotelId = hotelId;
            EnderecoId = enderecoId;
        }
    }
}