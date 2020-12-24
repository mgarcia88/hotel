using System;
using HotelApi.ValueObjects;

namespace HotelApi.Dominio.Entidades
{
    public class Reserva : Entidade
    {
        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        public Hotel Hotel { get; set; }

        public int HotelId { get; set; }

        public double ValorDiaria { get; set; }
        
        public double ValorDesconto { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime DataSaida { get; set; }

        public ReservaStatus ReservaStatus { get; set; }
    }
}