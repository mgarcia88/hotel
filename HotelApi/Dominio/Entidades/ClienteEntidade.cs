using System;
using HotelApi.Dominio.Objetos;
using HotelApi.ValueObjects;

namespace HotelApi.Dominio.Entidades
{
    public class Cliente : Entidade
    { 
        public Pessoa Pessoa { get; private set; }
        public int PessoaId { get; private set; }
        public string TelefoneCelular { get; private set; }
        public int HotelId { get; private set; }
        public Endereco Endereco { get; private set; }
        public int EnderecoId { get; private set; }

        /// <summary>
        /// construtor classe cliente
        /// </summary>
        /// <param name="telefoneCelular"></param>
        /// <param name="pessoaId"></param>
        /// <param name="enderecoId"></param>
        /// <param name="hotelId"></param>
        public Cliente(string telefoneCelular, int pessoaId, int enderecoId, int hotelId)
        {
            TelefoneCelular = telefoneCelular;
            PessoaId = pessoaId;
            EnderecoId = enderecoId;
            HotelId = hotelId;
            
            Validar();
        }
        
        private void Validar()
        {
            Validacoes.ValidarSeVazio(TelefoneCelular, "O campo telefone celular não pode ser vazio");
            Validacoes.ValidarSeNulo(PessoaId, "O id da pessoa não pode ser nulo");
            Validacoes.ValidarSeNulo(EnderecoId, "O id do endereço não pode ser nulo");
            Validacoes.ValidarSeNulo(HotelId, "O id do hotel não pode ser nulo");
        }
    }
}