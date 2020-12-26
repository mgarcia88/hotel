using System;
using HotelApi.ValueObjects;

namespace HotelApi.Dominio.Entidades
{
    public class Hotel : Entidade
    {
        public string Nome { get; set; }

        public int Classificacao { get; set; }

        public double ValorFinalDeSemana { get; set; }

        public double ValorDuranteSemana { get; set; }

        public Cnpj Documento { get; set; }

        public string TelefonePrincipal { get; set; }

        public string TelefoneSecundario { get; set; }

        public Endereco Endereco { get; set; }

        public int EnderecoId { get; set; }
    }
}