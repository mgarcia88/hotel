using System;
using System.ComponentModel.DataAnnotations;
using HotelApi.Dominio.Objetos;

namespace HotelApi.Dominio.Entidades
{
    public class Endereco : Entidade
    {
        public string Cep { get; private set; }

        public string Logradouro { get; private set; }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Complemento { get; private set; }

        public int CidadeId { get; private set; }

        public Cidade Cidade { get; set; }

        public Endereco(string cep, string logradouro, string numero, string bairro, string complemento, int cidadeId)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            CidadeId = cidadeId;
            
            Validar();
        }

        public void AlterarCidade(Cidade cidade)
        {
            Cidade = cidade;
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(Cep, "O campo cep não pode ser vazio");
            Validacoes.ValidarSeVazio(Logradouro, "O campo logradouro não pode ser vazio");
            Validacoes.ValidarSeVazio(Numero, "O campo número é obrigatório");
            Validacoes.ValidarSeVazio(Bairro, "O campo bairro é obrigatório");
            Validacoes.ValidarSeNulo(CidadeId, "O campo cidade não pode ser nulo");
        }
    }
}