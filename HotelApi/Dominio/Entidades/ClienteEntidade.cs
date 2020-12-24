using System;
using HotelApi.ValueObjects;

namespace HotelApi.Dominio.Entidades
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        public string Email { get; set; }

        public ClienteStatus ClienteStatus { get; set; }
    }
}