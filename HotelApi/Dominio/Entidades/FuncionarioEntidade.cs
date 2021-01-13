using System;

namespace HotelApi.Dominio.Entidades
{
    public class Funcionario : Entidade
    {
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}