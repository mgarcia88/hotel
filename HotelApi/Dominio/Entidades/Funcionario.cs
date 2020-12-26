using System;

namespace HotelApi.Dominio.Entidades
{
    public class Funcionario : Entidade
    {
        public Pessoa Pessoa { get; set; }

        public int PessoaId { get; set; }

        public DateTime DataAdmissao { get; set; }
        
        public DateTime DataDemissao { get; set; }
    }
}