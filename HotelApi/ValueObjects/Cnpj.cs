using System;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace HotelApi.ValueObjects
{
    public struct Cnpj
    {
        private readonly string _value;
        
        private Cnpj(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
        
        public static implicit operator Cnpj(string input) => new Cnpj(input);

        public static Cnpj Parse(string value)
        {
            if (TryParse(value, out var resultado))
            {
                return resultado;
            }
            
            throw new ArgumentException("CNPJ inválido");
        }

        public static bool TryParse(string value, out Cnpj cnpj)
        {
            int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
            int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            value = value.Trim();
            value = value.Replace(".", "").Replace("-", "").Replace("/", "");

            if (value.Length != 14)
            {
                cnpj= new Cnpj();
                return false;
            }

            tempCnpj = value.Substring(0, 12);
            soma = 0;
            for(int i=0; i<12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if ( resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            
            cnpj = new Cnpj(value);
            return value.EndsWith(digito);
        }
    }
}