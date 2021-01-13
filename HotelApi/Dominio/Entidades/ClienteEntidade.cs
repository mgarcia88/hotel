using System;
using HotelApi.ValueObjects;

namespace HotelApi.Dominio.Entidades
{
    public class Cliente : Entidade
    { 
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public string TelefoneCelular { get; set; }
        public int HotelId { get; set; }
        public Endereco Endereco { get; set; }

        public int EnderecoId { get; set; }
    }
}