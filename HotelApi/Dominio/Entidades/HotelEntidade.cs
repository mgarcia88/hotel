using System;

namespace HotelApi.Dominio.Entidades
{
    public class Hotel : Entidade
    {
        public string Nome { get; set; }

        public int Classificacao { get; set; }

        public double ValorFinalDeSemana { get; set; }

        public double ValorDuranteSemana { get; set; }
    }
}