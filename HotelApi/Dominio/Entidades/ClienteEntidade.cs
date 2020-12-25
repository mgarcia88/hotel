using System;
using HotelApi.ValueObjects;

namespace HotelApi.Dominio.Entidades
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }

        public Cpf Documento { get; set; }

        public Email Email { get; set; }

        public ClienteStatus ClienteStatus { get; set; }
    }
}